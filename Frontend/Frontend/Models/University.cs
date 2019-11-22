using System.Collections.Generic;

namespace Timetable
{
    public class University
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Campus> Campus { get; set; }
       public HashSet<FieldOfStudy> FieldOfStudy { get; set; }
    }
}