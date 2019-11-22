using System;
using System.Collections.Generic;

namespace Timetable
{
    enum dayOfWeek { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY}
    public class Group
    {
        //Starttime and Endttime
        public long id { get; set; }
        public int slots { get; set; }
        public dayOfWeek day { get; set; }
        public Term term { get; set; }
        public CourseComponent courseComponent { get; set; }
        public User lecture { get; set; }
        public Room room { get; set; }
        public HashSet<Student> students { get; set; }

    }
}