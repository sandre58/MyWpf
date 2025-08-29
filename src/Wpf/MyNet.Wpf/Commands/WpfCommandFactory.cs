// -----------------------------------------------------------------------
// <copyright file="WpfCommandFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Input;
using MyNet.UI.Commands;

namespace MyNet.Wpf.Commands;

public class WpfCommandFactory : ICommandFactory
{
    public ICommand Create(Action execute) => new WpfCommand(execute);

    public ICommand Create(Action execute, Func<bool> canExectute) => new WpfCommand(execute, canExectute);

    public ICommand Create<T>(Action<T?> execute) => new WpfCommand<T>(execute);

    public ICommand Create<T>(Action<T?> execute, Func<T?, bool> canExectute) => new WpfCommand<T>(execute, canExectute);
}
