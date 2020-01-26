using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for SO_Dialog.xaml
    /// </summary>
    public partial class SO_Dialog : Window
    {

        public long GroupID;
        public long ToGroupID=40;
        public SO_Dialog()
        {
            InitializeComponent();
        }

        private void CloWi(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        public void Create(object sender, RoutedEventArgs e)
        {
            CreateSwapOfferAsync();
            CloWi(sender, e);
        }
        private async void CreateSwapOfferAsync()
        {

            Console.WriteLine("create");
           
           
            SwapOffer so = new SwapOffer(GroupID, ToGroupID);
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/swapOffer/create", so);
            Console.WriteLine(response.Content);
            if ((int)response.StatusCode >= 400) return;
            Console.WriteLine(response.Content);
           

        }

    }
}
