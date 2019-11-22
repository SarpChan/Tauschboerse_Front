namespace Timetable
{
    public class User
    {
        public long id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string loginname { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }
    }
}