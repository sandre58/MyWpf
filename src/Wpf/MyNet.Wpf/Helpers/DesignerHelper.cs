// -----------------------------------------------------------------------
// <copyright file="DesignerHelper.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Helpers;

public static class DesignerHelper
{
    private static bool? _isInDesignMode;

    public static bool IsInDesignMode
    {
        get
        {
            if (!_isInDesignMode.HasValue)
            {
                _isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof(FrameworkElement)).Metadata.DefaultValue;
            }

            return _isInDesignMode.Value;
        }
    }
}
