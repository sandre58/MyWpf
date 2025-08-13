// -----------------------------------------------------------------------
// <copyright file="IBusyService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using MyNet.UI.Loading.Models;

namespace MyNet.UI.Loading;

/// <summary>
/// Defines a service for managing busy states in the UI, allowing asynchronous and synchronous operations to signal when the application is busy and when it resumes normal operation.
/// <para>
/// Progress reporting and cancellation can be managed via the <c>TBusy</c> parameter, which should implement <see cref="IBusy"/>. For example, use <c>ProgressionBusy</c> for progress and cancellation support.
/// </para>
/// </summary>
public interface IBusyService : INotifyPropertyChanged
{
    /// <summary>
    /// Executes an action while the UI is marked as busy, using a busy indicator of type <typeparamref name="TBusy"/>.
    /// <para>
    /// The <typeparamref name="TBusy"/> instance can be used to report progress and handle cancellation if it supports these features.
    /// </para>
    /// </summary>
    /// <typeparam name="TBusy">The type of busy indicator to use. Can be <c>IndeterminateBusy</c>, <c>ProgressionBusy</c>, etc.</typeparam>
    /// <param name="action">The action to execute while busy. Use the <typeparamref name="TBusy"/> parameter to manage progress and cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task WaitAsync<TBusy>(Action<TBusy> action)
        where TBusy : class, IBusy, new();

    /// <summary>
    /// Executes an asynchronous action while the UI is marked as busy, using a busy indicator of type <typeparamref name="TBusy"/>.
    /// <para>
    /// The <typeparamref name="TBusy"/> instance can be used to report progress and handle cancellation if it supports these features.
    /// </para>
    /// </summary>
    /// <typeparam name="TBusy">The type of busy indicator to use. Can be <c>IndeterminateBusy</c>, <c>ProgressionBusy</c>, etc.</typeparam>
    /// <param name="action">The asynchronous action to execute while busy. Use the <typeparamref name="TBusy"/> parameter to manage progress and cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task WaitAsync<TBusy>(Func<TBusy, Task> action)
        where TBusy : class, IBusy, new();

    /// <summary>
    /// Instantiates and returns a busy indicator of type <typeparamref name="TBusy"/> and marks the UI as busy.
    /// <para>
    /// The returned <typeparamref name="TBusy"/> instance can be used to report progress and handle cancellation if it supports these features.
    /// </para>
    /// </summary>
    /// <typeparam name="TBusy">The type of busy indicator to create. Can be <c>IndeterminateBusy</c>, <c>ProgressionBusy</c>, etc.</typeparam>
    /// <returns>The created busy indicator.</returns>
    TBusy Wait<TBusy>()
        where TBusy : class, IBusy, new();

    /// <summary>
    /// Signals that the busy state should end and resumes normal UI operation.
    /// </summary>
    void Resume();

    /// <summary>
    /// Gets the current busy indicator of type <typeparamref name="TBusy"/>, if any.
    /// <para>
    /// The returned <typeparamref name="TBusy"/> instance can be used to report progress and handle cancellation if it supports these features.
    /// </para>
    /// </summary>
    /// <typeparam name="TBusy">The type of busy indicator to retrieve.</typeparam>
    /// <returns>The current busy indicator, or <c>null</c> if not busy.</returns>
    TBusy? GetCurrent<TBusy>()
        where TBusy : class, IBusy;

    /// <summary>
    /// Gets a value indicating whether the UI is currently busy.
    /// </summary>
    bool IsBusy { get; }
}
