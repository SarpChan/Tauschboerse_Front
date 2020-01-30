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
        ModuleType _Type = ModuleType.PRACTICE;
        [JsonIgnore]
        string _StartTime = "12:34";
        [JsonIgnore]
        string _EndTime = "14:42";
        [JsonIgnore]
        string _Day = "1";
        [JsonIgnore]
        string _Name = "Default";
        [JsonIgnore]
        string _GroupChar = "Default";
        [JsonIgnore]
        string _RoomNumber = "D14";
        [JsonIgnore]
        string _PersonName = "DU";

        [JsonProperty("groupID")]
        public long ID { get; set; }
        [JsonProperty("courseComponentID")]
        public long CourseID { get; set; }
        [JsonProperty("lecturerNameAbbreviation")]
        public string LecturerNameAbbreviation { get; set; }
        [JsonProperty("courseTitleAbbreviation")]
        public string courseTitleAbbreviation;


        public enum ModuleType {[Description("Vorlesung")] LECTURE, [Description("Übung")] TEST, [Description("Praktikum")] PRACTICE, [Description("Tutorium")] TUTORIAL };

        public string StartTime
        {
            get { return _StartTime; }
            set
            {
                var oldValue = _StartTime;
                _StartTime = value;
                NotifyPropertyChanged("StartTime", oldValue, value);
            }
        }
        public string EndTime
        {
            get { return _EndTime; }
            set
            {
                var oldValue = _EndTime;
                _EndTime = value;
                NotifyPropertyChanged("EndTime", oldValue, value);
            }
        }
        [JsonProperty("roomID")]
        public string RoomNumber
        {
            get { return _RoomNumber; }
            set
            {
                var oldValue = _RoomNumber;
                _RoomNumber = value;
                NotifyPropertyChanged("RoomNumber", oldValue, value);
            }
        }
        [JsonProperty("lecturerName")]
        public string PersonName
        {
            get { return _PersonName; }
            set
            {
                var oldValue = _PersonName;
                _PersonName = value;
                NotifyPropertyChanged("PersonName", oldValue, value);
            }
        }

        [JsonProperty("courseTitle")]
        public string CourseName
        {
            get { return _Name; }
            set
            {
                var oldValue = _Name;
                _Name = value;
                NotifyPropertyChanged("CourseName", oldValue, value);
            }
        }
        public string GroupChar
        {
            get { return _GroupChar; }
            set
            {
                var oldValue = _GroupChar;
                _GroupChar = value;
                NotifyPropertyChanged("GroupChar", oldValue, value);
            }
        }
        [JsonProperty("dayOfWeek")]
        public string Day
        {
            get { return _Day; }
            set
            {
                var oldValue = _Day;
                _Day = value;
                NotifyPropertyChanged("Day", oldValue, value);
            }
        }
        //[Newtonsoft.Json.JsonProperty("courseType")]
        public ModuleType Type
        {
            get { return _Type; }
            set
            {
                var oldValue = _Type;
                _Type = value;
                NotifyPropertyChanged("Type", oldValue, value);
            }
        }

        /// <summary>
        /// Copiert das Timetable Object
        /// </summary>
        /// <returns></returns>
        public TimetableModule DeepCopy()
        {
            TimetableModule other = (TimetableModule)this.MemberwiseClone();

            if (_StartTime != null)
            {
                other.StartTime = String.Copy(_StartTime);
            }

            if (_EndTime != null)
            {
                other.EndTime = String.Copy(_EndTime);
            }

            if (_Day != null)
            {
                other.Day = String.Copy(_Day);
            }

            if (_Name != null)
            {
                other.CourseName = String.Copy(_Name);
            }

            return other;
        }

        /// <summary>
        /// Uberschreibt die Daten des akt. Objektes mit den eines anderen Objektes
        /// </summary>
        /// <param name="other"></param>
        public void ReplaceData(TimetableModule other)
        {
            if (!other.StartTime.Equals(StartTime) && other.StartTime != null)
            {
                StartTime = other.StartTime;
            }

            if (!other.EndTime.Equals(EndTime) && other.EndTime != null)
            {
                EndTime = other.EndTime;
            }

            if (!other.Day.Equals(Day) && other.Day != null)
            {
                Day = other.Day;
            }

            if (!other.CourseName.Equals(CourseName) && other.CourseName != null)
            {
                CourseName = other.CourseName;
            }

            if (other.Type != Type)
            {
                Type = other.Type;
            }
        }
    }

}
//lecturerNameAbbreviation("Placeholder Abbreviation")
//courseComponentID(courseComponent.getId())
//moduleTitleAbbreviation("Placeholder Abbreviation")