using Frontend.Helpers;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
    class AdminpageViewModel: ViewModelBase
    {
        private ObservableCollection<string> myItems = new ObservableCollection<string>() { 
        "one", "two","three" };
        public AdminpageViewModel()
        {
            University university = new University();
            HashSet<FieldOfStudy> fieldOfStudies = university.FieldOfStudies;

            //fieldofStudyComboBox.ItemsSource = fieldOfStudies;

            
            //subject.Add("Medieninformatik");
            //subject.Add("Informatik");
            //subjectComboBox.ItemsSource = subject;

            ObservableCollection<string> po = new ObservableCollection<string>();
            po.Add("PO 2019");
            po.Add("PO 2018");
           // poComboBox.ItemsSource = po;
        }
    }
}
