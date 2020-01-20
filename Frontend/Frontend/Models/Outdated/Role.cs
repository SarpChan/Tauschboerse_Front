using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    /// <summary>
    /// The Role class models a role. A role is applicable to one user.
    /// </summary>
    public abstract class Role
    {
        public long Id { get; set; }
        public User User { get; set; }
    }
}
