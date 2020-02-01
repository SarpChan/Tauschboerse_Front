using Frontend.View.Windows;
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
            CreateSwapOffer_Dialog d= new CreateSwapOffer_Dialog();
            d.Show();
            d.Topmost = true;
        }
    }
}
