using System;
using System.Windows;
using System.Windows.Navigation;

namespace Frontend
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            //this.DataContext = new RootPageViewModel(); //TODO: MW Ohne das ging nix beim testen
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
