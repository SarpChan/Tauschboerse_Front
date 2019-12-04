using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Room class models a room.
    /// </summary>
    public class Room
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("seats")]
        public int Seats { get; set; }
        [JsonProperty("building")]
        public long BuildingId { get; set; }
        [JsonProperty("groups")]
        public List<int> Groups { get; set; }
    }
}