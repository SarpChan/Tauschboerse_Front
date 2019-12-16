using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Building class models a building.
    /// A building is located on and references one campus.
    /// One building has many rooms.
    /// </summary>
    public class Building
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CampusId { get; set; }
        public HashSet<Room> Rooms { get; set; }
    }

     
}

