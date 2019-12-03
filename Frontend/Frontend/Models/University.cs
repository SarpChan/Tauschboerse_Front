using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The University class models a university.
    /// </summary>
    public class University
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public HashSet<Campus> Campuses { get; set; }
        [JsonProperty("fieldsOfStudy")]
        public HashSet<FieldOfStudy> FieldOfStudies { get; set; }
    }
}