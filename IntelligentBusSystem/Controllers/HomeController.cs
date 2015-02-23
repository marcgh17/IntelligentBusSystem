﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentBusSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           // ViewBag.Message = "Your application description page.";

           // return PartialView("_LoginPartial");
           return View();
        }

        public ActionResult Contact()
        {
            ViewBag.UserName = User.Identity.Name;
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}