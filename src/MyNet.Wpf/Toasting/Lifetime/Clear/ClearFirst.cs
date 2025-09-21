// -----------------------------------------------------------------------
// <copyright file="ClearFirst.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace MyNet.Wpf.Toasting.Lifetime.Clear;

public class ClearFirst : IClearStrategy
{
    public IEnumerable<Toast> GetToastsToRemove(IEnumerable<Toast> toasts)
    {
        if (!toasts.Any())
        {
            return [];
        }

        var lastMessage = toasts.First();

        return [lastMessage];
    }
}
