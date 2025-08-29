// -----------------------------------------------------------------------
// <copyright file="IClosable.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MyNet.UI;

/// <summary>
/// Defines the contract for an object that can be closed, including close event and logic.
/// </summary>
public interface IClosable
{
    /// <summary>
    /// Occurs when a request to close the object is made.
    /// </summary>
    event EventHandler<CancelEventArgs> CloseRequest;

    /// <summary>
    /// Determines asynchronously whether the object can be closed.
    /// </summary>
    /// <returns>A task that returns true if the object can be closed; otherwise, false.</returns>
    Task<bool> CanCloseAsync();

    /// <summary>
    /// Closes the object and raises the <see cref="CloseRequest"/> event.
    /// </summary>
    void Close();
}
