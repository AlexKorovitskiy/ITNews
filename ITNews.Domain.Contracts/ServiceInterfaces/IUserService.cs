using DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ServiceInterfaces
{
    public interface IUserService : IInfoModelService<UserInfo>
    {
        UserInfo GetUser(string email, string password);
    }
}
