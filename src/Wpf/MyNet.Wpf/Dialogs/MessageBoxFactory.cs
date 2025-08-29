// -----------------------------------------------------------------------
// <copyright file="MessageBoxFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.UI.Dialogs.MessageBox;

namespace MyNet.Wpf.Dialogs;

public class MessageBoxFactory : IMessageBoxFactory
{
    public IMessageBox Create(string message,
                              string? title,
                              MessageSeverity severity,
                              MessageBoxResultOption buttons,
                              MessageBoxResult defaultResut)
        => new MessageBoxViewModel(message, title, severity, buttons, defaultResut);
}
