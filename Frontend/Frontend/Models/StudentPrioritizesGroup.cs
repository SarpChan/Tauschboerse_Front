using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    /// <summary>
    /// The StudentPrioritizesGroup class models a student and a group and the priority the student gave that group.
    /// </summary>
    public class StudentPrioritizesGroup
    {
        public long Id { get; set; }
        public int Priority { get; set; }
        public Student Student { get; set; }
        public Group Group { get; set; }

    }
}
