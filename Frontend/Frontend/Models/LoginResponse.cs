using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class LoginResponse
    {
        public enum Rights { ADMIN };
        [JsonProperty("userId")]
        public long UserId;
        [JsonProperty("token")]
        public string AuthenticationToken;
        [JsonProperty("userRights")]
        public string userRight;

    }
}
