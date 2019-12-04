using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Course class models a course.
    /// </summary>
    public class Course
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("owner")]
        public User Owner { get; set; }
        [JsonProperty("modules")]
        public List<long> Modules { get; set; }
        [JsonProperty("terms")]
        public HashSet<Term> Terms { get; set; }
        [JsonProperty("courseComponents")]
        public HashSet<CourseComponent> CourseComponents { get; set; }
        [JsonProperty("studentsAttendsCourses")]
        public List<long> StudentAttendsCourses { get; set; }
    }
}