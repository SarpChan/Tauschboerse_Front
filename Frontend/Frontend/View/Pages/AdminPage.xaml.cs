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
using Newtonsoft.Json;

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
            foreach (FieldOfStudy x in e.AddedItems)
            {
                AdminPageViewModel.FillStudyProgramList(x);
            }
        }

        private void StudyProgramComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (StudyProgram x in e.AddedItems)
            {
                AdminPageViewModel.FillExamRegulationList(x);
            }
        }

        private void ExamRegulationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(ExamRegulation eR in e.AddedItems)
            {
                AdminPageViewModel.FillSemesterList(eR);
            }
        }

        private void Semester_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var content = (string)button.Content;
            var exR = (ExamRegulation)ExamRegulationComboBox.SelectedItem;
            AdminPageViewModel.LoadNewTimeTable(exR,content);
        }
    }
}
