// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using Chocolatey.NuGet.Frameworks;
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using NuGet.Test.Utility;
using Xunit;

namespace NuGet.CommandLine.Test
{
    public class InstallCommandProjectTests
    {
        [Fact]
        public async Task GetFolderPackagesAsync_WithCancellationToken_ThrowsAsync()
        {
            using (var testDir = TestDirectory.Create())
            {
                var cmd = new InstallCommandProject(
                    testDir.Path,
                    new Packaging.PackagePathResolver(testDir.Path, true),
                    NuGetFramework.AnyFramework);
                var cts = new CancellationTokenSource();

                await Assert.ThrowsAsync<OperationCanceledException>(async () =>
                {
                    cts.Cancel();
                    await cmd.GetFolderPackagesAsync(cts.Token);
                });
            }
        }
    }
}
