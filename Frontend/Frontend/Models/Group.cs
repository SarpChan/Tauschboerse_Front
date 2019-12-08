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
        public long Id { get; set; }
        public long TermId { get; set; }
        public long CourseComponentId { get; set; }
        public long RoomId { get; set; }
        public long Slots { get; set; }
        public char GroupChar { get; set; }
        public Dictionary<string, int> StartTime { get; set; } //warum dictionary? was fuer ein string soll denn da als key stehen?
        public Dictionary<string, int> EndTime { get; set; }
        //public Lecturer Lecturer { get; set; }
        public string Lecturer { get; set; }
        public DayOfWeek Day { get; set; }
        //public List<int> PrioritizeGroups { get; set; } was ist das?-> null!
        public HashSet<Student> Students { get; set; } //was ist das? -> null!

    }
}