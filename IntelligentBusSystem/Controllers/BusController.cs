using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntelligentBusSystem.Models;

namespace IntelligentBusSystem.Controllers
{
    public class BusController : Controller
    {
        //
        // GET: /Bus/
        public ActionResult MonitorBuses()
        {
            using (var context = new SerializerContext())
            {
                List<Bus> buses= context.Buses.ToList();
                return View(buses);
            }
            
        }
	}
}