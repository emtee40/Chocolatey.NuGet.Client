// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
namespace Chocolatey.NuGet.Frameworks
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
{
    public interface IFrameworkCompatibilityListProvider
    {
        /// <summary>
        /// Get a list of frameworks supporting the provided framework. This list
        /// is not meant to be exhaustive but is instead meant to be human-readable.
        /// Ex: netstandard1.5 -> netstandardapp1.5, net462, dnxcore50, ...
        /// </summary>
        IEnumerable<NuGetFramework> GetFrameworksSupporting(NuGetFramework target);
    }
}
