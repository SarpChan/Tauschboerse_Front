using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class TimetableModule
    {
        public enum ModuleType { Vorlesung, Übung, Praktikum, Tutorium };
        [JsonProperty("groupID")] 
        public string ID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        [JsonProperty("roomID")]
        public string RoomNumber { get; set; }
        [JsonProperty("lecturerName")]
        public string PersonName { get; set; }
        [JsonProperty("moduleTitle")]
        public string CourseName { get; set; }
        public char GroupChar { get; set; }
        [JsonProperty("dayOfWeek")]
        public string Day { get; set; }
        //[Newtonsoft.Json.JsonProperty("courseType")]
        public ModuleType Type { get; set; }//TODO: braucht noch anpassung fuer json parser 
    }

}
//lecturerNameAbbreviation("Placeholder Abbreviation")
//courseComponentID(courseComponent.getId())
//moduleTitleAbbreviation("Placeholder Abbreviation")