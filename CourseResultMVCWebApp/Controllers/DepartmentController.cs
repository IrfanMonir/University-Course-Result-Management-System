using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        // GET: /Department/
        [HttpGet]
        public ActionResult SaveDept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDept(Department department)
        {
           string message = departmentManager.Save(department);
            ViewBag.Message = message;
            return View();
        }
        public ActionResult ShowDept()
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.Departments = departments;
            return View();
        }
	}
}