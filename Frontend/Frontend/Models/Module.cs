using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Module class models a module.
    /// </summary>
    public class Module
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int CreditPoints { get; set; }
        public int Period { get; set; }
        [JsonProperty("modulesInCurriculum")]
        public List<int> Curriculua { get; set;}
    }
}