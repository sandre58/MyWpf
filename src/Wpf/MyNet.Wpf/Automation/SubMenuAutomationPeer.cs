// -----------------------------------------------------------------------
// <copyright file="SubMenuAutomationPeer.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.Wpf.Controls;
using System.Windows.Automation.Peers;

namespace MyNet.Wpf.Automation;

public class SubmenuAutomationPeer(Submenu owner) : FrameworkElementAutomationPeer(owner)
{
    [System.Diagnostics.Contracts.Pure]
    protected override string GetClassNameCore() => "Submenu";

    [System.Diagnostics.Contracts.Pure]
    protected override AutomationControlType GetAutomationControlTypeCore() => AutomationControlType.Menu;
}
