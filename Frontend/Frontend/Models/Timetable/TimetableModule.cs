using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class TimetableModule : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        [JsonIgnore]
        ModuleType _Type;
        [JsonIgnore]
        string _StartTime;
        [JsonIgnore]
        string _EndTime;
        [JsonIgnore]
        string _Day;
        [JsonIgnore]
        string _Name;
        

        public enum ModuleType { Vorlesung, Übung, Praktikum, Tutorium };
        [JsonProperty("groupID")] 
        public string ID { get; set; }
        public string StartTime { get { return _StartTime; } 
            set {
                _StartTime = value;
                OnPropertyChanged("StartTime");
            } 
        }
        public string EndTime { get { return _EndTime; }
            set {
                _EndTime = value;
                OnPropertyChanged("EndTime");
            } 
        }
        [JsonProperty("roomID")]
        public string RoomNumber { get; set; }
        [JsonProperty("lecturerName")]
        public string PersonName { get; set; }
        [JsonProperty("moduleTitle")]
        public string CourseName { get { return _Name; } 
            set {
                _Name = value;
                OnPropertyChanged("Name");
            } 
        }
        public char GroupChar { get; set; }
        [JsonProperty("dayOfWeek")]
        public string Day { get { return _Day; } 
            set {
                _Day = value;
                OnPropertyChanged("Day");
            }
        }
        //[Newtonsoft.Json.JsonProperty("courseType")]
        public ModuleType Type {
            get { return _Type; }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

}
//lecturerNameAbbreviation("Placeholder Abbreviation")
//courseComponentID(courseComponent.getId())
//moduleTitleAbbreviation("Placeholder Abbreviation")