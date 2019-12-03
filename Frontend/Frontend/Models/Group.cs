using System.Collections.Generic;
using Newtonsoft.Json;
using Frontend.Helpers;
namespace Frontend.Models
{
    /// <summary>
    /// The Group class models a group.
    /// </summary>
    public enum DayOfWeek { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY}
    public class Group
    {
        //Starttime and Endttime
        public long Id { get; set; }
        public int Slots { get; set; }
        public char GroupChar { get; set; }
        [JsonProperty("dayOfWeek")]
        public DayOfWeek Day { get; set; }
        public Dictionary<string, int> startTime { get; set; } // convert to datettime
        public Dictionary<string, int> endTime { get; set; }
        // Use custom converter to create a new Term object
        [JsonProperty("term")]
        public long TermId { get; set; }
        [JsonProperty("courseComponent")]
        public long CourseComponentId { get; set; }
        [JsonProperty("lecturer")]
        public Lecturer Lecturer { get; set; }
        [JsonProperty("room")]
        public long RoomId { get; set; }
        //Use custom converter to create a new Student object
        [JsonConverter(typeof(StudentConverter))]
        public HashSet<Student> Students { get; set; }

    }
}