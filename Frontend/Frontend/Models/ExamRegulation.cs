using System;
using System.Collections.Generic;

namespace Timetable
{
    public class ExamRegulation
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int Rule { get; set; }
        public StudyProgram StudyPrograms { get; set; }
        public HashSet<Curriculum> Curricula { get; set; }
    }
}
