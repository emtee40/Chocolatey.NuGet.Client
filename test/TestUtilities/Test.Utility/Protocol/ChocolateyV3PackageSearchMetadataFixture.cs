// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using NuGet.Protocol.Core.Types;

namespace NuGet.Test.Utility
{
    public partial class V3PackageSearchMetadataFixture : IDisposable
    {
        public partial class MockPackageSearchMetadata : IPackageSearchMetadata
        {
            public string PackageHash => null;
            public string PackageHashAlgorithm => null;
            public long? PackageSize => null;
            public int? VersionDownloadCount => null;

            public bool IsApproved => false;
            public string PackageStatus => null;
            public string PackageSubmittedStatus => null;
            public string PackageTestResultStatus => null;
            public DateTime? PackageTestResultStatusDate => null;
            public string PackageValidationResultStatus => null;
            public DateTime? PackageValidationResultDate => null;
            public DateTime? PackageCleanupResultDate => null;
            public DateTime? PackageReviewedDate => null;
            public DateTime? PackageApprovedDate => null;
            public string PackageReviewer => null;

            public bool IsDownloadCacheAvailable => false;
            public DateTime? DownloadCacheDate => null;
            public IEnumerable<DownloadCache> DownloadCache => null;
            public string ReleaseNotes => null;
            public Uri ProjectSourceUrl => null;
            public Uri PackageSourceUrl => null;
            public Uri DocsUrl => null;
            public Uri MailingListUrl => null;
            public Uri BugTrackerUrl => null;
            public string DownloadCacheStatus => null;
            public string PackageScanStatus => null;
            public DateTime? PackageScanResultDate => null;
            public string PackageScanFlagResult => null;
        }
    }
}
