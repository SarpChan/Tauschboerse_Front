using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The StudyProgram class models a study program.
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
        [JsonProperty("fieldsOfStudy")]
        public List<int> FieldsOfStudies { get; set; }
    }
}
