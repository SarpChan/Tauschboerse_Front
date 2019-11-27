using Newtonsoft.Json;

namespace Frontend.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Üassword { get; set; }
        public bool Admin { get; set; }
        public int EnrolementNumber { get; set; }
        public string Mail { get; set; }
        [JsonProperty("examRegulation")]
        public long ExamRegulationId { get; set; }
        public int EnrolementTerm { get; set; }
    }
}