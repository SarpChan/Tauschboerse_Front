namespace Timetable
{
    public class User
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
}