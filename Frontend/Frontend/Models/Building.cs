using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Building class models a building.
    /// </summary>
    public class Building
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("campus")]
        public long CampusId { get; set; }
        [JsonProperty("rooms")]
        public List<long> Rooms { get; set; }
    }

     
}

