// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Protocol.Core.Types
{
    public abstract class ListResource : INuGetResource
    {
        public abstract Task<IEnumerableAsync<IPackageSearchMetadata>> ListAsync(
            string searchTerm,
            bool prerelease,
            bool allVersions,
            bool includeDelisted,
            ILogger log,
            CancellationToken token);

        //////////////////////////////////////////////////////////
        // Start - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        public abstract Task<IEnumerableAsync<IPackageSearchMetadata>> ListAsync(
            string searchTerm,
            bool prerelease,
            bool allVersions,
            bool includeDelisted,
            ILogger log,
            SourceCacheContext cacheContext,
            CancellationToken token);

        public abstract Task<IPackageSearchMetadata> PackageAsync(
            string searchTerm,
            bool prerelease,
            ILogger log,
            CancellationToken token);

        public abstract Task<IPackageSearchMetadata> PackageAsync(
            string searchTerm,
            bool prerelease,
            ILogger log,
            SourceCacheContext cacheContext,
            CancellationToken token);

        //////////////////////////////////////////////////////////
        // End - Chocolatey Specific Modification
        //////////////////////////////////////////////////////////

        public abstract string Source { get; }
    }
}
