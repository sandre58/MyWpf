// -----------------------------------------------------------------------
// <copyright file="IToastLifetimeSupervisor.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.Wpf.Toasting.Lifetime.Clear;

namespace MyNet.Wpf.Toasting.Lifetime;

public interface IToastLifetimeSupervisor : IDisposable
{
    void PushToast(Toast toast);

    void CloseToast(Toast toast);

    event EventHandler<ShowToastEventArgs>? ShowToastRequested;
    event EventHandler<CloseToastEventArgs>? CloseToastRequested;

    void ClearMessages(IClearStrategy clearStrategy);
}
