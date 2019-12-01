namespace Frontend.Models
{
    /// <summary>
    /// The User class models an user.
    /// </summary>
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