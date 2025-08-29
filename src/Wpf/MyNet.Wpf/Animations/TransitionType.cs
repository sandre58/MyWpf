// -----------------------------------------------------------------------
// <copyright file="TransitionType.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Wpf.Animations;

/// <summary>
/// Available types of transitions.
/// </summary>
public enum TransitionType
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Change opacity.
    /// </summary>
    FadeIn,

    FadeInWithSlide,

    /// <summary>
    /// Slide from bottom.
    /// </summary>
    SlideBottom,

    /// <summary>
    /// Slide to top.
    /// </summary>
    SlideTop,

    /// <summary>
    /// Slide to the right side.
    /// </summary>
    SlideRight,

    /// <summary>
    /// Slide to the left side.
    /// </summary>
    SlideLeft
}
