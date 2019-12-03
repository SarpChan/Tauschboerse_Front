using System;
using System.Collections.Generic;

namespace Frontend.Models
{
    /// <summary>
    /// The Term class models a term.
    /// </summary>
    public class Term
    {
        public long Id { get; set; }
        public string StartDate { get; set; } //convert string to datetime
		public string EndDate { get; set; }
		public int Period { get; set; }
        public List<int> Courses { get; set; }
        public List<int> Groups { get; set; }
        public List<int> StudentAttendsCourses { get; set; }
        public List<int> EnroledStudents { get; set; }                          
    }
}