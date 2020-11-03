// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.ServiceHub.Framework;
using Microsoft.ServiceHub.Framework.Services;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Threading;
using NuGet.PackageManagement.VisualStudio;
using NuGet.VisualStudio;
using NuGet.VisualStudio.Implementation.Extensibility;
using NuGet.VisualStudio.Internal.Contracts;
using ContractsNuGetServices = NuGet.VisualStudio.Contracts.NuGetServices;
using IBrokeredServiceContainer = Microsoft.VisualStudio.Shell.ServiceBroker.IBrokeredServiceContainer;
using ISettings = NuGet.Configuration.ISettings;
using SVsBrokeredServiceContainer = Microsoft.VisualStudio.Shell.ServiceBroker.SVsBrokeredServiceContainer;
using Task = System.Threading.Tasks.Task;

namespace NuGetVSExtension
{
    // The disposables live for the duration of the process.
#pragma warning disable CA1001 // Types that own disposable fields should be disposable
    internal sealed class NuGetBrokeredServiceFactory
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        private readonly AsyncLazyInitializer _lazyInitializer;
        private AsyncLazy<ISettings> _lazySettings;
        private AsyncLazy<IVsSolutionManager> _lazySolutionManager;
        private INuGetProjectManagerServiceState _projectManagerServiceSharedState;
        private ISharedServiceState _sharedServiceState;

        private NuGetBrokeredServiceFactory()
        {
            _lazyInitializer = new AsyncLazyInitializer(InitializeAsync, ThreadHelper.JoinableTaskFactory);
        }

        internal static async ValueTask ProfferServicesAsync(IAsyncServiceProvider serviceProvider)
        {
            Assumes.NotNull(serviceProvider);

            IBrokeredServiceContainer brokeredServiceContainer = await serviceProvider.GetServiceAsync<SVsBrokeredServiceContainer, IBrokeredServiceContainer>();

            var factory = new NuGetBrokeredServiceFactory();

            // This service descriptor reference will cause NuGet.VisualStudio.Contracts.dll to load.
            brokeredServiceContainer.Proffer(ContractsNuGetServices.NuGetProjectServiceV1, factory.CreateNuGetProjectServiceV1);

            // These service descriptor references will cause NuGet.VisualStudio.Internal.Contracts.dll to load.
            brokeredServiceContainer.Proffer(NuGetServices.SourceProviderService, factory.CreateSourceProviderServiceAsync);
            brokeredServiceContainer.Proffer(NuGetServices.SolutionManagerService, factory.CreateSolutionManagerServiceAsync);
            brokeredServiceContainer.Proffer(NuGetServices.ProjectManagerService, factory.CreateProjectManagerServiceAsync);
            brokeredServiceContainer.Proffer(NuGetServices.ProjectUpgraderService, factory.CreateProjectUpgraderServiceAsync);
        }

        private ValueTask<object> CreateSourceProviderServiceAsync(
            ServiceMoniker moniker,
            ServiceActivationOptions options,
            IServiceBroker serviceBroker,
            AuthorizationServiceClient authorizationServiceClient,
            CancellationToken cancellationToken)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new ValueTask<object>(new NuGetSourcesService(options, serviceBroker, authorizationServiceClient));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private async ValueTask<object> CreateSolutionManagerServiceAsync(
            ServiceMoniker moniker,
            ServiceActivationOptions options,
            IServiceBroker serviceBroker,
            AuthorizationServiceClient authorizationServiceClient,
            CancellationToken cancellationToken)
        {
            NuGetSolutionManagerService service = await NuGetSolutionManagerService.CreateAsync(
                options,
                serviceBroker,
                authorizationServiceClient,
                cancellationToken);

            return service;
        }

        private async ValueTask<object> CreateProjectManagerServiceAsync(
            ServiceMoniker moniker,
            ServiceActivationOptions options,
            IServiceBroker serviceBroker,
            AuthorizationServiceClient authorizationServiceClient,
            CancellationToken cancellationToken)
        {
            await _lazyInitializer.InitializeAsync(cancellationToken);

#pragma warning disable CA2000 // Dispose objects before losing scope
            var service = new NuGetProjectManagerService(
                options,
                serviceBroker,
                authorizationServiceClient,
                _projectManagerServiceSharedState,
                _sharedServiceState);
#pragma warning restore CA2000 // Dispose objects before losing scope

            return service;
        }

        private async ValueTask<object> CreateProjectUpgraderServiceAsync(
            ServiceMoniker moniker,
            ServiceActivationOptions options,
            IServiceBroker serviceBroker,
            AuthorizationServiceClient authorizationServiceClient,
            CancellationToken cancellationToken)
        {
            await _lazyInitializer.InitializeAsync(cancellationToken);

#pragma warning disable CA2000 // Dispose objects before losing scope
            var service = new NuGetProjectUpgraderService(
                options,
                serviceBroker,
                authorizationServiceClient,
                _sharedServiceState);
#pragma warning restore CA2000 // Dispose objects before losing scope

            return service;
        }

        private async ValueTask<object> CreateNuGetProjectServiceV1(
            ServiceMoniker moniker,
            ServiceActivationOptions options,
            IServiceBroker serviceBroker,
            CancellationToken cancellationToken)
        {
            await _lazyInitializer.InitializeAsync(cancellationToken);

            IVsSolutionManager solutionManager = await _lazySolutionManager.GetValueAsync(cancellationToken);
            ISettings settings = await _lazySettings.GetValueAsync(cancellationToken);

            return new NuGetProjectService(solutionManager, settings);
        }

        private Task InitializeAsync()
        {
            _lazySettings = new AsyncLazy<ISettings>(ServiceLocator.GetInstanceAsync<ISettings>, ThreadHelper.JoinableTaskFactory);
            _lazySolutionManager = new AsyncLazy<IVsSolutionManager>(ServiceLocator.GetInstanceAsync<IVsSolutionManager>, ThreadHelper.JoinableTaskFactory);
            _projectManagerServiceSharedState = new NuGetProjectManagerServiceState();
            _sharedServiceState = new SharedServiceState();

            return Task.CompletedTask;
        }
    }
}
