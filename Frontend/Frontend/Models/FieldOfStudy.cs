using System.Collections.Generic;

namespace Timetable
{
	public class FieldOfStudy
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public HashSet<StudyProgram> StudyPrograms { get; set; }
    }
}