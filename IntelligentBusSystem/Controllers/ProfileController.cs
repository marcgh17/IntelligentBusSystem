using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;
using System.IO;
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
                var us = User.Identity.Name;
                var user = context.SUsers.Find(us);
                return View((SUser)user);
            }
        }
        public ActionResult AddUser()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddUser(SignUpViewModel model, HttpPostedFileBase uploadFile)
        {

            if (ModelState.IsValid)
            {
                using (var context = new IntelligentBusSystemEntities())
                {
                    SUser newuser = new SUser();
                    SUser olduser = context.SUsers.Find(model.UserName);
                    if (olduser == null)
                    {
                        newuser.SUserID = model.UserName;
                        newuser.SUserPassword = model.Password;
                        newuser.SUserFirstName = model.FirstName;
                        newuser.SUserLastName = model.LastName;
                        newuser.SUserRole = model.Role;
                        if (uploadFile != null)
                        {
                            string databasePath = "/img/Users/" + Path.GetFileName(uploadFile.FileName);
                            string filePath = HttpContext.Server.MapPath(databasePath);
                            uploadFile.SaveAs(filePath);
                            newuser.SUserPhoto = databasePath;

                        }
                        else
                        {
                            string databasePath = "/img/Users/nophoto.png";
                            newuser.SUserPhoto = databasePath;

                        }
                        context.SUsers.Add(newuser);
                        context.SaveChanges();
                        //UserAdded
                        //Put After Add Code Here
                        return View();

                    }
                        
                    else
                    {
                        ModelState.AddModelError("", "Username already exists!");
                    }

                }
            }

         
            return View(model);
        }
    }
}