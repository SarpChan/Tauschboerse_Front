using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
namespace Frontend.Models
{
    /// <summary>
    /// The Lecturere class models a lecturer and inherits from the class role.
    /// A lecturer can have many groups.
    /// </summary>
    public class Lecturer : Role
    {
        public int Priviledge { get; set; }
        public HashSet<Group> Groups { get; set; }
    }
}
