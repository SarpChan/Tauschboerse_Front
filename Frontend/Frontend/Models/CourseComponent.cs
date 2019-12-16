using System.Collections.Generic;
//using Newtonsoft.Json;
namespace Frontend.Models
{
    /// <summary>
    /// The CourseComponent class models a course component.
    /// A course component describes the type of course.
    /// A course component can be split into multiple groups.
    /// </summary>
    public enum CourseType { LECTURE, PRACTICE, TUTORIAL, TEST };
    public class CourseComponent
    {
        public long Id { get; set; }
        public CourseType Type { get; set; }
        public int CreditPoints { get; set; }
        public string Exam { get; set; }
        public HashSet<Group> Groups { get; set; }
        public long CourseId { get; set; }
        public StudentPassedExam StudentPassedExam { get; set; }
    }
}