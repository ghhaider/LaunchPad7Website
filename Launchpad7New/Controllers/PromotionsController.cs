﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Launchpad7New.Controllers
{
    public class PromotionsController : Controller
    {
        public PromotionsController()
        {
        }

        // GET: Promotions
        public ActionResult Index() => View();
    }
}