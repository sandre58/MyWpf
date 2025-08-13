// -----------------------------------------------------------------------
// <copyright file="Scheduler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reactive.Concurrency;

namespace MyNet.UI.Threading;

/// <summary>
/// Provides static access to schedulers for background and UI thread operations.
/// </summary>
public static class Scheduler
{
    private static IScheduler? _ui;

    /// <summary>
    /// Gets the scheduler for background operations.
    /// </summary>
    public static IScheduler Background => DefaultScheduler.Instance;

    /// <summary>
    /// Gets the scheduler for UI thread operations. Throws if not initialized.
    /// </summary>
    public static IScheduler Ui => _ui ?? throw new InvalidOperationException("UI thread has not been initialized");

    /// <summary>
    /// Gets the UI scheduler if initialized, otherwise returns the background scheduler.
    /// </summary>
    public static IScheduler UiOrCurrent => _ui ?? Background;

    /// <summary>
    /// Initializes the UI scheduler.
    /// </summary>
    /// <param name="uiScheduler">The scheduler to use for UI thread operations.</param>
    public static void Initialize(IScheduler? uiScheduler) => _ui = uiScheduler;
}
