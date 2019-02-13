using DomainModels.Users;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITNews_WebAPI.Hubs
{
    public class UsersHub : Hub<IUserHubClient>
    {
        public void AddUser(UserInfo user)
        {
            Clients.All.AddUser(user);
        }

        public void RemoveUser(int id)
        {
            Clients.All.RemoveUser(id);
        }

        public void UpdateUser(UserInfo user)
        {
            Clients.All.UpdateUser(user);
        }
    }
}
