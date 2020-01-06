using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    /// <summary>
    /// The StudentsAttendsCourse class models one student who attends one curse during one term.
    /// </summary>
    public class StudentAttendsCourse
    {
        public long Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public Term Term { get; set; }
    }
}
