// -----------------------------------------------------------------------
// <copyright file="ClearByNotification.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using MyNet.UI.Notifications;

namespace MyNet.Wpf.Toasting.Lifetime.Clear;

public class ClearByNotification(INotification notification) : IClearStrategy
{
    private readonly INotification _notification = notification;

    public IEnumerable<Toast> GetToastsToRemove(IEnumerable<Toast> toasts)
    {
        var notificationsToRemove = toasts
            .Where(x => x.Notification.Equals(_notification))
            .ToList();

        return notificationsToRemove;
    }
}
