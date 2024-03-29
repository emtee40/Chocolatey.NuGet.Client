// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.Versioning;
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using Chocolatey.NuGet.Frameworks;
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////

namespace NuGet.PackageManagement.VisualStudio
{
    public class ScriptPackageFile : IScriptPackageFile
    {
        public ScriptPackageFile(string path, NuGetFramework targetFramework)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (targetFramework == null)
            {
                throw new ArgumentNullException(nameof(targetFramework));
            }

            Path = path.Replace(System.IO.Path.AltDirectorySeparatorChar, System.IO.Path.DirectorySeparatorChar);
            TargetFramework = new FrameworkName(targetFramework.DotNetFrameworkName); ;
        }

        // Path is a public API used by init.ps1/install.ps users.
        public string Path
        {
            get;
            set;
        }

        public FrameworkName TargetFramework
        {
            get;
        }
    }
}
