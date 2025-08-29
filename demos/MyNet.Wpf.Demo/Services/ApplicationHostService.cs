// Copyright (c) Stéphane ANDRE. All Right Reserved.
// See the LICENSE file in the project root for more information.

using System;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using MyNet.Humanizer;
using MyNet.UI.Commands;
using MyNet.UI.Dialogs;
using MyNet.UI.Dialogs.CustomDialogs;
using MyNet.UI.Dialogs.FileDialogs;
using MyNet.UI.Dialogs.MessageBox;
using MyNet.UI.Loading;
using MyNet.UI.Locators;
using MyNet.UI.Navigation;
using MyNet.UI.Theming;
using MyNet.UI.Toasting;
using MyNet.Utilities.Geography.Extensions;
using MyNet.Utilities.Localization;
using MyNet.Utilities.Logging;
using MyNet.Wpf.Demo.Properties;
using MyNet.Wpf.Demo.Resources;
using MyNet.Wpf.Demo.ViewModels;
using MyNet.Wpf.Demo.Views;

namespace MyNet.Wpf.Demo.Services;

/// <summary>
/// Managed host of the application.
/// </summary>
public class ApplicationHostService : IHostedService
{
    public ApplicationHostService(
        IThemeService themeService,
        INavigationService navigationService,
        IToasterService toasterService,
        ICustomDialogService dialogService,
        IMessageBoxService messageBoxService,
        IFileDialogService fileDialogService,
        IViewModelResolver viewModelResolver,
        IViewModelLocator viewModelLocator,
        IViewResolver viewResolver,
        IViewLocator viewLocator,
        IBusyServiceFactory busyServiceFactory,
        IMessageBoxFactory messageBoxFactory,
        ICommandFactory commandFactory,
        IScheduler uiScheduler,
        ILogger logger)
    {
        LogManager.Initialize(logger);
        ViewModelManager.Initialize(viewModelResolver, viewModelLocator);
        ViewManager.Initialize(viewResolver, viewLocator);
        ThemeManager.Initialize(themeService);
        NavigationManager.Initialize(navigationService, viewModelLocator);
        ToasterManager.Initialize(toasterService);
        DialogManager.Initialize(dialogService, messageBoxService, fileDialogService, messageBoxFactory, viewResolver, viewLocator, viewModelLocator);
        WindowDialogManager.Initialize(messageBoxFactory, viewResolver, viewLocator, viewModelLocator);
        BusyManager.Initialize(busyServiceFactory);
        CommandsManager.Initialize(commandFactory);
        UI.Threading.Scheduler.Initialize(uiScheduler);

        TranslationService.RegisterResources(nameof(CountryResources), CountryResources.ResourceManager);
        TranslationService.RegisterResources(nameof(DemoResources), DemoResources.ResourceManager);
    }

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);

        InitializeAplication();

        var window = new MainWindow();
        Application.Current.MainWindow = window;
        window.Closed += OnWindowsClosed;
        window.Show();

        await Task.CompletedTask.ConfigureAwait(false);

        NavigationManager.NavigateTo<HomeViewModel>();
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public async Task StopAsync(CancellationToken cancellationToken) => await Task.CompletedTask.ConfigureAwait(false);

    private static void InitializeAplication()
    {
        if (!string.IsNullOrEmpty(Settings.Default.Language))
            GlobalizationService.Current.SetCulture(Settings.Default.Language);

        if (!string.IsNullOrEmpty(Settings.Default.TimeZone))
            GlobalizationService.Current.SetTimeZone(TimeZoneInfo.FindSystemTimeZoneById(Settings.Default.TimeZone));

        ThemeManager.ApplyTheme(new Theme
        {
            Base = Settings.Default.ThemeBase.DehumanizeTo<ThemeBase>(),
            PrimaryColor = Settings.Default.ThemePrimaryColor,
            AccentColor = Settings.Default.ThemeAccentColor
        });
    }

    private void OnWindowsClosed(object? sender, EventArgs e) => Application.Current.Shutdown();
}
