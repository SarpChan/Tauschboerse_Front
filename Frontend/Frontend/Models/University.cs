using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class University
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        
        public string Address { get; set; }
        public List<Campus> Campus { get; set; }
        [JsonProperty("fieldOfStudies")]
        public HashSet<FieldOfStudy> FieldOfStudies { get; set; }
    }
}