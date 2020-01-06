using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Frontend.Models
{

[Obsolete("brauchen gemeinsame klasse")]
    /**
     * Diese Klasse enthaelt alle ModelDaten betreffend Stundenplan
     */
    class TimetableData: INotifyPropertyChanged
    {
        //TODO Model.TD: Singleton TimetableData?
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private List<Module> _timetable = new List<Module>();
        public List<Module> Timetable
        {
            get { return _timetable; }
            set
            {
                if (value != _timetable)
                {
                    _timetable = value;
                    OnPropertyChanged("Timetable");
                }
            }
        }
    }
}
