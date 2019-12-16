using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The FieldOfStudy class models a field of study. 
    /// A field of study references one university and consists of many study programs.
    /// </summary>
    public class FieldOfStudy
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long UniversityId { get; set; }
        public HashSet<StudyProgram> StudyPrograms { get; set; }
    }
}