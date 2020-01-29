using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOfferCourse
    {
        [JsonProperty("id")]
        public long courseComponentId;
        [JsonProperty("courseId")]
        public long courseId; 
        [JsonProperty("title")]
        public string courseName;
        [JsonProperty("groups")]
        public List<SwapOfferGroup> groups;
        [JsonProperty("myGroupChar")]
        public char groupChar;
        [JsonProperty("typ")]
        public string courseType;

    }

    class SwapOfferGroup
    {
        [JsonIgnore]
        public string DisplayText
        {
            get
            {
                return "Gruppe " + Char;
            } set
            {
                DisplayText = value;
            }
        }
        public char Char;
        public long Id;
    }

}
