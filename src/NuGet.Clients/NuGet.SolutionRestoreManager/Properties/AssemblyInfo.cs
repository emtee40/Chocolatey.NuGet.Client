// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NuGet.SolutionRestoreManager")]
[assembly: AssemblyDescription("NuGet Solution Restore Manager")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("06662133-1292-4918-90f3-36c930c0b16f")]

[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Lucene.Net.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Newtonsoft.Json.dll")]
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Commands.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Common.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Configuration.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Credentials.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.DependencyResolver.Core.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Frameworks.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Indexing.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.LibraryModel.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.PackageManagement.dll")]
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\NuGet.PackageManagement.VisualStudio.dll")]
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Packaging.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.ProjectModel.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Protocol.dll")]
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Resolver.dll")]
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\NuGet.SolutionRestoreManager.dll")]
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.Versioning.dll")]
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\NuGet.VisualStudio.Common.dll")]
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.VisualStudio.dll")]
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideCodeBase(CodeBase = @"$PackageFolder$\NuGet.VisualStudio.Internal.Contracts.dll")]

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
[assembly: ProvideBindingRedirection(CodeBase = @"$PackageFolder$\Chocolatey.NuGet.VisualStudio.dll", OldVersionLowerBound = "0.0.0.0")]

[assembly: InternalsVisibleTo("NuGet.SolutionRestoreManager.Test, PublicKey=00240000048000009400000006020000002400005253413100040000010001003f70732af6adf3f525d983852cc7049878c498e4f8a413bd7685c9edc503ed6c6e4087354c7c1797b7c9f6d9bd3c25cdd5f97b0e810b7dd1aaba2e489f60d17d1f03c0f4db27c63146ee64ce797e4c92d591a750d8c342f5b67775710f6f9b3d9d10b4121522779a1ff72776bcce3962ca66f1755919972fb70ffb289bc082b3")]

//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
