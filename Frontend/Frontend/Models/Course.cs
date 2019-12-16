using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Course class models a course.
    /// One course belongs to many modules and terms.
    /// A course consists of many course components and students.
    /// </summary>
    public class Course
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public User Owner { get; set; }
        public HashSet<Module> Modules { get; set; }
        public HashSet<Term> Terms { get; set; }
        public HashSet<CourseComponent> CourseComponents { get; set; }
        public HashSet<StudentAttendsCourse> StudentAttendsCourses { get; set; }
    }
}