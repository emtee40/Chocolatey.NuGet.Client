// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;

namespace NuGet.Protocol
{
    /// <summary>
    /// A FindPackageByIdResource provider for plugins.
    /// </summary>
    public sealed class PluginFindPackageByIdResourceProvider : ResourceProvider
    {
        /// <summary>
        /// Instantiates a new <see cref="PluginFindPackageByIdResourceProvider" /> class.
        /// </summary>
        public PluginFindPackageByIdResourceProvider()
            : base(typeof(FindPackageByIdResource),
                nameof(PluginFindPackageByIdResourceProvider),
                before: nameof(HttpFileSystemBasedFindPackageByIdResourceProvider))
        {
        }

        /// <summary>
        /// Asynchronously attempts to create a resource for the specified source repository.
        /// </summary>
        /// <param name="source">A source repository.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result (<see cref="Task{TResult}.Result" />) returns a Tuple&lt;bool, INuGetResource&gt;</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="OperationCanceledException">Thrown if <paramref name="cancellationToken"/>
        /// is cancelled.</exception>
        public override async Task<Tuple<bool, INuGetResource>> TryCreate(
            SourceRepository source,
            CancellationToken cancellationToken)
        {
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            return await TryCreate(source, cacheContext: null, cancellationToken);
        }

        /// <summary>
        /// Asynchronously attempts to create a resource for the specified source repository.
        /// </summary>
        /// <param name="source">A source repository.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result (<see cref="Task{TResult}.Result" />) returns a Tuple&lt;bool, INuGetResource&gt;</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="OperationCanceledException">Thrown if <paramref name="cancellationToken"/>
        /// is cancelled.</exception>
        public override async Task<Tuple<bool, INuGetResource>> TryCreate(
            SourceRepository source,
            SourceCacheContext cacheContext,
            CancellationToken cancellationToken)
        {
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            cancellationToken.ThrowIfCancellationRequested();

            PluginFindPackageByIdResource resource = null;

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            var pluginResource = await source.GetResourceAsync<PluginResource>(cacheContext, cancellationToken);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

            if (pluginResource != null)
            {
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
                var serviceIndexResource = await source.GetResourceAsync<ServiceIndexResourceV3>(cacheContext, cancellationToken);
                var httpHandlerResource = await source.GetResourceAsync<HttpHandlerResource>(cacheContext, cancellationToken);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

                if (serviceIndexResource != null && httpHandlerResource != null)
                {
                    var result = await pluginResource.GetPluginAsync(OperationClaim.DownloadPackage, cancellationToken);

                    if (result != null)
                    {
                        AddOrUpdateGetCredentialsRequestHandler(result.Plugin, source, httpHandlerResource);
                        AddOrUpdateGetServiceIndexRequestHandler(result.Plugin, source);

                        resource = new PluginFindPackageByIdResource(
                            result.Plugin,
                            result.PluginMulticlientUtilities,
                            source.PackageSource);
                    }
                }
            }

            return new Tuple<bool, INuGetResource>(resource != null, resource);
        }

        private static void AddOrUpdateGetCredentialsRequestHandler(
            IPlugin plugin,
            SourceRepository source,
            HttpHandlerResource httpHandlerResource)
        {
            plugin.Connection.MessageDispatcher.RequestHandlers.AddOrUpdate(
                MessageMethod.GetCredentials,
                () => new GetCredentialsRequestHandler(
                    plugin,
                    httpHandlerResource.ClientHandler?.Proxy,
                    HttpHandlerResourceV3.CredentialService?.Value),
                existingHandler =>
                    {
                        var handler = (GetCredentialsRequestHandler)existingHandler;

                        handler.AddOrUpdateSourceRepository(source);

                        return handler;
                    });
        }

        private static void AddOrUpdateGetServiceIndexRequestHandler(IPlugin plugin, SourceRepository source)
        {
            plugin.Connection.MessageDispatcher.RequestHandlers.AddOrUpdate(
                MessageMethod.GetServiceIndex,
                () => new GetServiceIndexRequestHandler(plugin),
                existingHandler =>
                    {
                        var handler = (GetServiceIndexRequestHandler)existingHandler;

                        handler.AddOrUpdateSourceRepository(source);

                        return handler;
                    });
        }
    }
}
