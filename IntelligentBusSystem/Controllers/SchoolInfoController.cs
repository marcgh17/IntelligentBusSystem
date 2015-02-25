using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;

namespace IntelligentBusSystem.Controllers
{[Authorize]
    public class SchoolInfoController : Controller
    {
        //
        // GET: /SchoolInfo/
        public ActionResult Index()
        {
            if(!UserAccountsController.checkIfAdmin(User.Identity.Name)) return Redirect("/");
            using (var context = new IntelligentBusSystemEntities())
            {

                School s = context.Schools.ToList().First();
                s.SchoolPhoneNumber = FormatPhoneNumber(s.SchoolPhoneNumber);
                if (s != null)
                    return View(s);
                else
                    return View();
            }
           
        }
[AllowAnonymous]
        public ActionResult Header()
        {
            using (var context = new IntelligentBusSystemEntities())
            {

                School s = context.Schools.ToList().First();
                if (s != null)
                    return PartialView("SchoolHeader", s);
                else
                    return PartialView("SchoolHeader");
            }

        }

    public string FormatPhoneNumber(string pn)
{
    return "";
}


	}


}