// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
namespace Chocolatey.NuGet.Frameworks
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
{
    public static class NuGetFrameworkExtensions
    {
        /// <summary>
        /// True if the Framework is .NETFramework
        /// </summary>
        public static bool IsDesktop(this NuGetFramework framework)
        {
            return framework.Framework.Equals(FrameworkConstants.FrameworkIdentifiers.Net, StringComparison.OrdinalIgnoreCase)
                   || framework.Framework.Equals(FrameworkConstants.FrameworkIdentifiers.AspNet, StringComparison.OrdinalIgnoreCase)
                   || framework.Framework.Equals(FrameworkConstants.FrameworkIdentifiers.Dnx, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Return the item with the target framework nearest the project framework
        /// </summary>
        public static T GetNearest<T>(this IEnumerable<T> items, NuGetFramework projectFramework) where T : class, IFrameworkSpecific
        {
            return NuGetFrameworkUtility.GetNearest(items, projectFramework, e => e.TargetFramework);
        }
    }
}
