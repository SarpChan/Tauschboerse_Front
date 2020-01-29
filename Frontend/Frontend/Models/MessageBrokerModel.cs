using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class JsonMessage
    {
        [JsonProperty]
        public long timestamp;
        public string message;
    }

    public class PublicSwapMessage
    {
        public long timestamp;
        public string action;
        public string data;
    }
}