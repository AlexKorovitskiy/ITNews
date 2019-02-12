using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryModels.Users
{
    public class Role : EntityBaseNamed
    {
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
