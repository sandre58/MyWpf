// -----------------------------------------------------------------------
// <copyright file="BehaviorCollection.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using Microsoft.Xaml.Behaviors;
using PropertyChanged;

namespace MyNet.Wpf.Behaviors;

[DoNotNotify]
public class BehaviorCollection : FreezableCollection<Behavior>
{
    protected override Freezable CreateInstanceCore() => new BehaviorCollection();
}
