using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using Frontend.Models;
using Frontend.Helpers;

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

            ObservableCollection<string> po = new ObservableCollection<string>();
            po.Add("PO 2019");
            po.Add("PO 2018");
            poComboBox.ItemsSource = po;
            fieldofStudyComboBox.ItemsSource = po;

        }

        private void OnfieldoStudyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           Helpers.JsonFileDialog jsonFileDialog = new Helpers.JsonFileDialog();
           jsonFileDialog.GetJsonFromFile();
        }
    }
}
