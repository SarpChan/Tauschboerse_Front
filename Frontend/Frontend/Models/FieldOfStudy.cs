using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The FieldOfStudy class models a field of study. 
    /// A field of study references one university and consists of many study programs.
    /// </summary>
    public class FieldOfStudy
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("studyPrograms")]
        public HashSet<StudyProgram> StudyPrograms { get; set; }
    }
}