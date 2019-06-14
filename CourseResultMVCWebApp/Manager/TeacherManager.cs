using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class TeacherManager
    {
        public TeacherGateway ATeacherGateway = new TeacherGateway();

        public string SaveTeacher(Teacher aTeacher)
        {
            if (ATeacherGateway.IsUniqeEmail(aTeacher.Email) != null)
            {
                return "Email Already Exists";
            }
            int rowAffected = ATeacherGateway.SaveTeacher(aTeacher);
            if (rowAffected > 0)
            {
                return "Saved Successfully";
            }
            else
            {
                return "Saving Failed";
            }
        }

        public String GetTeacher(int courseId)
        {
          return  ATeacherGateway.GetTeacher(courseId);
        }

    }
}