using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITNews_WebAPI.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(new { data = "success" });
        }

        [HttpGet]
        [Route("GetActions")]
        public IActionResult GetActions()
        {
            var actionsObject = new
            {
                //myNewsAction = Url.Action("Index", "Admin", null, this.Request.Scheme, this.Request.Host.Value),
                getUsersAction = Url.Action("GetUsers", "User", null, this.Request.Scheme, this.Request.Host.Value)
                //getCurrentUserAction = Url.Action("GetCurrentUser", "MySpace", null, this.Request.Scheme, this.Request.Host.Value),
                //deleteNews = Url.Action("DeleteNews", "News", null, this.Request.Scheme, this.Request.Host.Value),
                //updateUserAction = Url.Action("updateUser", "User", null, this.Request.Scheme, this.Request.Host.Value)
            };
            return Json(new { actions = actionsObject });
        }
    }
}