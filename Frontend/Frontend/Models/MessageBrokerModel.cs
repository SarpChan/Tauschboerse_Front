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
        public long timestamp;
        public string message;
    }

    public class PersonalNewsMessage
    {
        public long timestamp;
        public string message;
        public long userid;
    }

    public class PublicSwapMessage
    {
        public long timestamp;
        public string action; 
        public string data;
    }
}