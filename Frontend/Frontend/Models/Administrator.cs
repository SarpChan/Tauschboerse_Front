using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    /// <summary>
    /// The Administrator class models an administrator.
    /// An administrator is a role with administrative permissions.
    /// </summary>
    public class Administrator : Role
    {
        public int Priviledge { get; set; }
    }
}
