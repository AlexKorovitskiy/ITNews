using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ITNews.Controllers
{
    public class MySpaceController : Controller
    {
        public IActionResult MyNews()
        {
            return View();
        }

        public IActionResult PersanalData()
        {
            return View();
        }
    }
}