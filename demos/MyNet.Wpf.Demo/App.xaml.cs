// Copyright (c) Stéphane ANDRE. All Right Reserved.
// See the LICENSE file in the project root for more information.

using System.IO;
using System.Reactive.Concurrency;
using System.Reflection;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyNet.UI.Commands;
using MyNet.UI.Dialogs;
using MyNet.UI.Dialogs.ContentDialogs;
using MyNet.UI.Dialogs.FileDialogs;
using MyNet.UI.Dialogs.MessageBox;
using MyNet.UI.Loading;
using MyNet.UI.Locators;
using MyNet.UI.Navigation;
using MyNet.UI.Theming;
using MyNet.UI.Toasting;
using MyNet.Utilities.Logging.NLog;
using MyNet.Wpf.Busy;
using MyNet.Wpf.Commands;
using MyNet.Wpf.Demo.Services;
using MyNet.Wpf.Demo.ViewModels;
using MyNet.Wpf.Dialogs;
using MyNet.Wpf.Schedulers;
using MyNet.Wpf.Theming;
using MyNet.Wpf.Toasting;
using ShowMeTheXAML;

namespace MyNet.Wpf.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost Host = Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, configurationBuilder) => configurationBuilder.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!)
                                                                                              .AddJsonFile("config/appsettings.json", optional: false, reloadOnChange: true))
            .ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();

                Logger.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/config/NLog.config"));
                logging.AddProvider(new LoggerProvider());
            })
            .ConfigureServices((context, services) => services

            // App Host
            .AddHostedService<ApplicationHostService>()

            // Services
            .AddSingleton<Utilities.Logging.ILogger, Logger>()
            .AddSingleton<IViewModelResolver, ViewModelResolver>()
            .AddSingleton<IViewModelLocator, ViewModelLocator>(x => new ViewModelLocator(x))
            .AddSingleton<IViewLocator, ViewLocator>()
            .AddSingleton<IViewResolver, ViewResolver>()
            .AddSingleton<IThemeService, ThemeService>()
            .AddSingleton<INavigationService, NavigationService>()
            .AddSingleton<IToasterService, ToasterService>()
            .AddSingleton<IContentDialogService, OverlayDialogService>()
            .AddSingleton<IMessageBoxService, OverlayDialogService>()
            .AddSingleton<IFileDialogService, FileDialogService>()
            .AddScoped<IBusyServiceFactory, BusyServiceFactory>()
            .AddSingleton<IDialogService, DialogService>()
            .AddScoped<IMessageBoxFactory, MessageBoxFactory>()
            .AddScoped<IScheduler, WpfScheduler>(_ => WpfScheduler.Current)
            .AddScoped<ICommandFactory, WpfCommandFactory>()

            // ViewModels
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<HomeViewModel>()
            .AddSingleton<ProgressLoadingIndicatorsViewModel>()

            // Configuration
            .Configure<AppConfiguration>(context.Configuration)

            ).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            XamlDisplay.Init();

            base.OnStartup(e);

            await Host.StartAsync().ConfigureAwait(false);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            await Host.StopAsync().ConfigureAwait(false);

            Host.Dispose();
        }
    }
}
