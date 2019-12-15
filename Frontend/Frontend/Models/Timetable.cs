using Frontend.Helpers.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace Frontend.Models
{
    class Timetable: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Curriculum _currentCurriulum = new Curriculum();
        public Curriculum CurrentCurriulum
        {
            get { return _currentCurriulum; }
            set
            {
                if (value != _currentCurriulum)
                {
                    _currentCurriulum = value;
                    OnPropertyChanged("CurrentCurriculum");
                }
            }
        }


        /*
        [JsonConverter(typeof(JsonToGroupListConverter))]
        public List<Group> GroupList
        {
            get { return _groupList; }
            set {
                if (value != _groupList)
                {
                    _groupList = value;
                    OnPropertyChanged("GroupList");
                }
            }
        }
        private List<Group> _groupList = new List<Group>();
        */
    }
}
