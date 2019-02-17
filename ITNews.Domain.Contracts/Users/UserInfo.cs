using DomainModels;
using DomainModels.News;
using System;
using System.Collections.Generic;

namespace DomainModels.Users
{
    public class UserInfo : DomainBaseNamed
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<RoleInfo> Roles { get; set; }
        public bool IsConfirm { get; set; }
        public IEnumerable<NewsInfo> News { get; set; }
    }
}
