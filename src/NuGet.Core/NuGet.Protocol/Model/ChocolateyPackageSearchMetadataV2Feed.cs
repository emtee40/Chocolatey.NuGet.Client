// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace NuGet.Protocol
{
    public partial class PackageSearchMetadataV2Feed : IPackageSearchMetadata
    {
        public string PackageHash { get; private set; }
        public string PackageHashAlgorithm { get; private set; }
        public long? PackageSize { get; private set; }
        public int? VersionDownloadCount { get; private set; }

        public bool IsApproved { get; private set; }
        public string PackageStatus { get; private set; }
        public string PackageSubmittedStatus { get; private set; }
        public string PackageTestResultStatus { get; private set; }
        public DateTime? PackageTestResultStatusDate { get; private set; }
        public string PackageValidationResultStatus { get; private set; }
        public DateTime? PackageValidationResultDate { get; private set; }
        public DateTime? PackageCleanupResultDate { get; private set; }
        public DateTime? PackageReviewedDate { get; private set; }
        public DateTime? PackageApprovedDate { get; private set; }
        public string PackageReviewer { get; private set; }

        public bool IsDownloadCacheAvailable { get; private set; }
        public DateTime? DownloadCacheDate { get; private set; }

        private string _downloadCacheString;

        public string PackagePath => null;

        public IEnumerable<DownloadCache> DownloadCache
        {
            get
            {
                if (string.IsNullOrEmpty(_downloadCacheString))
                {
                    return Enumerable.Empty<DownloadCache>();
                }

                var cache = new List<DownloadCache>();
                foreach (string downloadString in _downloadCacheString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    if (downloadString.Contains("^"))
                    {
                        var cacheValues = downloadString.Split(new[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                        if (cacheValues.Count() < 3) continue;

                        cache.Add(new DownloadCache
                        {
                            OriginalUrl = cacheValues[0],
                            FileName = cacheValues[1],
                            Checksum = cacheValues[2]
                        });
                    }
                }

                return cache;
            }
        }

        public bool IsLatestVersion { get; private set; }
        public bool IsAbsoluteLatestVersion { get; private set; }
        public bool IsPrerelease { get; private set; }
        public string ReleaseNotes { get; private set; }
        public Uri ProjectSourceUrl { get; private set; }
        public Uri PackageSourceUrl { get; private set; }
        public Uri DocsUrl { get; private set; }
        public Uri MailingListUrl { get; private set; }
        public Uri BugTrackerUrl { get; private set; }
        public string DownloadCacheStatus { get; private set; }
        public string PackageScanStatus { get; private set; }
        public DateTime? PackageScanResultDate { get; private set; }
        public string PackageScanFlagResult { get; private set; }

        private void FinishInitialization(V2FeedPackageInfo package)
        {
            PackageHash = package.PackageHash;
            PackageHashAlgorithm = package.PackageHashAlgorithm;
            PackageSize = package.PackageSize;
            VersionDownloadCount = package.VersionDownloadCount;
            IsApproved = package.IsApproved;
            PackageStatus = package.PackageStatus;
            PackageSubmittedStatus = package.PackageSubmittedStatus;
            PackageTestResultStatus = package.PackageTestResultStatus;
            PackageTestResultStatusDate = package.PackageTestResultStatusDate;
            PackageValidationResultStatus = package.PackageValidationResultStatus;
            PackageValidationResultDate = package.PackageValidationResultDate;
            PackageCleanupResultDate = package.PackageCleanupResultDate;
            PackageReviewedDate = package.PackageReviewedDate;
            PackageApprovedDate = package.PackageApprovedDate;
            PackageReviewer = package.PackageReviewer;
            IsDownloadCacheAvailable = package.IsDownloadCacheAvailable;
            DownloadCacheDate = package.DownloadCacheDate;
            _downloadCacheString = package.DownloadCacheString;
            IsLatestVersion = package.IsLatestVersion;
            IsAbsoluteLatestVersion = package.IsAbsoluteLatestVersion;
            IsPrerelease = package.IsPrerelease;
            ReleaseNotes = package.ReleaseNotes;
            ProjectSourceUrl = GetUriSafe(package.ProjectSourceUrl);
            PackageSourceUrl = GetUriSafe(package.PackageSourceUrl);
            DocsUrl = GetUriSafe(package.DocsUrl);
            MailingListUrl = GetUriSafe(package.MailingListUrl);
            BugTrackerUrl = GetUriSafe(package.BugTrackerUrl);
            DownloadCacheStatus = package.DownloadCacheStatus;
            PackageScanStatus = package.PackageScanStatus;
            PackageScanResultDate = package.PackageScanResultDate;
            PackageScanFlagResult = package.PackageScanFlagResult;
        }
    }
}
