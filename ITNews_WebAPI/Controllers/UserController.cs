using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using ITNews_WebAPI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ITNewsBaseController
    {
        IUserService userService;
        IHubContext<UsersHub, IUserHubClient> userContext;
        public UserController(IUserService userService, IHubContext<UsersHub, IUserHubClient> userContext)
        {
            this.userService = userService;
            this.userContext = userContext;
        }

        [Authorize("admin")]
        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<UserInfo> GetUsers()
        {
            var users = userService.GetModelCollections();
            return users;
        }

        [Authorize]
        [HttpGet]
        [Route("getUser")]
        public JsonResult GetUser(int id)
        {
            var user = userService.GetModelById(id);
            return Json(JsonConvert.SerializeObject(user, Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore/* , PreserveReferencesHandling = PreserveReferencesHandling.All */}));
        }

        [Authorize]
        [HttpPost]
        [Route("updateUser")]
        public void UpdateUser(UserInfo user)
        {
            if (!CurrentUserHasRole("admin"))
            {
                if (user.Id != UserId)
                {
                    throw new UnauthorizedAccessException();
                }
            }
            userService.Update(user);
            userContext.Clients.All.UpdateUser(user);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("[action]")]
        public void DeleteUser(int id)
        {
            userService.Delete(id);
            userContext.Clients.All.RemoveUser(id);
        }
    }
}