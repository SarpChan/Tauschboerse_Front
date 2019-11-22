namespace Timetable
{
    public class Room
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }
        public Building Building { get; set; }
    }
}