using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       
        public SO_Dialog()
        {
            InitializeComponent();
        }

   
        /*
         * Methode, um das Dialogfenster wieder zu schließen
         */
        private void CloWi(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        /*
         * Methode für den "Erstellen"-Button, die die Methode CreateSwapOfferAsync aufruft und
         * das Dialogfenster wieder schließt 
         */
        public void Create(object sender, RoutedEventArgs e)
        {
            CreateSwapOfferAsync();
            CloWi(sender, e);
        }

        /*
         * Methode, um ein neues SwapOffer anzulegen und dieses an das Backend zu schicken
         * Das SwapOfferobjekt bekommt dafür die IDs von der Gruppe, in der der Student aktuell ist, 
         * die ID der Gruppe, in die er wechseln möchte.
         * Über den APIClient wird das Backend und der passende PostRequest angesprochen
         */
        private async void CreateSwapOfferAsync()
        {
            long ToGroupID = 0;

            foreach (long id in ToGroup.ItemsSource)
            {
                if(id.Equals(ToGroup.SelectedItem))
                {
                    ToGroupID = id;
             
                }
            }
            
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
