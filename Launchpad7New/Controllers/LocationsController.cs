using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Launchpad7New.Controllers
{
    public class LocationsController : Controller
    {

        public LocationsController()
        {
        }

        // GET: Locations
        public ActionResult Index() => View();

    }
}