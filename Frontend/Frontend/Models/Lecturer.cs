using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Frontend.Models
{
    public class Lecturer
    {
        public long Id { get; set; }
        [JsonProperty("user")]
        public long userId { get; set; }
        public int priviledge { get; set; }
        public List<int> Groups { get; set; }
    }
}
