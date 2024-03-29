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
    /// A keyvalue pair specific to a framework identifier
    /// </summary>
    public class FrameworkSpecificMapping
    {
        private readonly string _frameworkIdentifier;
        private readonly KeyValuePair<string, string> _mapping;

        public FrameworkSpecificMapping(string frameworkIdentifier, string key, string value)
            : this(frameworkIdentifier, new KeyValuePair<string, string>(key, value))
        {
        }

        public FrameworkSpecificMapping(string frameworkIdentifier, KeyValuePair<string, string> mapping)
        {
            _frameworkIdentifier = frameworkIdentifier;
            _mapping = mapping;
        }

        public string FrameworkIdentifier
        {
            get { return _frameworkIdentifier; }
        }

        public KeyValuePair<string, string> Mapping
        {
            get { return _mapping; }
        }
    }
}
