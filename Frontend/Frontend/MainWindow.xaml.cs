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
            this.DataContext = new MainViewModel(); //TODO: verifizieren wie genau DataContext funktioniert
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }
    }
}
