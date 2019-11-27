using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class ExamRegulation
    {
        public long Id { get; set; }
        public string Date { get; set; } //convert string to datettime
        public int Rule { get; set; }
        [JsonProperty("studyProgram")]
        public long StudyProgramId { get; set; }
        public List<Curriculum> Curricula { get; set; }
    }
}
