using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;

namespace CourseResultMVCWebApp.Controllers
{
    public class UnassignController : Controller
    {
        UnassignManager unassign = new UnassignManager();
        //
        // GET: /Unassign/
        [HttpGet]
        public ActionResult Unassign()
        {
          return View();
        }
        [HttpPost]
        public ActionResult Unassign(string msg)
        {
            string message1 = unassign.UnassignCoursetoTeacher();
            string message2 = unassign.UnassignRemainingCredit();
            string message3 = unassign.UnassignEnrollCourse();
            
   
            ViewBag.Message1 = message1;
            ViewBag.Message2 = message2;
            ViewBag.Message3 = message3;
            ViewBag.SuccessMessage = "Unassigned successfully";
            ViewBag.Message = "Do you want to delete?";

            return View();
        }
        [HttpGet]
        public ActionResult UnallocateRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnallocateRoom(string msg)
        {
            string message= unassign.UnallocateClassroom();
            ViewBag.Message = message;
            return View();
        }
	}
}