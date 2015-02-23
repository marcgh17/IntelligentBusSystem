using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;

namespace IntelligentBusSystem.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        //
        // GET: /Menu/
        public ActionResult Index()
        {
            if(!Request.IsAuthenticated)
            return PartialView("_Menu",GetMenuItems("A"));
            else
                return PartialView("_Menu", GetMenuItems("A"));
        }


        public List<CustomMenuItem> GetMenuItems(string role)
        {
            List<CustomMenuItem> menus=new List<CustomMenuItem>();
            using (var context = new IntelligentBusSystemEntities())
            {
                List<WebAppMenu> dbMainMenus = context.WebAppMenus.Where(c=>c.WebAppMenuParent==0).OrderBy(c => c.WebAppMenuPosition).ToList();
                foreach (var dbMM in dbMainMenus)
                {
                    CustomMenuItem mm = new CustomMenuItem();
                    mm.Menu = dbMM;
                    mm.subMenus = context.WebAppMenus.Where(c => c.WebAppMenuParent==dbMM.WebAppMenuID).OrderBy(c => c.WebAppMenuPosition).ToList();
                    menus.Add(mm);

                }
            }
            return menus;

        }
	}
}