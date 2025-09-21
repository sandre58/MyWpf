// -----------------------------------------------------------------------
// <copyright file="TransitionAssist.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace MyNet.Wpf.Parameters;

public static class TransitionAssist
{
    public static readonly DependencyProperty DisableTransitionsProperty = DependencyProperty.RegisterAttached(
        "DisableTransitions", typeof(bool), typeof(TransitionAssist), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));

    public static void SetDisableTransitions(DependencyObject element, bool value) => element.SetValue(DisableTransitionsProperty, value);

    public static bool GetDisableTransitions(DependencyObject element) => (bool)element.GetValue(DisableTransitionsProperty);
}
