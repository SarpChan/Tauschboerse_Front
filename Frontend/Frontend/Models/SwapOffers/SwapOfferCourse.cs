using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models.SwapOffers
{
    class SwapOfferCourse
    {
        public string courseId;
        public string courseName;
        public List<SwapOfferGroup> courseTypes;
    }

    class SwapOfferCourseTypes
    {
        public List<SwapOfferGroup> groups;
        public string currentGroupId;
        public string currentGroupChar;
        public string name;
    }

    class SwapOfferGroup
    {
        public char Char;
        public long Id;
    }

}
