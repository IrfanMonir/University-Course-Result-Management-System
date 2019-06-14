using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        CourseManager aCourseManager = new CourseManager();
        public ActionResult SaveCourse()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;

            List<Semester> semesters = aSemesterManager.GetAllSemestersInfo();
            ViewBag.Semesters = semesters;
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;

            List<Semester> semesters = aSemesterManager.GetAllSemestersInfo();
            ViewBag.Semesters = semesters;

            ViewBag.message = aCourseManager.SaveCourse(aCourse);

            ViewBag.code = aCourse.Code;
            ViewBag.name = aCourse.Name;
            return View();
        }

        public ActionResult ViewCourseStatic(int? DepartmentId)
        {
            List<Department> departments = aDepartmentManager.GetAllDepartmentsInfo();
            ViewBag.Departments = departments;
            return View();
        }
        public JsonResult GetCourseStatic(int departmentId)
        {
            TeacherManager teacherManager = new TeacherManager();
           CourseManager courseManager =new CourseManager();
            List<Semester> semesters = aSemesterManager.GetAllSemestersInfo();
            
            var courses = courseManager.GetAllCourses(departmentId);
            foreach (Course course in courses)
            {
                Semester semester = semesters.Find(p => p.Id ==course.SemesterId);
                course.Semester = semester.Name;
             course.AssignedTo=   teacherManager.GetTeacher(course.Id);
            }
            return Json(courses);
        }
    }
}