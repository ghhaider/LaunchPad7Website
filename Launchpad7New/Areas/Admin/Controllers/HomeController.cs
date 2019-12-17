using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Launchpad7New.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin")]
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}