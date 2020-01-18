using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Frontend.ViewModel
{
    class AdminPageViewModel: ViewModelBase
    {
        private FieldOfStudy fieldOfStudy = new FieldOfStudy() { Title = "Informatik" };
        private HashSet<FieldOfStudy> fieldsOfStudy = new HashSet<FieldOfStudy>();


        private ObservableCollection<FieldOfStudy> _MyItems = new ObservableCollection<FieldOfStudy>();
        public ObservableCollection<FieldOfStudy> MyItems
        {
            get { return _MyItems; }
        }

        public AdminPageViewModel()
        {
            fieldsOfStudy.Add(fieldOfStudy);
            University university = new University() { FieldOfStudies = fieldsOfStudy };
            Console.WriteLine("zu viel ist zuviel .");

            foreach (FieldOfStudy ding in fieldsOfStudy)
            {
                _MyItems.Add(ding);
            }


            //University university = new University();
            //HashSet<FieldOfStudy> fieldOfStudies = university.FieldOfStudies;

            //fieldofStudyComboBox.ItemsSource = fieldOfStudies;

            
            //subject.Add("Medieninformatik");
            //subject.Add("Informatik");
            //subjectComboBox.ItemsSource = subject;

            
        }

       
        
    }
}
