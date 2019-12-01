using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Building class models a building.
    /// </summary>
    public class Building
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("campus")]
        public long CampusId { get; set; }
        public HashSet<Room> Rooms { get; set; }
    }

     
}

