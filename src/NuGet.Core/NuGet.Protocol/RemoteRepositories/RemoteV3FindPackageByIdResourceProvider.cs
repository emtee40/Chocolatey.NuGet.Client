// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public class RemoteV3FindPackageByIdResourceProvider : ResourceProvider
    {
        public RemoteV3FindPackageByIdResourceProvider()
            : base(typeof(FindPackageByIdResource),
                nameof(RemoteV3FindPackageByIdResourceProvider),
                before: nameof(RemoteV2FindPackageByIdResourceProvider))
        {
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository sourceRepository, CancellationToken token)
        {
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            return await TryCreate(sourceRepository, cacheContext: null, token);
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository sourceRepository, SourceCacheContext cacheContext, CancellationToken token)
        {
            INuGetResource resource = null;

            var serviceIndexResource = await sourceRepository.GetResourceAsync<ServiceIndexResourceV3>(cacheContext, token);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

            if (serviceIndexResource != null)
            {
                //Repository signature information init
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
                var repositorySignatureResource = await sourceRepository.GetResourceAsync<RepositorySignatureResource>(cacheContext, token);
                repositorySignatureResource?.UpdateRepositorySignatureInfo();
                var httpSourceResource = await sourceRepository.GetResourceAsync<HttpSourceResource>(cacheContext, token);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

                resource = new RemoteV3FindPackageByIdResource(
                    sourceRepository,
                    httpSourceResource.HttpSource);
            }

            return Tuple.Create(resource != null, resource);
        }
    }
}
