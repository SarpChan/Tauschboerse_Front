using System.Collections.Generic;

namespace Timetable
{
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public User Owner { get; set; }
        public HashSet<CourseComponent> CourseComponents { get; set; }
        public HashSet<Module> Modules { get; set; }
        public HashSet<Term> Terms { get; set; }
    }
}
