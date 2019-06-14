using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        StudentManager manager = new StudentManager();
        StudentResultManager studentResultManager = new StudentResultManager();
        //
        // GET: /StudentResult/
        public ActionResult SaveResult()
        {
            ViewBag.Students = manager.GetAllStudents();
            return View();
        }
       
        public JsonResult GetStudentByRegNo(int studentId)
        {
            Student student = manager.GetStudentByRegNo(studentId);
            return Json(student);
        }
        public JsonResult GetCourseByStudent(int studentId)
        {
           List<EnrollCourse> courses= studentResultManager.GetCourseByStudentId(studentId);
           
            return Json(courses);
        }
        [HttpPost]
        public ActionResult SaveResult(StudentResult studentResult)
        {

           string messege= studentResultManager.Save(studentResult);
           ViewBag.Message = messege;
            ViewBag.Students = manager.GetAllStudents();
            return View();
        }
	}
}