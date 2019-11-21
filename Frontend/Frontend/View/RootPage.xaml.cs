using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaktionslogik für RootPage.xaml
    /// </summary>
    public partial class RootPage : Page
    {
        public RootPage()
        {
            InitializeComponent();
        }


        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }

        private void Timetable_Button_Click(object sender, RoutedEventArgs e)
        {
            TimetablePage timetablePage = new TimetablePage();
            MainFrame.NavigationService.Navigate(timetablePage);
        }

        private void SharingService_Button_Click(object sender, RoutedEventArgs e)
        {
            SharingServicePage sharingServicePage = new SharingServicePage();
            MainFrame.NavigationService.Navigate(sharingServicePage);
        }

        private void PersonalData_Button_Click(object sender, RoutedEventArgs e)
        {
            PersonalDataPage personalDataPage = new PersonalDataPage();
            MainFrame.NavigationService.Navigate(personalDataPage);
        }

        private void Admin_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            MainFrame.NavigationService.Navigate(adminPage);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            MainFrame.NavigationService.Navigate(homePage);
        }
    }
}
