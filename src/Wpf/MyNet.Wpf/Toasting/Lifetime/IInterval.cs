// -----------------------------------------------------------------------
// <copyright file="IInterval.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Threading;

namespace MyNet.Wpf.Toasting.Lifetime;

public interface IInterval
{
    bool IsRunning { get; }
    void Invoke(TimeSpan frequency, Action action, Dispatcher dispatcher);
    void Stop();
}
