using System.Collections.Generic;
using System.Data.Entity;
using Frontend.Models;
using System;

namespace Frontend.Models
{
    public class Campus
    {
        public Campus() { }
        public long id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public List<Building> buildings { get; set; }
    }
}