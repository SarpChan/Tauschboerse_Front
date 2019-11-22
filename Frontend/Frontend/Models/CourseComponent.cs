using System.Collections.Generic;

namespace Timetable
{
    enum courseType { LECTURE, PRACTICE, TUTORIAL, TEST };
    public class CourseComponent
    {
        public long id { get; set; }
        public courseType type { get; set; }
        public int creditPoints { get; set; }
        public string exam { get; set; }
        public HashSet<Group> groups { get; set; }
    }
}