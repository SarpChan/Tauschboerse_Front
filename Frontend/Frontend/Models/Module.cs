using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class Module
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int Period { get; set; }
        [JsonProperty("curriculums")]
        public List<int> Curriculua { get; set;}
        public HashSet<Course> Courses { get; set; }
    }
}