using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using IntelligentBusSystem.Models;

namespace IntelligentBusSystem.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
           // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated) return  RedirectToAction("Index","Home");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (model.Password == model.UserName)
                {
                    FormsAuthentication.SetAuthCookie(
                        model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);

                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }

            }
             return View(model);
            
        }

           
           
        
       

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
    }
