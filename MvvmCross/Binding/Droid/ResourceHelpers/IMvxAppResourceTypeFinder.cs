﻿// IMvxAppResourceTypeFinder.cs

// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
//
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;

namespace MvvmCross.Binding.Droid.ResourceHelpers
{
    public interface IMvxAppResourceTypeFinder
    {
        Type Find();
    }
}