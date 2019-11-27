using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class Curriculum
    {
        public long Id { get; set; }
        public int Term { get; set; }
        [JsonProperty("examRegulation")]
        public long ExamRegulationId { get; set; }
        public HashSet<Module> Modules { get; set; }
    }
}