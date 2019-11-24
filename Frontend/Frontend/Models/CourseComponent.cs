using System.Collections.Generic;

namespace Timetable
{
    public enum CourseType { LECTURE, PRACTICE, TUTORIAL, TEST };
    public class CourseComponent
    {
        public long Id { get; set; }
        public CourseType Type { get; set; }
        public int CreditPoints { get; set; }
        public string Exam { get; set; }
        public HashSet<Group> Groups { get; set; }
    }
}