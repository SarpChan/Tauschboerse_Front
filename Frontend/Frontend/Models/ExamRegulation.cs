using System.Collections.Generic;
using System;
namespace Frontend.Models
{
    /// <summary>
    /// The ExamRegulation class models an exam regulation.
    /// One exam regulation belongs to a study program and consists of many curricula.
    /// </summary>
    public class ExamRegulation
    {
        public long Id { get; set; }
        public DateTime Date { get; set; } 
        public int Rule { get; set; }
        public StudyProgram StudyProgramId { get; set; }
        public HashSet<Curriculum> Curricula { get; set; }
        public HashSet<Student> Students { get; set; }
    }
}
