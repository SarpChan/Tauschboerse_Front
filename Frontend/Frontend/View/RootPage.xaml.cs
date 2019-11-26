using Frontend.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /* <summary>
    * Interaktionslogik für RootPage.xaml
    * Verwaltet nur die Events der Button_Click's
    * </summary>
    */

    public partial class RootPage : Page
    {

        /* <summary>
        * Konstruktor der RootPage : Page
        * </summary>
        */
        public RootPage()
        {
            InitializeComponent();
        }


        /* <summary>
        * Methode fuer Eventhandling "Click auf HomeButton" 
        * </summary>
        */
        //TODO: RP Alle Button_Clicks durch ICommands ersetzen
        [Obsolete]
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
            
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf TimetableButton" 
        * </summary>
        */
        [Obsolete]
        private void TimetableButton_Click(object sender, RoutedEventArgs e)
        {
            TimetablePage timetablePage = TimetablePage.Instance;
            MainFrame.NavigationService.Navigate(timetablePage);
       
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf SharingServiceButton" 
        * </summary>
        */
        [Obsolete]
        private void SharingServiceButton_Click(object sender, RoutedEventArgs e)
        {
            SharingServicePage sharingServicePage = new SharingServicePage();
            MainFrame.NavigationService.Navigate(sharingServicePage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf PersonalDataButton" 
        * </summary>
        */
        [Obsolete]
        private void PersonalDataButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalDataPage personalDataPage = new PersonalDataPage();
            MainFrame.NavigationService.Navigate(personalDataPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf AdminButton" 
        * </summary>
        */
        [Obsolete]
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            MainFrame.NavigationService.Navigate(adminPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf LogoutButton" 
        * </summary>
        */
        [Obsolete]
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }
    }
}
