using System.Collections.Generic;

namespace Timetable
{
    public class Couse
    {
        public long id { get; set; }
        public string title { get; set; }
        public User owner { get; set; }
        public HashSet<CourseComponent> courseComponents { get; set; }
        public HashSet<Module> modules { get; set; }
        public HashSet<Term> terms { get; set; }
    }
}
