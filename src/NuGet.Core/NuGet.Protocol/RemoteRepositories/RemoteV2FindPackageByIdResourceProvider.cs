// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    /// <summary>
    /// A <see cref="ResourceProvider" /> for <see cref="FindPackageByIdResource" /> over v2 NuGet feeds.
    /// </summary>
    public class RemoteV2FindPackageByIdResourceProvider : ResourceProvider
    {
        public RemoteV2FindPackageByIdResourceProvider()
            : base(typeof(FindPackageByIdResource), name: nameof(RemoteV2FindPackageByIdResourceProvider), before: nameof(LocalV2FindPackageByIdResourceProvider))
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
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            INuGetResource resource = null;

            if (sourceRepository.PackageSource.IsHttp
                &&
                !sourceRepository.PackageSource.Source.EndsWith("json", StringComparison.OrdinalIgnoreCase))
            {
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
                var httpSourceResource = await sourceRepository.GetResourceAsync<HttpSourceResource>(cacheContext, token);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

                resource = new RemoteV2FindPackageByIdResource(
                    sourceRepository.PackageSource,
                    httpSourceResource.HttpSource);
            }

            return Tuple.Create(resource != null, resource);
        }
    }
}
