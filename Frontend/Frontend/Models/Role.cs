using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    class Role
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("user")]
        public List<int> User { get; set; }
    }
}
