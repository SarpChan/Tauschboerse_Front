﻿using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend.UserControls
{



    /// <summary>
    /// Interaction logic for ModuleTimeEditor.xaml
    /// </summary>
    public partial class ModuleMainInformationEditor : UserControl
    {
        public ModuleMainInformationEditor()
        {
            InitializeComponent();
            nameTextBox.LostFocus += NameTextBox_LostFocus;
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if(textBox != null)
            {
                viewmodel.EditTimetableModule.CourseName = textBox.Text;
            }
        }

        public String DeaktiveteSaveButton
        {
            set
            {
                if (value.Equals("true"))
                {
                    saveButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    saveButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Parent is Popup)
            {
                var chooser = new ModuleEditorChooser();
                chooser.viewmodel.EditTimetableModule = viewmodel.EditTimetableModule;

                ((Popup)Parent).Child = chooser;
            }
        }

        private void StudyProgramComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (StudyProgram x in e.AddedItems)
            {
                viewmodel.FillExamRegulationList(x);
            }
        }

        private void FieldOfStudyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (FieldOfStudy x in e.AddedItems)
            {
                viewmodel.FillStudyProgramList(x);
            }
        }
    }

}
