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
                //ToFix
               
                if (s != null){
                      s.SchoolPhoneNumber=String.Format("{0:(+###) ##-######}", Convert.ToInt64(s.SchoolPhoneNumber));
                    return View(s);
                }
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


    public ActionResult SaveChanges(School model)
    {
        using (var context = new IntelligentBusSystemEntities())
        {
            School s = context.Schools.ToList().First();
            s.SchoolName=model.SchoolName;
            s.SchoolPhoneNumber =FormatToNumber(model.SchoolPhoneNumber);
            s.SchoolLat = model.SchoolLat;
            s.SchoolLong = model.SchoolLong;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }

    public string FormatToNumber(string s)
    {
        string num="";
        for (int i=0;i<s.Length;++i)
        {
            if(s[i]=='0' || s[i]=='1' || s[i]=='2' || s[i]=='3' || s[i]=='4' || s[i]=='5' || s[i]=='6' || s[i]=='7' || s[i]=='8' ||s[i]=='9')
            {
                num = num + s[i];
            }
        }
        return num;
    }
	}




}