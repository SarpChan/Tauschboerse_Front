using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Term class models a term. One term has a start and end date. 
    /// One term has a period and many courses, groups and students.
    /// </summary>
    public class Term
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int Period { get; set; }
        public HashSet<Course> Courses { get; set; }
        public HashSet<Group> Groups { get; set; }
        public HashSet<StudentAttendsCourse> StudentAttendsCourses { get; set; }
        public HashSet<Student> EnroledStudents { get; set; }                          
    }
}