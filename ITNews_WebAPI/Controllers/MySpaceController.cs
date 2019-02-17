using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.News;
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
    public class MySpaceController : ITNewsBaseController
    {
        INewsService newsService;
        IUserService userService;

        public MySpaceController(INewsService newsService, IUserService userService)
        {
            this.newsService = newsService;
            this.userService = userService;
        }

        [Authorize(Roles = "admin, writer")]
        [Route("MyNews")]
        [HttpGet]
        public IActionResult MyNews()
        { 
            var news = newsService.GetNews(UserId);
            return Json( JsonConvert.SerializeObject(news, Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore/* , PreserveReferencesHandling = PreserveReferencesHandling.All */}));
        }

        [Authorize]
        [HttpGet]
        [Route("GetCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            var user = userService.GetModelById(UserId);
            return Json(JsonConvert.SerializeObject(user, Formatting.Indented,
                 new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore/*,PreserveReferencesHandling = PreserveReferencesHandling.Objects */}));

        }

        [HttpGet]
        [Route("GetActions")]
        public IActionResult GetActions()
        {
            var actionsObject = new
            {
                myNewsAction = Url.Action("MyNews", "MySpace", null, this.Request.Scheme, this.Request.Host.Value),
                addNewsAction = Url.Action("AddNews", "News", null, this.Request.Scheme, this.Request.Host.Value),
                getCurrentUserAction = Url.Action("GetCurrentUser", "MySpace", null, this.Request.Scheme, this.Request.Host.Value),
                deleteNews = Url.Action("DeleteNews", "News", null, this.Request.Scheme, this.Request.Host.Value),
                updateUserAction = Url.Action("updateUser", "User", null, this.Request.Scheme, this.Request.Host.Value)
            };
            return Json(new { actions = actionsObject });
        }
    }
}