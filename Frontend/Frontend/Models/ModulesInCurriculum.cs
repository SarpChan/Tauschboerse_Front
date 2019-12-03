using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class ModulesInCurriculum
    {
        public long Id { get; set; }
        public int TermPeriod { get; set; }
        public long Curriculum { get; set; }
        public Module Module { get; set; }
        public HashSet<Course> Courses { get; set; }
    }            
}
