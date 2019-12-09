using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Curriculum class models a course curriculum.
    /// A curriculum belongs to one term and one exam regulations.
    /// One curriculum consists of many modules.
    /// </summary>
    public class Curriculum
    {
        public long Id { get; set; }
        public int Term { get; set; }
        public long ExamRegulationId { get; set; } 
        public HashSet<ModuleInCurriculum> ModulesInCurriculum { get; set; }
    }
}