using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Room class models a room.
    /// </summary>
    public class Room
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }
        [JsonProperty("building")]
        public long BuildingId { get; set; }
    }
}