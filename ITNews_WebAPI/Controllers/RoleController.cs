using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ITNews_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetRoles()
        {
            var roles = roleService.GetModelCollections();
            return Json(JsonConvert.SerializeObject(roles, Formatting.Indented,
                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore/* , PreserveReferencesHandling = PreserveReferencesHandling.All */}));
        }
    }
}