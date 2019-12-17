using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using Frontend.Models;
using Frontend.Helpers;
using Microsoft.Win32;
using System.IO;

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
           Helpers.JsonFileDialog jsonFileDialog = new Helpers.JsonFileDialog();
           jsonFileDialog.GetJsonFromFile();
        }

        private void upload_rules(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:";

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader stream = new StreamReader(openFileDialog.FileName))
                {
                    filenameRules.Text = openFileDialog.SafeFileName;
                }
            }
        }
    }
}
