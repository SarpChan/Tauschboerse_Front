namespace Timetable
{
    public class Room
    {
        public long id { get; set; }
        public int number { get; set; }
        public int seats { get; set; }
        public Building building { get; set; }
    }
}