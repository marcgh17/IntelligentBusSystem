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
    public class UserAccountsController : Controller
    {
        //
        // GET: /UserAccounts/
        public ActionResult Index()
        {
            return Redirect("/");
        }

        //Check if user is admin
        public static bool checkIfAdmin(string user)
        {
            using (var context = new IntelligentBusSystemEntities())
            {

                SUser u = context.SUsers.Find(user);
                if (u != null && u.SUserRole == "A") return true;
                else return false;
            }
        }

        //Open add User form
        public ActionResult AddUser()
        {
            if (checkIfAdmin(User.Identity.Name)) return View();
            else return Redirect("/");

        }

        //Submit A new User
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
                        return RedirectToAction("addUser", "Profile");

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
