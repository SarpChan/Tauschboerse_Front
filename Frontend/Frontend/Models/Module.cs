using System.Collections.Generic;

namespace Timetable
{
    public class Module
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int Period { get; set; }
        public HashSet<Curriculum> Curriculua { get; set;}
        public HashSet<Course> Courses { get; set; }
    }
}