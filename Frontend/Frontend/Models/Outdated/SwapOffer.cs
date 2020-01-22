using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    class SwapOffer
    {
        public long id;
        public DateTime date;
        public Student student;
        public Group fromGroup;
        public Group toGroup;
    }
}
