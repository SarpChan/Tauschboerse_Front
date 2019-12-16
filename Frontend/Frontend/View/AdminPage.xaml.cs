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
        ObservableCollection<string> subject = new ObservableCollection<string>();

        public AdminPage()
        {
            InitializeComponent();
            /*StudyProgram test2 = new StudyProgram();
            List<int> test = new List<int>();
            test = test2.FieldsOfStudies;*/

            University university = new University();
            HashSet<FieldOfStudy> fieldOfStudies= university.FieldOfStudies;

            fieldofStudyComboBox.ItemsSource = fieldOfStudies;

            subject.Add("Medieninformatik");
            subject.Add("Informatik");
            subjectComboBox.ItemsSource = subject;

            ObservableCollection<string> po = new ObservableCollection<string>();
            po.Add("PO 2019");
            po.Add("PO 2018");
            poComboBox.ItemsSource = po;

        }

        private void subjectComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            object selectedSubject =(subjectComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
            this.Background = new SolidColorBrush(Color.FromRgb(55,100, 5));
        }

        private void fieldoStudyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            object selectedSubject = (subjectComboBox.SelectedItem as PropertyInfo).GetValue(null, null);
            this.Background = new SolidColorBrush(Color.FromRgb(55, 100, 5));
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           Helpers.JsonFileDialog jsonFileDialog = new Helpers.JsonFileDialog();
           jsonFileDialog.GetJsonFromFile();
        }
    }
}
