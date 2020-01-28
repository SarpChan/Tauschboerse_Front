using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class SharingServicePage : Page
    {
        public SharingServicePage()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void OpenDialog(object sender, RoutedEventArgs args)
        {
            SO_Dialog d = new SO_Dialog();
            d.Show();
            d.Topmost = true;
        }
    }
}
