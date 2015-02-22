using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;
using System.IO;
namespace IntelligentBusSystem.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/
        public ActionResult Profile(string user="")
        {
            using (var context = new IntelligentBusSystemEntities())
            
            {
                //Requesting Personal Profile
                if (user == "")
                {
                    var u = context.SUsers.Find(User.Identity.Name);
                    return View((SUser)u);
                }

                    //Requesting Specific Profile
                else
                {
                    var u = context.SUsers.Find(user);
                    if (u != null) return View((SUser)u);
                    else return Redirect("/");
                }
            }
        }


      
    }
}