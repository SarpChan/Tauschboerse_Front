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
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("slots")]
        public long Slots { get; set; }
        [JsonProperty("groupChar")]
        public char GroupChar { get; set; }
        [JsonProperty("dayOfWeek")]
        public DayOfWeek Day { get; set; }
        [JsonProperty("startTime")]
        public Dictionary<string, int> StartTime { get; set; } // convert to datettime
        [JsonProperty("endTime")]
        public Dictionary<string, int> EndTime { get; set; }
        [JsonProperty("term")]
        public long TermId { get; set; }
        [JsonProperty("courseComponent")]
        public long CourseComponentId { get; set; }
        [JsonProperty("lecturer")]
        public Lecturer Lecturer { get; set; }
        [JsonProperty("room")]
        public long RoomId { get; set; }
        [JsonProperty("students")]
        public HashSet<Student> Students { get; set; }
        public List<int> PrioritizeGroups { get; set; }

    }
}