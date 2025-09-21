// -----------------------------------------------------------------------
// <copyright file="SlideTransition.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MyNet.Wpf.Animations;

public class SlideTransition : Transition
{
    #region Direction

    public static readonly DependencyProperty DirectionProperty =
        DependencyProperty.Register(
            "Direction",
            typeof(TransitionSlideDirection),
            typeof(SlideTransition),
            new PropertyMetadata(null));

    public TransitionSlideDirection Direction
    {
        get => (TransitionSlideDirection)GetValue(DirectionProperty);
        set => SetValue(DirectionProperty, value);
    }

    #endregion NavigationTransitionInfo
    public override void Begin(FrameworkElement frameworkElement)
    {
        var translateDoubleAnimation = new DoubleAnimation
        {
            Duration = Duration,
            DecelerationRatio = DecelerationRatio,
            From = Direction is TransitionSlideDirection.Left or TransitionSlideDirection.Bottom ? -50
            : 30,
            To = 0
        };

        if (frameworkElement.RenderTransform is not TranslateTransform)
            frameworkElement.RenderTransform = new TranslateTransform(0, 0);

        if (!frameworkElement.RenderTransformOrigin.Equals(new Point(0.5, 0.5)))
            frameworkElement.RenderTransformOrigin = new Point(0.5, 0.5);

        frameworkElement.RenderTransform.BeginAnimation(Direction is TransitionSlideDirection.Top or TransitionSlideDirection.Bottom ? TranslateTransform.YProperty : TranslateTransform.XProperty, translateDoubleAnimation);
    }
}
