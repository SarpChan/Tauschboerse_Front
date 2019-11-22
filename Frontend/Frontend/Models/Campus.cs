using System.Collections.Generic;

namespace Timetable
{
    public class Campus
    {
        public Campus() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Building> Buildings { get; set; }
    }
}