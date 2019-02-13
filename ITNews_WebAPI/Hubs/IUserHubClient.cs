using DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public interface IUserHubClient
    {
        Task AddUser(UserInfo user);
        Task UpdateUser(UserInfo user);
        Task RemoveUser(int id);
    }
}
