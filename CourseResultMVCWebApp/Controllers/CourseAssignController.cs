using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class CourseAssignController : Controller
    {
        //
        // GET: /CourseAssign/
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseAssignManager aCourseAssignManager = new CourseAssignManager();

        public ActionResult CourseAssign()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult CourseAssign(CourseAssignTeacher assigncourse)
        {
            string msg = aCourseAssignManager.AssignCourseToTeacher(assigncourse);
            ModelState.Clear();
            ViewBag.Message = msg;
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();

            ViewBag.Departments = departments;
            return View();
        }
        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            List<Teacher> teachers = aCourseAssignManager.GetAllTeachers();
            List<Teacher> teacherList = teachers.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courses = aCourseAssignManager.GetAllCourses();
            List<Course> courseList = courses.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreditToBeTakenByTeacherId(int teacherId)
        {
            List<Teacher> teachers = aCourseAssignManager.GetAllTeachers();
            List<Teacher> teacherList = teachers.Where(a => a.Id == teacherId).ToList();
            //double CreditLimit = aTeacher.CreditLimit;
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseInfoByCourseId(int courseId)
        {
            List<Course> courses = aCourseAssignManager.GetAllCourses();
            List<Course> courseList = courses.Where(a => a.Id == courseId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);

        }

    }
}