using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The StudyProgram class models a study program. One study program belongs to many exam regulations as well as many field of studies.
    /// </summary>
    public class StudyProgram
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("degree")]
        public string Degree { get; set; }
        [JsonProperty("examRegulations")]
        public HashSet<ExamRegulation> ExamRegulations { get; set; }
    }
}
