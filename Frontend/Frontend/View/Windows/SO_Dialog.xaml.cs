﻿using Frontend.Helpers;
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
using ToastNotifications.Messages;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for SO_Dialog.xaml
    /// </summary>
    public partial class SO_Dialog : Window
    {

        public long FromGroupID;
       
        public SO_Dialog()
        {
            InitializeComponent();
        }

        public SO_Dialog(long Id)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Methode, um das Dialogfenster wieder zu schließen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void CloWi(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Methode für den "Erstellen"-Button, die die Methode CreateSwapOfferAsync aufruft und
        /// das Dialogfenster wieder schließt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Create(object sender, RoutedEventArgs e)
        {
            CreateSwapOfferAsync();
            CloWi(sender, e);
        }

        /*
         * 
         */
         /// <summary>
         /// ein neues SwapOffer wird angelegt und an das Backend geschickt
         /// Das SwapOfferobjekt bekommt dafür die IDs von der Gruppe, in der der Student aktuell ist, 
         /// die ID der Gruppe, in die er wechseln möchte.
         /// Über den APIClient wird das Backend und der passende PostRequest angesprochen
         /// </summary>
        private async void CreateSwapOfferAsync()
        {
            SwapOfferGroup SelectedGroup = (SwapOfferGroup) ToGroup.SelectedItem;

            long ToGroupId = SelectedGroup.Id;

            SwapOffer so = new SwapOffer(FromGroupID, ToGroupId);
            APIClient apiClient = APIClient.Instance;
            var response = await apiClient.NewPOSTRequest("/rest/swapoffer/insert", so);
            
            if ((int)response.StatusCode >= 400) return;
            
            App.notifier.ShowSuccess("Tauschangebot erstellt!");


        }



    }
}
