using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable;

namespace Frontend.Models
{
    class MockupModels { 

        public MockupModels()
        {
            ModuleList = "";
        }
    private string _moduleList;
    public string ModuleList
    {
        get
        {
            return _moduleList;
        }
        set
        {
            _moduleList = value;
        }
    }

   }
}
