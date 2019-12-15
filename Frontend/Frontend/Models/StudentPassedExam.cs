using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The StudentPassedExam class models a student and a course component as well as the grade the student received in that course component.
    /// </summary>
    public class StudentPassedExam
    {
        public long Id { get; set; }
        public float Grade { get; set; }
        public Student Student { get; set; }
        public CourseComponent CourseComponent { get; set; }
    }
}
