// -----------------------------------------------------------------------
// <copyright file="Interval.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Threading;

namespace MyNet.Wpf.Toasting.Lifetime;

public class Interval : IInterval
{
    private DispatcherTimer? _timer;

    public bool IsRunning => _timer is { IsEnabled: true };

    public void Invoke(TimeSpan frequency, Action action, Dispatcher dispatcher)
    {
        _timer = new DispatcherTimer(frequency, DispatcherPriority.Normal, (sender, args) => action(), dispatcher);
        _timer.Start();
    }

    public void Stop()
    {
        _timer?.Stop();
        _timer = null;
    }
}
