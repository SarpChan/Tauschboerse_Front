using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frontend.Models
{
    /// <summary>
    /// The Campus class models a campus.
    /// A campus belongs to and refernces one university.
    /// One campus has many buildings.
    /// </summary>
    public class Campus
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public long UniversityId { get; set; }
        public HashSet<Building> Buildings { get; set; }
    }
}