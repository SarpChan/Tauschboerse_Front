using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{


    class SwapOfferCourse
    {
        private Dictionary<String, String> CourseTypeTranslate = new Dictionary<string, string>() {
            {"lecture", "Vorlesung"},
            {"practice", "Praktikum"},
            {"tutorial", "Tutorium"},
            {"test", "Übung"},
        };

        [JsonProperty("id")]
        public long _courseComponentId;
        [JsonProperty("courseId")]
        public long _courseId; 
        [JsonProperty("title")]
        public string _courseName;
        [JsonProperty("groups")]
        public List<SwapOfferGroup> _groups;
        [JsonProperty("myGroupChar")]
        public char _groupChar;
        [JsonProperty("type")]
        public string _courseType;

        [JsonIgnore]
        public long CourseComponentId
        {
            get
            {
                return _courseComponentId;
            } set
            {
                _courseComponentId = value;
            }
        }

        [JsonIgnore]
        public long CourseId
        {
            get
            {
                return _courseId;
            }
            set
            {
                _courseId = value;
            }
        }

        [JsonIgnore]
        public string CourseName
        {
            get
            {
                return _courseName;
            }
            set
            {
                _courseName = value;
            }
        }

        [JsonIgnore]
        public List<SwapOfferGroup> Groups
        {
            get
            {
                return _groups;
            }
            set
            {
                _groups = value;
            }
        }

        [JsonIgnore]
        public char GroupChar
        {
            get
            {
                return _groupChar;
            }
            set
            {
                _groupChar = value;
            }
        }

        [JsonIgnore]
        public string CourseType
        {
            get
            {
                return CourseTypeTranslate[_courseType.ToLower()];
            }
            set
            {
                _courseType = value;
            }
        }

    }

    class SwapOfferGroup
    {
        [JsonIgnore]
        public string DisplayText
        {
            get
            {
                return "Gruppe " + Char;
            } set
            {
                DisplayText = value;
            }
        }
        [JsonProperty("groupChar")]
        public char Char;
        [JsonProperty("id")]
        public long Id;
    }

}
