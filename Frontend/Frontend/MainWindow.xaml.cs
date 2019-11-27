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
            this.DataContext = new RootPageViewModel();
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }
    }
}
