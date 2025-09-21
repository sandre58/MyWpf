// -----------------------------------------------------------------------
// <copyright file="IToastAnimator.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.Wpf.Controls.Toasts;

public interface INotificationAnimator
{
    void Setup();
    void PlayShowAnimation();
    void PlayHideAnimation();
}
