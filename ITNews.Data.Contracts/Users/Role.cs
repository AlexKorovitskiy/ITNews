using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts.Users
{
    public class Role : EntityBaseNamed
    {
        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}
