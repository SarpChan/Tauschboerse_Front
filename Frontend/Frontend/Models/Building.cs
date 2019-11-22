using System.Collections.Generic;

namespace Timetable
{
    public class Building
    {
        public long id { get; set; }
        public string name { get; set; }
        public Campus campus { get; set; }
        public List<Room> rooms { get; set; }
    }

}

