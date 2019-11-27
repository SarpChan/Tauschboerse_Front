using System.Collections.Generic;

namespace Frontend.Models
{
	public class FieldOfStudy
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public HashSet<StudyProgram> StudyProgram { get; set; }
    }
}