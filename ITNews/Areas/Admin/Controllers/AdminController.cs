using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Areas.Admin.Controllers
{
    //[Route("admin/[controller]")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        //[Authorize(Roles = "admin")]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Profile()
        {
            return View();
        }
    }
}