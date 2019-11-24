using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable;

namespace Frontend.Models
{
    class MockupModels
    {
        public List<Group> GroupList { get; set; }
        public Student ActiveStudent { get; set; }

        public MockupModels ()
        {
            this.ActiveStudent = new Student();
            this.ActiveStudent.EnrolementNumber = 1001337;
        }
    }
}
