﻿using System.Collections.Generic;
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
            //Stundenplan.Focus();
            


            //Zum Testen 
            /*
            List<Rule> rules = new List<Rule>(); //only for testing purposes
            rules.Add(new Rule() { Id = 1, Beschreibung = "Hallo i bin eine Beschreibung!", Regel = "Regel bist du es ?"});
            rules.Add(new Rule() { Id = 2, Beschreibung = "Hallo i bin eine Beschreibung!", Regel = "Regel bist du es ?" });
            rules.Add(new Rule() { Id = 3, Beschreibung = "Hallo i bin eine Beschreibung!", Regel = "Regel bist du es ?" });



            DataGridRules.ItemsSource = rules;
            */

            ObservableCollection<string> po = new ObservableCollection<string>();
            po.Add("PO 2019");
            po.Add("PO 2018");
            ExamRegulationComboBox.ItemsSource = po;

            ObservableCollection<string> foS = new ObservableCollection<string>();
            foS.Add("Informatik");

            FieldofStudyComboBox.ItemsSource = foS;

            ObservableCollection<string> Sp = new ObservableCollection<string>();
            Sp.Add("Meideninformatik");

            StudyProgramComboBox.ItemsSource = Sp;


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
    }
}
