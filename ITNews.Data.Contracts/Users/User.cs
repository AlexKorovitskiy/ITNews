using System;
using System.Collections.Generic;
using System.Text;

namespace ITNews.Data.Contracts.Users
{
    public class User : EntityBaseNamed
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public bool IsConfirm { get; set; }
        public virtual IEnumerable<News> News { get; set; }
    }
}
