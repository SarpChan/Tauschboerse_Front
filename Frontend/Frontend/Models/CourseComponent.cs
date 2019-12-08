using System.Collections.Generic;
using Newtonsoft.Json;
using Frontend.Helpers;
namespace Frontend.Models
{
    /// <summary>
    /// The CourseComponent class models a course component.
    /// </summary>
    public enum CourseType { LECTURE, PRACTICE, TUTORIAL, TEST };
    public class CourseComponent
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("type")]
        public CourseType Type { get; set; }
        [JsonProperty("creditPoints")]
        public int CreditPoints { get; set; }
        [JsonProperty("exam")]
        public string Exam { get; set; }
        [JsonProperty("groups")]
        public HashSet<Group> Groups { get; set; }
        [JsonProperty("course")]
        public long CourseId { get; set; }
        [JsonProperty("studentPassedExam")]
        public StudentPassedExam StudentPassedExam { get; set; }
    }
}