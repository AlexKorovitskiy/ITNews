using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.ServiceInterfaces;
using DomainModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
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
        public UserInfo GetUser(int id)
        {
            return userService.GetModelById(id);
        }

        [Authorize]
        [HttpPost]
        [Route("updateUser")]
        public void UpdateUser(UserInfo user)
        {
            userService.Update(user);
        }
    }
}