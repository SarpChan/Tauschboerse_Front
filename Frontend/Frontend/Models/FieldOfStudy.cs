using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The FieldOfStudy class models a field of study.
    /// </summary>
    public class FieldOfStudy
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public HashSet<StudyProgram> StudyPrograms { get; set; }
    }
}