using System.ComponentModel;

namespace Frontend.Models
{
    /**
     * Diese Klasse enthaelt alle ModelDaten betreffend der Eigenen Daten
     */
    class PersonalData : INotifyPropertyChanged
    {
        //TODO: Singleton PersonalData?
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
