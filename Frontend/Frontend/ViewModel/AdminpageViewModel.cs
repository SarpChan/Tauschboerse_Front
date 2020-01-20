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
        private HashSet<FieldOfStudy> fieldsOfStudy = new HashSet<FieldOfStudy>();

        

        private ObservableCollection<FieldOfStudy> _MyItems = new ObservableCollection<FieldOfStudy>();
        public ObservableCollection<FieldOfStudy> MyItems
        {
            get { return _MyItems; }
        }

        public AdminPageViewModel()
        {

            //Console.WriteLine("\nNEW ADMINPAGEVM -> "+this.GetHashCode());


            //University university = new University();
            //HashSet<FieldOfStudy> fieldOfStudies = university.FieldOfStudies;

            //fieldofStudyComboBox.ItemsSource = fieldOfStudies;

            
            //subject.Add("Medieninformatik");
            //subject.Add("Informatik");
            //subjectComboBox.ItemsSource = subject;

            
        }

       
        
    }
}
