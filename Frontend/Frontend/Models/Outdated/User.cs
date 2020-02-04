using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The User class models an user.
    /// One user can have many roles.
    /// </summary>
    public class User
    {
        public User()
        {
            Id = (int)(new Random().NextDouble() * 999) + 1;
            Firstname = "";
            Lastname = "";
            Loginname = "";
            Password = "";
            Roles = new HashSet<Role>();
        }

        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public HashSet<Role> Roles { get; set; }
    }
}