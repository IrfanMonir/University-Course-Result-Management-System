using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        //
        // GET: /EnrollCourse/
        EnrollManager aEnrollCourseManager = new EnrollManager();
        CourseAssignManager aCourseAssignManager = new CourseAssignManager();
        public ActionResult EnrollCourse()
        {
            List<Student> students = aEnrollCourseManager.GetAllStudents();
            ViewBag.Students = students;
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {
            List<Student> students = aEnrollCourseManager.GetAllStudents();
            ViewBag.Students = students;
            ViewBag.Message = aEnrollCourseManager.Save(enrollCourse);
            return View();
        }

        public JsonResult GetStudentByRegNo(int studentId)
        {
            Student student = aEnrollCourseManager.GetStudentByRegNo(studentId);

            return Json(student);
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            List<Course> courses = aCourseAssignManager.GetAllCourses();
            Student student = aEnrollCourseManager.GetStudentByRegNo(studentId);
            List<Course> courseList = courses.Where(a => a.DepartmentId == student.DepartmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);

        }


	}
}