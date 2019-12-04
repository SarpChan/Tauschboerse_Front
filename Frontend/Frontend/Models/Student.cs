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
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("loginName")]
        public string LoginName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        public bool Admin { get; set; }
        public int EnrolementNumber { get; set; }
        public string Mail { get; set; }
        [JsonProperty("examRegulation")]
        public long ExamRegulationId { get; set; }
        public int EnrolementTerm { get; set; }
    }
}