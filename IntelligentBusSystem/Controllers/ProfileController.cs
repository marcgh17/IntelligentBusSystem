using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;
namespace IntelligentBusSystem.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/
        public ActionResult Profile()
        {
            using (var context = new IntelligentBusSystemEntities())
            {
                var us=User.Identity.Name;
                var user = context.SUsers.Find(us);
                return View((SUser)user);
            }
        }
        public ActionResult AddUser()
        {
            return View();
        }
	}
}