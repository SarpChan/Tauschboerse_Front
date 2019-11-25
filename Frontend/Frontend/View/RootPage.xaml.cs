using Frontend.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Frontend.View
{
    /* <summary>
    * Interaktionslogik für RootPage.xaml
    * Verwaltet nur die Events der Button_Click's
    * </summary>
    */

    public partial class RootPage : Page
    {
        public bool IsLoading {get; set; }
        public bool isLoading;

        private TimetableViewModel tvm = new TimetableViewModel(); //TODO: FRAGE FUER MITTWOCH: HAT DIE PAGE CS DATEI DAS VM ODER DAS VM DAS VIEW??? PROBLEM: MUSS JA AUF DER PAGE DAS LOADING SWITCHEN UND IM VIEWMODEL DAS LOADING MACHEN. IDEE: VIEW HAT GETTER SETTER FUER LOADING, DAS WARS
        /* <summary>
        * Konstruktor der RootPage : Page
        * </summary>
        */
        public RootPage()
        {
            DataContext = this;
            IsLoading = false;
            isLoading = false;
            InitializeComponent();
            
        }

        


        /* <summary>
        * Methode fuer Eventhandling "Click auf HomeButton" 
        * </summary>
        */
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            IsLoading = false;
            isLoading = false;
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
            
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf TimetableButton" 
        * </summary>
        */
        private void TimetableButton_Click(object sender, RoutedEventArgs e)
        {
            IsLoading = true;
            isLoading = true;
            TimetablePage timetablePage = new TimetablePage();
            MainFrame.NavigationService.Navigate(timetablePage);
       
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf SharingServiceButton" 
        * </summary>
        */
        private void SharingServiceButton_Click(object sender, RoutedEventArgs e)
        {
            SharingServicePage sharingServicePage = new SharingServicePage();
            MainFrame.NavigationService.Navigate(sharingServicePage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf PersonalDataButton" 
        * </summary>
        */
        private void PersonalDataButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalDataPage personalDataPage = new PersonalDataPage();
            MainFrame.NavigationService.Navigate(personalDataPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf AdminButton" 
        * </summary>
        */
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            MainFrame.NavigationService.Navigate(adminPage);
        }

        /* <summary>
        * Methode fuer Eventhandling "Click auf LogoutButton" 
        * </summary>
        */
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }
    }
}
