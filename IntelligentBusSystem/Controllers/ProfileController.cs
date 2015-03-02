using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;
using System.IO;
using Newtonsoft.Json;
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

        public ActionResult DriverProfile(string driver = "")
        {
            using (var context = new IntelligentBusSystemEntities())
            {
                //Requesting Personal Profile
                if (driver == "")
                {
                     return Redirect("/");
                }

                    //Requesting Specific Profile
                else
                {
                    var u = context.Drivers.Find(driver);
                    if (u != null) return View((Driver)u);
                    else return Redirect("/");
                }
            }
        }

        public ActionResult StudentProfile(string student = "")
        {
            
                //Requesting Personal Profile
                if (student == "")
                {
                    return Redirect("/");
                }

                    //Requesting Specific Profile
                else
                {
                           using (var context = new SerializerContext())
                           {
                               IDCardGenerator idc = new IDCardGenerator();
                               idc.GetIDCard(student);
                    StudentProfileModel spm = new StudentProfileModel();

                    spm.Student = context.Students.Find(student);
                    spm.StudentClass = context.Classes.Find(spm.Student.ClassID);
                    spm.StudentAddresses = context.Addresses.Where(a => a.StudentID == student).ToList();
                    spm.StudentSubscriptions = context.Subscriptions.Where(a => a.StudentID == student).ToList();

                     
                    if (spm != null) return View(spm.Student);
                    else return Redirect("/");
                }

                }
            
        }
       
    }
}