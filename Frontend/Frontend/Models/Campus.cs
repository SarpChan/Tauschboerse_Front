using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Campus class models a campus.
    /// </summary>
    public class Campus
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [JsonProperty("university")]
        public long UniversityId { get; set; }
        public HashSet<Building> Buildings { get; set; }
    }
}