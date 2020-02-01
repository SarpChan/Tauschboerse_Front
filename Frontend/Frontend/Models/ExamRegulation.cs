using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The ExamRegulation class models an exam regulation.
    /// One exam regulation belongs to a study program and consists of many curricula.
    /// </summary>
    public class ExamRegulation
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; } 
        [JsonProperty("maxTerms")]
        public int MaxTerms;
    }
}
