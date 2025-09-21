﻿// -----------------------------------------------------------------------
// <copyright file="ShowToastEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Wpf.Toasting.Lifetime;

public class ShowToastEventArgs(Toast toast) : EventArgs
{
    public Toast Toast { get; } = toast;
}
