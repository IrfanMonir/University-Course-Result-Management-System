using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway aCourseAssignGateway = new CourseAssignGateway();

        public string AssignCourseToTeacher(CourseAssignTeacher assignCourse)
        {
            if (aCourseAssignGateway.IsCourseAlreadyAssigned(assignCourse))
            {
                return "Course Already Assigned";
            }

            int rowAffected = aCourseAssignGateway.AssignCourseToTeacher(assignCourse);
            if (rowAffected > 0)
                return "Course assign successful";
            else
            {
                return "Course assign failed";
            }

        }
        public List<Teacher> GetAllTeachers()
        {
            return aCourseAssignGateway.GetAllTeachers();
        }
        public List<Course> GetAllCourses()
        {
            return aCourseAssignGateway.GetAllCourses();
        }
    }
}