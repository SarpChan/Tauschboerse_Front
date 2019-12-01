using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The StudyProgram class models a study program.
    /// </summary>
    public class StudyProgram
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Degree { get; set; }
        public HashSet<ExamRegulation> ExamRegulations { get; set; }
    }
}
