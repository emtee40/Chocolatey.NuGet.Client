// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Linq;

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
namespace Chocolatey.NuGet.Frameworks
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
{
    public static class FrameworkNameHelpers
    {
        public static string GetPortableProfileNumberString(int profileNumber)
        {
            return String.Format(CultureInfo.InvariantCulture, "Profile{0}", profileNumber);
        }

        public static string GetFolderName(string identifierShortName, string versionString, string profileShortName)
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}{3}", identifierShortName, versionString, String.IsNullOrEmpty(profileShortName) ? string.Empty : "-", profileShortName);
        }

        public static string GetVersionString(Version version)
        {
            string versionString = null;

            if (version != null)
            {
                if (version.Major > 9
                    || version.Minor > 9
                    || version.Build > 9
                    || version.Revision > 9)
                {
                    versionString = version.ToString();
                }
                else
                {
                    versionString = version.ToString().Replace(".", "").TrimEnd('0');
                }
            }

            return versionString;
        }

        public static Version GetVersion(string versionString)
        {
            Version version = null;

            if (string.IsNullOrEmpty(versionString))
            {
                version = FrameworkConstants.EmptyVersion;
            }
            else
            {
                if (versionString.IndexOf('.') > -1)
                {
                    // parse the version as a normal dot delimited version
                    _ = Version.TryParse(versionString, out version);
                }
                else
                {
                    // make sure we have at least 2 digits
                    if (versionString.Length < 2)
                    {
                        versionString += "0";
                    }

                    // take only the first 4 digits and add dots
                    // 451 -> 4.5.1
                    // 81233 -> 8123
                    _ = Version.TryParse(string.Join(".", versionString.ToCharArray().Take(4)), out version);
                }
            }

            return version;
        }
    }
}
