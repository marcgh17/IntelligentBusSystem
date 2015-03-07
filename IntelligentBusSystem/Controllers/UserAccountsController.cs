using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;


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
                            string databasePath = "/Images/Users/" + model.FirstName+  Guid.NewGuid()+ Path.GetFileName(uploadFile.FileName);
                            string databasePathThumb = "/Images/Users/thumb_" + model.FirstName + Guid.NewGuid() + Path.GetFileName(uploadFile.FileName);

                            string filePath = HttpContext.Server.MapPath(databasePath);
                            uploadFile.SaveAs(filePath);
                            newuser.SUserPhoto = databasePath;
                            using (Bitmap originalImage = new Bitmap(filePath))
                            {
                               
                                int width = 100;
                                int height = 100;
                                System.Drawing.Image.GetThumbnailImageAbort thumbnailImageAbortDelegate = new System.Drawing.Image.GetThumbnailImageAbort(Class.ThumbnaiHelper.ThumbnailCallback);
                                System.Drawing.Image thumbnail = originalImage.GetThumbnailImage(width, height, thumbnailImageAbortDelegate, IntPtr.Zero);
                                thumbnail.Save(Server.MapPath(databasePathThumb));
                                newuser.SUserThumbPhoto = databasePathThumb;

                            }

                        }
                        else
                        {
                            string databasePath = "/Images/Users/nophoto.png";
                            string databasePathThumb = "/Images/Users/thumb_nophoto.png";
                            newuser.SUserPhoto = databasePath;
                            newuser.SUserThumbPhoto = databasePathThumb;

                        }
                        context.SUsers.Add(newuser);
                        context.SaveChanges();
                        //UserAdded
                        //Put After Add Code Here
                        return RedirectToAction("addUser", "UserAccounts");

                    }

                    else
                    {
                        ModelState.AddModelError("", "Username already exists!");
                    }

                }
            }


            return View(model);
        }

        // GET: /Profile/
        public ActionResult Profile(string user = "")
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
       

           //Open add Parent form
          
          

         
        public ActionResult DisplayAllUsersGrid()
        {
           using (var context = new IntelligentBusSystemEntities())
           {
               return PartialView("UsersGrid", context.SUsers.ToList());
           }
        }
   

     
        }
    }
