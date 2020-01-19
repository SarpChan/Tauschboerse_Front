using Frontend.Helpers.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class TimetableModule : NotifyPropertyValueChange
    {

        //public event PropertyChangedEventHandler PropertyChanged ;

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
                var oldValue = _StartTime;
                _StartTime = value;
                NotifyPropertyChanged("StartTime", oldValue, value);
            } 
        }
        public string EndTime { get { return _EndTime; }
            set {
                var oldValue = _EndTime;
                _EndTime = value;
                NotifyPropertyChanged("EndTime", oldValue, value);
            } 
        }
        [JsonProperty("roomID")]
        public string RoomNumber { get; set; }
        [JsonProperty("lecturerName")]
        public string PersonName { get; set; }
        [JsonProperty("courseTitle")]
        public string CourseName { get { return _Name; } 
            set {
                var oldValue = _Name;
                _Name = value;
                NotifyPropertyChanged("Name", oldValue, value);
            } 
        }
        public char GroupChar { get; set; }
        [JsonProperty("dayOfWeek")]
        public string Day { get { return _Day; } 
            set {
                var oldValue = _Day;
                _Day = value;
                NotifyPropertyChanged("Day", oldValue, value);
            }
        }
        //[Newtonsoft.Json.JsonProperty("courseType")]
        public ModuleType Type {
            get { return _Type; }
            set
            {
                var oldValue = _Type;
                _Type = value;
                NotifyPropertyChanged("Type", oldValue, value);
            }
        }
    }

}
//lecturerNameAbbreviation("Placeholder Abbreviation")
//courseComponentID(courseComponent.getId())
//moduleTitleAbbreviation("Placeholder Abbreviation")