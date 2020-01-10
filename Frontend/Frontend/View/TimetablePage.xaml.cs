using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {

        public static readonly string[] Wochentage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };

        public TimetablePage()
        {
            InitializeComponent();
        }

        private void Timetable_Button_Click(object sender, RoutedEventArgs e)
        {
            TimetablePage timetablePage = new TimetablePage();
            this.NavigationService.Navigate(timetablePage);
        }

      
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            this.NavigationService.Navigate(homePage);
        }

        private void TimetableItem_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TimeTable_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TestAddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
