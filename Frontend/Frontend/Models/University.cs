using System.Collections.Generic;
using System.Data.Entity;
using Frontend.Models;
using System;

namespace Frontend.Models
{
    public class University
    {
        public long id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public List<Campus> campus { get; set; }
        public HashSet<FieldOfStudy> fieldOfStudy { get; set; }
    }
}