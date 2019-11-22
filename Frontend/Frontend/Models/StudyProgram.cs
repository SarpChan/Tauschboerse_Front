using System.Collections.Generic;

namespace Timetable
{
    public class StudyProgram
    {
        public long id { get; set; }
        public string title { get; set; }
        public string degree { get; set; }
        public HashSet<ExamRegulation> examRegulations { get; set; }
    }
}
