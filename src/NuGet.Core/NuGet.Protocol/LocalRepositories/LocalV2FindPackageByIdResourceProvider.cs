// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    /// <summary>
    /// A v2-style package repository that has nupkgs at the root.
    /// </summary>
    public class LocalV2FindPackageByIdResourceProvider : ResourceProvider
    {
        public LocalV2FindPackageByIdResourceProvider()
            : base(typeof(FindPackageByIdResource),
                  nameof(LocalV2FindPackageByIdResourceProvider),
                  before: nameof(LocalV3FindPackageByIdResourceProvider))
        {
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository source, CancellationToken token)
        {
        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            return await TryCreate(source, cacheContext: null, token);
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository source, SourceCacheContext cacheContext, CancellationToken token)
        {
            INuGetResource resource = null;

            var feedType = await source.GetFeedType(cacheContext, token);
        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////
            if (feedType == FeedType.FileSystemV2 || feedType == FeedType.FileSystemUnzipped)
            {
                resource = new LocalV2FindPackageByIdResource(source.PackageSource);
            }

            return Tuple.Create(resource != null, resource);
        }
    }
}
