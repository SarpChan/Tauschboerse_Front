using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Student class models a student.
    /// </summary>
    public class Student
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("user")]
        public long userId { get; set; }
        public string LoginName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("enrolementNumber")]
        public int EnrolmentNumber { get; set; }
        public string Mail { get; set; }
        [JsonProperty("examRegulation")]
        public long ExamRegulationId { get; set; }
        public int EnrolementTerm { get; set; }
    }
}