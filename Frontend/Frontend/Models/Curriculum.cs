using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Curriculum class models a course curriculum.
    /// </summary>
    public class Curriculum
    {
        public long Id { get; set; }
        [JsonProperty("termPeriod")] 
        public int Term { get; set; }
        [JsonProperty("examRegulation")]
        public long ExamRegulationId { get; set; }
        [JsonProperty("modulesInCurriculum")] 
        public HashSet<ModulesInCurriculum> ModulesInCurricula { get; set; }
    }
}