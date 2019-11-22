using System.Collections.Generic;

namespace Timetable
{
    public class StudyProgram
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public HashSet<ExamRegulation> ExamRegulations { get; set; }
    }
}
