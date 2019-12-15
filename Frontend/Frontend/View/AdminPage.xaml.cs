using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            ObservableCollection<string> subject = new ObservableCollection<string>();
            subject.Add("Medieninformatik");
            subject.Add("Informatik");
            subjectComboBox.ItemsSource = subject;


        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            JsonFileDialog jfd = new JsonFileDialog();
            jfd.GetJsonFromFile();
        }
    }
}
