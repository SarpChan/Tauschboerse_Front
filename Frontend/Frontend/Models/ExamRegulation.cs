using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The ExamRegulation class models an exam regulation.
    /// </summary>
    public class ExamRegulation
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; } //convert string to datettime
        [JsonProperty("rule")]
        public int Rule { get; set; }
        [JsonProperty("studyProgram")]
        public long StudyProgramId { get; set; }
        [JsonProperty("curriculums")]
        public HashSet<Curriculum> Curricula { get; set; }
        [JsonProperty("students")]
        public List<long> Students { get; set; }
    }
}
