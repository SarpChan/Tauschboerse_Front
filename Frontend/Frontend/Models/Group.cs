using System.Collections.Generic;
using System;
namespace Frontend.Models
{
    /// <summary>
    /// The Group class models a group. A group belongs to one term, one course component and one room.
    /// A group is hold by one lecturer and consists of many students.
    /// </summary>
    public enum DayOfWeek { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY}
    public class Group
    {
        public long Id { get; set; }
        public int Slots { get; set; }
        public char GroupChar { get; set; }
        public DayOfWeek Day { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public Term Term { get; set; }
        public CourseComponent CourseComponent { get; set; }
        public Lecturer Lecturer { get; set; }
        public Room Room { get; set; }
        public HashSet<Student> Students { get; set; }
        public HashSet<PrioritizeGroups> PrioritizeGroups { get; set; }

    }
}