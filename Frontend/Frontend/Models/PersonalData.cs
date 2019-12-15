using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class PersonalData : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Student _activeStudent = new Student();
        public Student ActiveStudent
        {
            get { return _activeStudent; }
            set
            {
                if (value != _activeStudent)
                {
                    _activeStudent = value;
                    OnPropertyChanged("ActiveStudent");
                }
            }
        }

        public PersonalData()
        {
            ActiveStudent = new Student();
        }
    }
}
