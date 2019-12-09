using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Student class models a student and inherits from the class role.
    /// </summary>
    public class Student : Role
    {
        public int EnrolmentNumber { get; set; }
        public string Mail { get; set; }
        public ExamRegulation ExamRegulation { get; set; }
        public Term EnrolementTerm { get; set; }
        public HashSet<StudentPrioritizesGroup> PrioritizeGroups { get; set; }
        public HashSet<StudentPassedExam> PassedExam { get; set; }
        public HashSet<Group> Groups { get; set; }
    }
}