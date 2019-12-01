using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The CourseComponent class models a course component.
    /// </summary>
    public enum CourseType { LECTURE, PRACTICE, TUTORIAL, TEST };
    public class CourseComponent
    {
        public long Id { get; set; }
        public CourseType Type { get; set; }
        public int CreditPoints { get; set; }
        public string Exam { get; set; }
        public HashSet<Group> Groups { get; set; }
        [JsonProperty("course")]
        public long CourseId { get; set; }
    }
}