using System.Collections.Generic;
namespace Timetable
{
    public class Curriculum
    {
        public long id { get; set; }
        public int term { get; set; }
        public ExamRegulations examRegulation { get; set; }
        public HashSet<Module> modules { get; set; }
    }
}