using System.Collections.Generic;
using Newtonsoft.Json;
using JSONConverter;
namespace Frontend.Models
{
    public enum DayOfWeek { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY}
    public class Group
    {
        //Starttime and Endttime
        public long Id { get; set; }
        public int Slots { get; set; }
        [JsonProperty("group")]
        public char GroupLetter { get; set; }
        public DayOfWeek Day { get; set; }
        public Dictionary<string, int> startTime { get; set; } // convert to datettime
        public Dictionary<string, int> endTime { get; set; }
        [JsonConverter(typeof(TermConverter))]
        public Term Term { get; set; }
        [JsonProperty("courseComponent")]
        public long CourseComponentId { get; set; }
        [JsonProperty("lecturer")]
        public long LectureId { get; set; }
        [JsonProperty("room")]
        public long RoomId { get; set; }
        [JsonConverter(typeof(StudentConverter))]
        public List<int> Students { get; set; }

    }
}