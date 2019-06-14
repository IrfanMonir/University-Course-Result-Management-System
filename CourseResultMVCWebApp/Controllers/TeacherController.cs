using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        DepartmentManager aDepartmentManager = new DepartmentManager();
        DesignationManager aDesignationManager = new DesignationManager();
        TeacherManager aTeacherManager = new TeacherManager();
        public ActionResult SaveTeacher()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;

            List<TeacherDesignation> designations = aDesignationManager.GetAllDesignationsInfo();
            ViewBag.Designations = designations;
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;

            List<TeacherDesignation> designations = aDesignationManager.GetAllDesignationsInfo();
            ViewBag.Designations = designations;
            ViewBag.message = aTeacherManager.SaveTeacher(aTeacher);
            ViewBag.email = aTeacher.Email;
            return View();
        }
	}
}