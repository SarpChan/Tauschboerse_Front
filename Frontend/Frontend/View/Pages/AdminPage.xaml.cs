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
using Frontend.ViewModel;

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

        private void OnfieldoStudyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           //TODO
        }

        private void upload_rules(object sender, RoutedEventArgs e)
        {
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"c:";

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader stream = new StreamReader(openFileDialog.FileName))
                {
                    filenameRules.Text = openFileDialog.SafeFileName;
                }
            }
            */
        }

        private void TimeTable_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void FieldofStudyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (KeyValuePair<FieldOfStudy, string> x in e.AddedItems)
            {

                AdminPageViewModel.FillStudyProgramDict(x.Key);
            }
        }

        private void StudyProgramComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (KeyValuePair<StudyProgram, string> x in e.AddedItems)
            {
                AdminPageViewModel.FillExamRegulationDict(x.Key);
            }
        }
    }
}
