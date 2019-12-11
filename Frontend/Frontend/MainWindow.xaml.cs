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
            //DataContext = new TimetableViewModel();
            InitializeComponent();
            this.ShowsNavigationUI = false;
        }
    }
}
