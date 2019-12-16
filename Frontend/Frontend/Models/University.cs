using System.Collections.Generic;
//using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The University class models a university. 
    /// One univerty has many campuses and field of studies.
    /// </summary>
    public class University
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public HashSet<Campus> Campuses { get; set; }
        public HashSet<FieldOfStudy> FieldOfStudies { get; set; }
    }
}