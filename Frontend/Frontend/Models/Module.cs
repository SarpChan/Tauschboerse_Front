using System.Collections.Generics;

namespace Frontend
{
    public class Module
    {
        public long id { get; set; }
        public string title { get; set; }
        public int creditPoints { get; set; }
        public int period { get; set; }
        public HashSet<Curriculum> curriculua { get; set;}
        public HashSet<Course> courses { get; set; }
    }
}