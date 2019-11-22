using System.Collections.Generic;

namespace Timetable
{
	class FieldOfStudy
    {
        public long id { get; set; }
        public string title { get; set; }
        public HashSet<StudyProgram> studyPrograms { get; set; }
    }
}