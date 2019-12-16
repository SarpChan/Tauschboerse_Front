using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Module class models a module. A module belongs to one period and many curricula.
    /// One module can have many courses.
    /// </summary>
    public class Module
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int Period { get; set; }
        public HashSet<Curriculum> Curriculua { get; set; }
        public HashSet<Course> Courses { get; set; }
    }
}