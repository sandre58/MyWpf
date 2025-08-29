// -----------------------------------------------------------------------
// <copyright file="MessageBoxViewModel.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;
using MyNet.Observable;
using MyNet.UI.Dialogs.MessageBox;

namespace MyNet.Wpf.Dialogs;

public class MessageBoxViewModel : LocalizableObject, IMessageBox
{
    #region Members

    /// <summary>
    /// Gets or sets message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="MessageSeverity"/> value that specifies the icon to
    /// display. Default value is <see cref="MessageSeverity.Information"/>.
    /// </summary>
    public MessageSeverity Severity { get; set; }

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string? Title { get; set; }

    public MessageBoxResultOption Buttons { get; set; }

    public MessageBoxResult DefaultResult { get; set; }

    #endregion Members

    #region Constructors

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Used by Fody")]
    public MessageBoxViewModel(string message,
                               string? title = null,
                               MessageSeverity severity = MessageSeverity.Information,
                               MessageBoxResultOption buttons = MessageBoxResultOption.OkCancel,
                               MessageBoxResult defaultResult = MessageBoxResult.Ok)
    {
        Message = message;
        Title = title;
        Severity = severity;
        Buttons = buttons;
        DefaultResult = defaultResult;
    }

    #endregion

    public override bool Equals(object? obj) => obj is MessageBoxViewModel other && Equals(Message, other.Message);

    public override int GetHashCode() => Message?.GetHashCode(System.StringComparison.InvariantCultureIgnoreCase) ?? RuntimeHelpers.GetHashCode(this);

    public override string? ToString() => Message;
}
