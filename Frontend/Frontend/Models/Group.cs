using System.Collections.Generic;

namespace Timetable
{
    public enum DayOfWeek { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY}
    public class Group
    {
        //Starttime and Endttime
        public long Id { get; set; }
        public int Slots { get; set; }
        public DayOfWeek Day { get; set; }
        public Term Term { get; set; }
        public CourseComponent CourseComponent { get; set; }
        public User Lecture { get; set; }
        public Room Room { get; set; }
        public HashSet<Student> Students { get; set; }

    }
}