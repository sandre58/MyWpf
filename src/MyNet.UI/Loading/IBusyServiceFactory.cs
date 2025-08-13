// -----------------------------------------------------------------------
// <copyright file="IBusyServiceFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Loading;

/// <summary>
/// Defines a factory for creating instances of <see cref="IBusyService"/>.
/// Use this to decouple service creation and support dependency injection or custom instantiation logic.
/// </summary>
public interface IBusyServiceFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="IBusyService"/>.
    /// </summary>
    /// <returns>A new <see cref="IBusyService"/> instance.</returns>
    IBusyService Create();
}
