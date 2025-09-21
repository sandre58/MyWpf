// -----------------------------------------------------------------------
// <copyright file="IClearStrategy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace MyNet.Wpf.Toasting.Lifetime.Clear;

public interface IClearStrategy
{
    IEnumerable<Toast> GetToastsToRemove(IEnumerable<Toast> toasts);
}
