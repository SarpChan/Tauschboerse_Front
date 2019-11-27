using System.Collections.Generic;

namespace Frontend.Models
{
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public User Owner { get; set; }
        public HashSet<CourseComponent> CourseComponents { get; set; }
        public HashSet<Group> Groups { get; set; }
        public List<int> Modules { get; set; }
        public List<int> Terms { get; set; }
    }
}
