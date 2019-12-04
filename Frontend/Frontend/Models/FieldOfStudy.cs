using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The FieldOfStudy class models a field of study.
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