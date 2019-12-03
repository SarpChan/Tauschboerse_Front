using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Course class models a course.
    /// </summary>
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public User Owner { get; set; }
        public List<int> Modules { get; set; }
        public HashSet<Term> Terms { get; set; }
        public HashSet<CourseComponent> CourseComponents { get; set; }
    }
}