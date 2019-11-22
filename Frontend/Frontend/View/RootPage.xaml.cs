using System.Threading;
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
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf TimetableButton" 
        * </summary>
        */
        private void Timetable_Button_Click(object sender, RoutedEventArgs e)
        {
            TimetablePage timetablePage = new TimetablePage();
            MainFrame.NavigationService.Navigate(timetablePage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf SharingServiceButton" 
        * </summary>
        */
        private void SharingService_Button_Click(object sender, RoutedEventArgs e)
        {
            SharingServicePage sharingServicePage = new SharingServicePage();
            MainFrame.NavigationService.Navigate(sharingServicePage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf PersonalDataButton" 
        * </summary>
        */
        private void PersonalData_Button_Click(object sender, RoutedEventArgs e)
        {
            PersonalDataPage personalDataPage = new PersonalDataPage();
            MainFrame.NavigationService.Navigate(personalDataPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf AdminButton" 
        * </summary>
        */
        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            MainFrame.NavigationService.Navigate(adminPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf LogoutButton" 
        * </summary>
        */
        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }
    }
}
