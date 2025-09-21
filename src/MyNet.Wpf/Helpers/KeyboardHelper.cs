// -----------------------------------------------------------------------
// <copyright file="KeyboardHelper.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Input;

namespace MyNet.Wpf.Helpers;

public static class KeyboardHelper
{
    public static (bool Ctrl, bool Shift) MetaKeyState => ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control, (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
}
