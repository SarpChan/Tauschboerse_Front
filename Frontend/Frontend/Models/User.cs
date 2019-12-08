using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The User class models an user.
    /// </summary>
    public class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("firstName")]
        public string Firstname { get; set; }
        [JsonProperty("lastName")]
        public string Lastname { get; set; }
        [JsonProperty("loginName")]
        public string Loginname { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("roles")]
        public HashSet<Role> Roles { get; set; }
    }
}