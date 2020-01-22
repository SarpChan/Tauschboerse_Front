using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class SwapOfferFrontendModel
    {

        public long Id { get; set; }
        public char FromGroupChar { get; set; }
        public char ToGroupChar { get; set; }
        public string CourseName { get; set; }
        public string CourseType { get; set; }
        public TimeSpan ToStartTime { get; set; }
        public TimeSpan ToEndTime { get; set; }
        public TimeSpan FromStartTime { get; set; }
        public TimeSpan FromEndTime { get; set; }
        public DayOfWeek FromDay { get; set; }
        public DayOfWeek ToDay { get; set; }


    }
}
