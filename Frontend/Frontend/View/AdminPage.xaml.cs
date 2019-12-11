using Frontend.Helpers;
using System.Windows.Controls;


namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            JsonFileDialog jfd = new JsonFileDialog();
            jfd.GetJsonFromFile();
        }
    }
}
