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
    /// <summary>
    /// Sorts frameworks according to the framework mappings
    /// </summary>
    public class FrameworkPrecedenceSorter : IComparer<NuGetFramework>
    {
        private readonly IFrameworkNameProvider _mappings;
        private readonly bool _allEquivalent;

        public FrameworkPrecedenceSorter(IFrameworkNameProvider mappings, bool allEquivalent)
        {
            _mappings = mappings;
            _allEquivalent = allEquivalent;
        }

        public int Compare(NuGetFramework x, NuGetFramework y)
        {
            return _allEquivalent ? _mappings.CompareEquivalentFrameworks(x, y) : _mappings.CompareFrameworks(x, y);
        }
    }
}
