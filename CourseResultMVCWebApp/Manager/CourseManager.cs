using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class CourseManager : Manager
    {
        public string SaveCourse(Course aCourse)
        {
            if (courseGateway.IsUniqeCode(aCourse.Code) != null)
            {
                return "Code Already Exists";
            }

            if (courseGateway.IsUniqeName(aCourse.Name) != null)
            {
                return "Name Already Exists";
            }

            int rowAffected = courseGateway.SaveCourse(aCourse);

            if (rowAffected > 0)
            {
                return "Saved Successfully";
            }
            else
            {
                return "Saving Failed";
            }
        }

        public List<Course> GetAllCourses(int departmentId)
        {
           return courseGateway.GetAllCourses(departmentId);
         

        }
    }
}