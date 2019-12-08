using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Module class models a module.
    /// </summary>
    public class Module
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("creditPoints")]
        public int CreditPoints { get; set; }
        [JsonProperty("period")]
        public int Period { get; set; }
        [JsonProperty("modulesInCurriculum")]
        public List<long> Curriculua { get; set; }
        [JsonProperty("courses")]
        public HashSet<Course> Courses { get; set; }
    }
}