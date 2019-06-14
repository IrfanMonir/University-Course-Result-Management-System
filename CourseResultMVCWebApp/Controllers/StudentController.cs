using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;
using Rotativa;

namespace CourseResultMVCWebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager manager = new StudentManager();
        private DepartmentManager departmentManager = new DepartmentManager();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveStudent()
        {
            ViewBag.Departments = departmentManager.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            ViewBag.Departments = departmentManager.GetAll();

            student.RegNo = manager.GetRegNoByStudent(student);

             TempData["student"] = student;

            ViewBag.Message = manager.Save(student);
           
            TempData["Email"] = student.Email;
            TempData.Keep();


            string a = TempData["Email"].ToString();
                return RedirectToAction("ShowStudentInfo", "Student");
          
            //return View();
        }

        public ActionResult ShowStudentInfo()
        {
           string Email = TempData["Email"].ToString();
           
           List<Student> students = manager.GetAllStudents();
            Student student = students.Find(p => p.Email == Email);
           student.Department= departmentManager.GetDepartmentById(student.DepartmentId);
            ViewBag.Student = student;
            return View();
        }
        public ActionResult ViewResult()
        {
            ViewBag.Students = manager.GetAllStudents();
            return View();
        }
        public JsonResult GetStudentByRegNo(int studentId)
        {
            Student student = manager.GetStudentByRegNo(studentId);
            return Json(student);
        }
     
        public ActionResult GeneratePdf(Student student)
        {
            student.Id = (int)TempData["Id"];
            TempData.Keep();
            ViewBag.Student = manager.GetStudentInfoForPdf(student);

            List<StudentResultViewModel> studentResults = manager.GetAllCourseResult(student.Id);
            ViewBag.Result = studentResults;
            return new ViewAsPdf("GeneratePdf", "Student")
            {
                FileName = "Result sheet.pdf"
            };
        }
        
       
        public JsonResult GetStudentResultByStudentId(int studentId)
        {
            TempData["Id"] = studentId;

            List<StudentResultViewModel> studentResults = manager.GetAllCourseResult(studentId);

            return Json(studentResults);
        }

    }
}