using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Term class models a term.
    /// </summary>
    public class Term
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("startDate")]
        public string StartDate { get; set; } //convert string to datetime
        [JsonProperty("endDate")]
        public string EndDate { get; set; }
        [JsonProperty("period")]
        public int Period { get; set; }
        [JsonProperty("courses")]
        public List<long> Courses { get; set; }
        [JsonProperty("groups")]
        public List<long> Groups { get; set; }
        [JsonProperty("studentAttendsCourses")]
        public HashSet<StudentAttendsCourse> StudentAttendsCourses { get; set; }
        [JsonProperty("enroledStudents")]
        public List<long> EnroledStudents { get; set; }                          
    }
}