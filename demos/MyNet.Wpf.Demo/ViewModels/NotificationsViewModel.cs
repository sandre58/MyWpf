// Copyright (c) Stéphane ANDRE. All Right Reserved.
// See the LICENSE file in the project root for more information.

using System;
using System.Windows.Input;
using MyNet.Observable;
using MyNet.UI.Commands;
using MyNet.UI.Notifications;
using MyNet.UI.Resources;
using MyNet.UI.Toasting.Settings;
using MyNet.UI.ViewModels.Workspace;
using MyNet.Wpf.Demo.Resources;
using MyNet.Wpf.Toasting;

namespace MyNet.Wpf.Demo.ViewModels
{
    internal class NotificationsViewModel : NavigableWorkspaceViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "Disposed at each using.")]
        private ToasterService? _toasterService;

        public bool IsUnique { get; set; }

        public double DurationInSeconds { get; set; } = 3.5;

        public int MaxItems { get; set; } = 50;

        public ToasterPosition Position { get; set; } = ToasterPosition.BottomRight;

        public double Width { get; set; } = 300;

        public double OffsetY { get; set; } = 10;

        public double OffsetX { get; set; } = 10;

        public ICommand ShowSuccessCommand { get; set; }

        public ICommand ShowErrorCommand { get; set; }

        public ICommand ShowWarningCommand { get; set; }

        public ICommand ShowInformationCommand { get; set; }

        public ICommand ShowNoneCommand { get; set; }

        public ICommand ShowCustomCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public ICommand ApplySettingsCommand { get; set; }

        public NotificationsViewModel()
        {
            ResetToasterService();

            ShowSuccessCommand = CommandsManager.Create(() => _toasterService?.Show(new MessageNotification("You have win world cup !", UiResources.Success, NotificationSeverity.Success), SettingsFromSeverity(ToastClosingStrategy.AutoClose), IsUnique));

            ShowErrorCommand = CommandsManager.Create(() => _toasterService?.Show(new MessageNotification("You have an error. Click on me for more information.", UiResources.Error, NotificationSeverity.Error), SettingsFromSeverity(ToastClosingStrategy.CloseButton), IsUnique, x => _toasterService?.Show(new MessageNotification("You are click on error.", UiResources.Information, NotificationSeverity.Information), SettingsFromSeverity(ToastClosingStrategy.AutoClose), IsUnique)));

            ShowWarningCommand = CommandsManager.Create(() => _toasterService?.Show(new MessageNotification("You have a warning. Click on me for more information.", UiResources.Warning, NotificationSeverity.Warning), SettingsFromSeverity(ToastClosingStrategy.Both), IsUnique, x => _toasterService?.Show(new MessageNotification("You are click on error.", UiResources.Information, NotificationSeverity.Information), SettingsFromSeverity(ToastClosingStrategy.AutoClose), IsUnique)));

            ShowInformationCommand = CommandsManager.Create(() => _toasterService?.Show(new MessageNotification("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.t has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", UiResources.Information, NotificationSeverity.Information), SettingsFromSeverity(ToastClosingStrategy.AutoClose), IsUnique));

            ShowNoneCommand = CommandsManager.Create(() => _toasterService?.Show(new MessageNotification("It's a standard message.", "Header", NotificationSeverity.None), ToastSettings.Default, IsUnique));

            ApplySettingsCommand = CommandsManager.Create(() =>
            {
                ResetToasterService();

                _toasterService?.Show(new MessageNotification(DemoResources.SettingsHaveBeenSaved, UiResources.Success, NotificationSeverity.Success), SettingsFromSeverity(ToastClosingStrategy.AutoClose));
            });

            ShowCustomCommand = CommandsManager.Create(() => _toasterService?.Show(new CustomNotification(), ToastSettings.Default, IsUnique));

            ClearCommand = CommandsManager.Create(() => _toasterService?.Clear());
        }

        private void ResetToasterService()
        {
            (_toasterService as IDisposable)?.Dispose();
            _toasterService = new ToasterService(new ToasterSettings()
            {
                Duration = TimeSpan.FromSeconds(DurationInSeconds),
                MaxItems = MaxItems,
                OffsetX = OffsetX,
                OffsetY = OffsetY,
                Position = Position,
                Width = Width,
            });
        }

        public static ToastSettings SettingsFromSeverity(ToastClosingStrategy toastClosingStrategy)
        {
            var settings = new ToastSettings() { ClosingStrategy = toastClosingStrategy };

            return settings;
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            _toasterService?.Dispose();
        }
    }

    internal class CustomNotification : LocalizableObject, INotification
    {
        public Guid Id => Guid.NewGuid();

        public NotificationSeverity Severity => NotificationSeverity.Information;

        public bool IsSimilar(object obj) => throw new NotImplementedException();
    }
}
