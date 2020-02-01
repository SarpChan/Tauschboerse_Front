using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Room class models a room.
    /// One room belongs to and references one building.
    /// A room has many groups.
    /// </summary>
    public class Room
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }
        public long BuildingId { get; set; }
        public HashSet<Group> Groups { get; set; }
    }
}