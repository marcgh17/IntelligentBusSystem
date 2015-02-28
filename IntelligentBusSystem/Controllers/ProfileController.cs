﻿using System;
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
            using (var context = new IntelligentBusSystemEntities())
            {
                //Requesting Personal Profile
                if (student == "")
                {
                    return Redirect("/");
                }

                    //Requesting Specific Profile
                else
                {
                    StudentProfileModel spm = new StudentProfileModel();
                    
                    spm.student = context.Students.Find(student);
                    spm.studentclass = context.Classes.Find(spm.student.ClassID);
                    spm.studentaddresses = context.Addresses.Where(a => a.StudentID == student).ToList();
                  //  var tuple = new Tuple<Student, Class, IEnumerable<Address>>(stud, sclass, add);
                    if (spm != null) return View(spm);
                    else return Redirect("/");
                }
            }
        }
        public ActionResult DisplaySchedule()
        {
            using (var context = new IntelligentBusSystemEntities())
            {
                var stud=context.Students.Find(User.Identity.Name);
                var sched=context.Schedules.ToList();
                var sub=context.Subscriptions.ToList();

                var tuple = new Tuple<Student, IEnumerable<Schedule>, IEnumerable<Subscription>>(stud, sched, sub);
                return PartialView("DisplaySchedule", tuple);
            }
        }
    }
}