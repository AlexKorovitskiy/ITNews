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
                getUserAction = Url.Action("GetUser", "User", null, this.Request.Scheme, this.Request.Host.Value),
                getUsersAction = Url.Action("GetUsers", "User", null, this.Request.Scheme, this.Request.Host.Value),
                getRolesAction = Url.Action("getRoles", "Role", null, this.Request.Scheme, this.Request.Host.Value),
                updateUserAction = Url.Action("updateUser", "User", null, this.Request.Scheme, this.Request.Host.Value),
                deleteUserAction = Url.Action("deleteUser", "User", null, this.Request.Scheme, this.Request.Host.Value)
            };
            return Json(new { actions = actionsObject });
        }
    }
}