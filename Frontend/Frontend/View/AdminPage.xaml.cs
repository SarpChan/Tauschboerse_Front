using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using Frontend.Models;

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

        private void subjectComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (subjectComboBox.SelectedItem != null)
            {
                //object selectedSubject = (subjectComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
                //this.Background = new SolidColorBrush(Color.FromRgb(55, 100, 5));
            }
        }

        private void fieldoStudyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (subjectComboBox.SelectedItem != null)
            {
                object selectedSubject = (subjectComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
                this.Background = new SolidColorBrush(Color.FromRgb(55, 100, 5));
            }
        }

        private void poComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (subjectComboBox.SelectedItem != null)
            {
                object selectedSubject = (subjectComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
                this.Background = new SolidColorBrush(Color.FromRgb(55, 100, 5));
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           // JsonFileDialog jfd = new JsonFileDialog();
            //jfd.GetJsonFromFile();
        }
    }
}
