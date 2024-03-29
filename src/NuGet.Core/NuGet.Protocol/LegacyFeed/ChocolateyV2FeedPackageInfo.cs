// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//////////////////////////////////////////////////////////
// Chocolatey Specific Modification
//////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Packaging.Core;
using NuGet.Versioning;

namespace NuGet.Protocol
{
    public partial class V2FeedPackageInfo : PackageIdentity
    {
        private readonly long? _packageSize;
        private readonly int? _versionDownloadCount;
        private readonly bool _isApproved;
        private readonly string _packageStatus;
        private readonly string _packageSubmittedStatus;
        private readonly string _packageTestResultStatus;
        private readonly DateTime? _packageTestResultStatusDate;
        private readonly string _packageValidationResultStatus;
        private readonly DateTime? _packageValidationResultDate;
        private readonly DateTime? _packageCleanupResultDate;
        private readonly DateTime? _packageReviewedDate;
        private readonly DateTime? _packageApprovedDate;
        private readonly string _packageReviewer;
        private readonly bool _isDownloadCacheAvailable;
        private readonly DateTime? _downloadCacheDate;
        private readonly string _downloadCacheString;
        private readonly bool _isLatestVersion;
        private readonly bool _isAbsoluteLatestVersion;
        private readonly bool _isPrerelease;
        private readonly string _releaseNotes;
        private readonly string _projectSourceUrl;
        private readonly string _packageSourceUrl;
        private readonly string _docsUrl;
        private readonly string _mailingListUrl;
        private readonly string _bugTrackerUrl;
        private readonly string _downloadCacheStatus;
        private readonly string _packageScanStatus;
        private readonly DateTime? _packageScanResultDate;
        private readonly string _packageScanFlagResult;

        public V2FeedPackageInfo(PackageIdentity identity, string title, string summary, string description, IEnumerable<string> authors, IEnumerable<string> owners,
            string iconUrl, string licenseUrl, string projectUrl, string reportAbuseUrl, string galleryDetailsUrl,
            string tags, DateTimeOffset? created, DateTimeOffset? lastEdited, DateTimeOffset? published, string dependencies, bool requireLicenseAccept, string downloadUrl,
            string downloadCount, string packageHash, string packageHashAlgorithm, NuGetVersion minClientVersion, long? packageSize, int? versionDownloadCount, bool isApproved,
            string packageStatus, string packageSubmittedStatus, string packageTestResultStatus, DateTime? packageTestResultStatusDate, string packageValidationResultStatus,
            DateTime? packageValidationResultDate, DateTime? packageCleanupResultDate, DateTime? packageReviewedDate, DateTime? packageApprovedDate,
            string packageReviewer, bool isDownloadCacheAvailable, DateTime? downloadCacheDate, string downloadCacheString, bool isLatestVersion, bool isAbsoluteLatestVersion,
            bool isPrerelease, string releaseNotes, string projectSourceUrl, string packageSourceUrl, string docsUrl, string mailingListUrl, string bugTrackerUrl, string downloadCacheStatus,
            string packageScanStatus, DateTime? packageScanResultDate, string packageScanFlagResult)
            : base(identity.Id, identity.Version)
        {
            _summary = summary;
            _description = description;
            _authors = authors == null ? Array.Empty<string>() : authors.ToArray();
            _owners = owners == null ? Array.Empty<string>() : owners.ToArray();
            _iconUrl = iconUrl;
            _licenseUrl = licenseUrl;
            _projectUrl = projectUrl;
            _reportAbuseUrl = reportAbuseUrl;
            _galleryDetailsUrl = galleryDetailsUrl;
            _description = description;
            _summary = summary;
            _tags = tags;
            _dependencies = dependencies;
            _requireLicenseAcceptance = requireLicenseAccept;
            _title = title;
            _downloadUrl = downloadUrl;
            _downloadCount = downloadCount;
            _created = created;
            _lastEdited = lastEdited;
            _published = published;
            _packageHash = packageHash;
            _packageHashAlgorithm = packageHashAlgorithm;
            _minClientVersion = minClientVersion;
            _packageSize = packageSize;
            _versionDownloadCount = versionDownloadCount;
            _isApproved = isApproved;
            _packageStatus = packageStatus;
            _packageSubmittedStatus = packageSubmittedStatus;
            _packageTestResultStatus = packageTestResultStatus;
            _packageTestResultStatusDate = packageTestResultStatusDate;
            _packageValidationResultStatus = packageValidationResultStatus;
            _packageValidationResultDate = packageValidationResultDate;
            _packageCleanupResultDate = packageCleanupResultDate;
            _packageReviewedDate = packageReviewedDate;
            _packageApprovedDate = packageApprovedDate;
            _packageReviewer = packageReviewer;
            _isDownloadCacheAvailable = isDownloadCacheAvailable;
            _downloadCacheDate = downloadCacheDate;
            _downloadCacheString = downloadCacheString;
            _isLatestVersion = isLatestVersion;
            _isAbsoluteLatestVersion = isAbsoluteLatestVersion;
            _isPrerelease = isPrerelease;
            _releaseNotes = releaseNotes;
            _projectSourceUrl = projectSourceUrl;
            _packageSourceUrl = packageSourceUrl;
            _docsUrl = docsUrl;
            _mailingListUrl = mailingListUrl;
            _bugTrackerUrl = bugTrackerUrl;
            _downloadCacheStatus = downloadCacheStatus;
            _packageScanStatus = packageScanStatus;
            _packageScanResultDate = packageScanResultDate;
            _packageScanFlagResult = packageScanFlagResult;
        }

        public long? PackageSize => _packageSize;
        public int? VersionDownloadCount => _versionDownloadCount;
        public bool IsApproved => _isApproved;
        public string PackageStatus => _packageStatus;
        public string PackageSubmittedStatus => _packageSubmittedStatus;
        public string PackageTestResultStatus => _packageTestResultStatus;
        public DateTime? PackageTestResultStatusDate => _packageTestResultStatusDate;
        public string PackageValidationResultStatus => _packageValidationResultStatus;
        public DateTime? PackageValidationResultDate => _packageValidationResultDate;
        public DateTime? PackageCleanupResultDate => _packageCleanupResultDate;
        public DateTime? PackageReviewedDate => _packageReviewedDate;
        public DateTime? PackageApprovedDate => _packageApprovedDate;
        public string PackageReviewer => _packageReviewer;

        public bool IsDownloadCacheAvailable => _isDownloadCacheAvailable;
        public DateTime? DownloadCacheDate => _downloadCacheDate;
        public string DownloadCacheString => _downloadCacheString;
        public bool IsLatestVersion => _isLatestVersion;
        public bool IsAbsoluteLatestVersion => _isAbsoluteLatestVersion;
        public bool IsPrerelease => _isPrerelease;
        public string ReleaseNotes => _releaseNotes;
        public string ProjectSourceUrl => _projectSourceUrl;
        public string PackageSourceUrl => _packageSourceUrl;
        public string DocsUrl => _docsUrl;
        public string MailingListUrl => _mailingListUrl;
        public string BugTrackerUrl => _bugTrackerUrl;
        public string DownloadCacheStatus => _downloadCacheStatus;
        public string PackageScanStatus => _packageScanStatus;
        public DateTime? PackageScanResultDate => _packageScanResultDate;
        public string PackageScanFlagResult => _packageScanFlagResult;
    }
}
