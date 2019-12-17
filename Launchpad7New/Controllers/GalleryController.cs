using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Launchpad7New.Controllers
{
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult More()
        {
            ViewBag.Message = "Your LoadMore page.";

            return View();
        }
	}
}