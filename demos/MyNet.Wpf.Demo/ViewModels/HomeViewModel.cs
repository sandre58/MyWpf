// Copyright (c) Stéphane ANDRE. All Right Reserved.
// See the LICENSE file in the project root for more information.

using MyNet.Wpf.Demo.Resources;
using MyNet.UI.ViewModels.Workspace;

namespace MyNet.Wpf.Demo.ViewModels
{
    internal class HomeViewModel : NavigableWorkspaceViewModel
    {
        protected override string CreateTitle() => DemoResources.Home;
    }
}
