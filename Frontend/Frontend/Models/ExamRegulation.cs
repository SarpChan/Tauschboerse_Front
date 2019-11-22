using System.Collcetions.Generics;
using System;

namespace Timetable
{
    public class ExamRegulation
    {
        public long id { get; set; }
        public DateTime date { get; set; }
        public int rule { get; set; }
        public StudyProgram studyPrograms { get; set; }
        public HashSet<Curriculum> curricula { get; set; }
    }
}
