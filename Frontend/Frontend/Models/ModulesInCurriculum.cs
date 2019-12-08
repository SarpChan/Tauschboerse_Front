using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class ModulesInCurriculum
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("termPeriod")]
        public int Term { get; set; }
        [JsonProperty("curriculum")]
        public long Curriculum { get; set; }
        [JsonProperty("module")]
        public HashSet<Module> Modules { get; set; }
    }            
}
