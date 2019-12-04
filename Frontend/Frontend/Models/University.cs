using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The University class models a university.
    /// </summary>
    public class University
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("campuses")]
        public HashSet<Campus> Campuses { get; set; }
        [JsonProperty("fieldsOfStudy")]
        public HashSet<FieldOfStudy> FieldOfStudies { get; set; }
    }
}