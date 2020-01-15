using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;

namespace Frontend
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
         /*
         * Notifier fuer die Toast-Benachrichtigungen
         */
        public static Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: App.Current.MainWindow,
                corner: Corner.BottomCenter,
                offsetX: 10,
                offsetY: 10);
            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2), // Leben 2 Sekunden
                maximumNotificationCount: MaximumNotificationCount.FromCount(3)); // Maximal 3 auf einmal
            cfg.DisplayOptions.Width = 750;
            cfg.Dispatcher = App.Current.Dispatcher;
        });

        public static Notifier notifierSO = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: App.Current.MainWindow,
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);
            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(2), // Leben 2 Sekunden
                maximumNotificationCount: MaximumNotificationCount.FromCount(3)); // Maximal 3 auf einmal
            cfg.DisplayOptions.Width = 300;
            cfg.Dispatcher = App.Current.Dispatcher;
        });
    }
}
