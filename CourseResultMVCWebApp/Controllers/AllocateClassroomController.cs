using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseResultMVCWebApp.Manager;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Controllers
{
    public class AllocateClassroomController : Controller
    {

        AllocateClassroomManager manager = new AllocateClassroomManager();
        DepartmentManager departmentManager = new DepartmentManager();
        RoomManager roomManager = new RoomManager();
        //
        // GET: /AllocateClassroom/
        public ActionResult SaveRoom()
        {
          
            AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
            ViewBag.Departments = departmentManager.GetAll();
            ViewBag.Rooms = allocateClassroomManager.GetAllRoom();
            return View();

        }
        public JsonResult GetCoursesByDepartment(int DepartmentId)
        {
           List<Course> courses =manager.GetCourseByDepartment(DepartmentId);
            return Json(courses);
        }
        [HttpPost]

        public ActionResult SaveRoom(AllocateClassroom allocateClassroom)
        {
            
          
            ViewBag.Departments = departmentManager.GetAll();
            ViewBag.Rooms = manager.GetAllRoom();
          allocateClassroom.Allocate = "Yes";
            ViewBag.msg = manager.Save(allocateClassroom);
            return View();
        }
        public ActionResult ShowRoom()
        {

            ViewBag.Departments = departmentManager.GetAll();
            // ViewBag.Departments = GetDepartmentForDropDownList();

            //ViewBag.ClassSchedule = aClassRoomManager.GetAllAllocatedClassRoomWithout();
            return View();
        }
        [HttpPost]
        public ActionResult ShowRoom(ClassRoom classRoom)
        {
            ViewBag.Departments = departmentManager.GetAll();
            //ViewBag.Departments = GetDepartmentForDropDownList();
            /*List<Course> courses = aClassRoomManager.GetAllCourses(classRoom);
            ViewBag.Courses = courses;
            foreach (Course course in courses)
            {
                List<ClassRoom> classRooms = aClassRoomManager.GetAllClassRooms(course);
                ViewBag.ClassRooms = classRooms;
                return View();
            }*/

            return View();
        }
        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = manager.GetCourseByDepartment(departmentId);
            
            List<Course> courseDetails = new List<Course>();
            foreach (Course course in courses)
            {
                List<ClassRoom> classRooms = roomManager.GetAllClassRooms(course.Id);
                if (classRooms.Count < 1)
                {
                    course.RoomInfo = "Not scheduled yet";

                }
                else
                {
                    foreach (ClassRoom room in classRooms)
                    {
                        course.RoomInfo += "R No: " + room.RoomNo + ", " + room.Day + ", " + room.FromTime + "-" +
                                           room.ToTime + "; </br> ";
                    }
                }
       
               
                courseDetails.Add(course);
            }

            return Json(courseDetails);
        }
	}
}