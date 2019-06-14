using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class StudentResultManager : Manager
    {
        StudentResultGateway studentResultGateway = new StudentResultGateway();
        public string Save(StudentResult studentResult)
        {
                RowAffect = studentResultGateway.Save(studentResult);
            return "Student result saved " + Message(RowAffect);
            
        }
        public List<EnrollCourse> GetCourseByStudentId(int studentId)
        {
            return studentResultGateway.GetCourseByStudentId(studentId);
        }
    }
}