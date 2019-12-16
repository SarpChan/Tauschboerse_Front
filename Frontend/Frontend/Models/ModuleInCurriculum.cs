using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The ModuleInCurriculum class models a curriculum and its appendant modules for one term period.
    /// </summary>

    public class ModuleInCurriculum
    {
        public long Id { get; set; }
        public int Term { get; set; }
        public Curriculum Curriculum { get; set; }
        public HashSet<Module> Modules { get; set; }
    }            
}
