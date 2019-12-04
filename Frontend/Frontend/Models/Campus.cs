using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Campus class models a campus.
    /// </summary>
    public class Campus
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("university")]
        public long UniversityId { get; set; }
        [JsonProperty("buildings")]
        public HashSet<Building> Buildings { get; set; }
    }
}