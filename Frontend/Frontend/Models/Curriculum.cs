using System.Collections.Generic;

namespace Timetable
{
    public class Curriculum
    {
        public long Id { get; set; }
        public int Term { get; set; }
        public ExamRegulation ExamRegulation { get; set; }
        public HashSet<Module> Modules { get; set; }
    }
}