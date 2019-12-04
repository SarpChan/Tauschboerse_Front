using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    class StudentPassedExam
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("grade")]
        public float Grade { get; set; }
        [JsonProperty("student")]
        public long StudentId { get; set; }
        [JsonProperty("courseComponents")]
        public List<long> CourseComponents { get; set; }
    }
}
