// Copyright (c) 2022-Present Chocolatey Software, Inc.
// Copyright (c) 2015-2022 .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using NuGet.Shared;

#if IS_NET40_CLIENT
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using FallbackList = System.Collections.Generic.IList<Chocolatey.NuGet.Frameworks.NuGetFramework>;
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
#else
//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
using FallbackList = System.Collections.Generic.IReadOnlyList<Chocolatey.NuGet.Frameworks.NuGetFramework>;
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
#endif

//////////////////////////////////////////////////////////
// Start - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
namespace Chocolatey.NuGet.Frameworks
//////////////////////////////////////////////////////////
// End - Chocolatey Specific Modification
//////////////////////////////////////////////////////////
{
    public class FallbackFramework : NuGetFramework, IEquatable<FallbackFramework>
    {
        /// <summary>
        /// List framework to fall back to.
        /// </summary>
        public FallbackList Fallback
        {
            get { return _fallback; }
        }

        private readonly FallbackList _fallback;
        private int? _hashCode;

        public FallbackFramework(NuGetFramework framework, FallbackList fallbackFrameworks)
            : base(framework)
        {
            if (framework == null)
            {
                throw new ArgumentNullException(nameof(framework));
            }

            if (fallbackFrameworks == null)
            {
                throw new ArgumentNullException(nameof(fallbackFrameworks));
            }

            if (fallbackFrameworks.Count == 0)
            {
                throw new ArgumentException("Empty fallbackFrameworks is invalid", nameof(fallbackFrameworks));
            }

            _fallback = fallbackFrameworks;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FallbackFramework);
        }

        public override int GetHashCode()
        {
            if (_hashCode == null)
            {
                var combiner = new HashCodeCombiner();

                combiner.AddObject(Comparer.GetHashCode(this));

                foreach (var each in Fallback)
                {
                    combiner.AddObject(Comparer.GetHashCode(each));
                }

                _hashCode = combiner.CombinedHash;
            }

            return _hashCode.Value;
        }

        public bool Equals(FallbackFramework other)
        {
            if (other == null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return NuGetFramework.Comparer.Equals(this, other)
                && Fallback.SequenceEqual(other.Fallback);
        }
    }
}
