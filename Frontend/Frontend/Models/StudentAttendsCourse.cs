using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class StudentAttendsCourse
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("student")]
        public long StudentId { get; set; }
        [JsonProperty("course")]
        public long CourseId { get; set; }
        [JsonProperty("term")]
        public long Termid { get; set; }
    }
}
