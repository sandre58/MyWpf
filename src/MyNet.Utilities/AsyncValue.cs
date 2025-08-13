// -----------------------------------------------------------------------
// <copyright file="AsyncValue.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Utilities;

public class AsyncValue<T>(Func<T> provideValue)
{
    public T Value { get => field ??= provideValue(); private set; } = default!;
}
