using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class EnrollManager
    {
        EnrollGateway enrollGateway = new EnrollGateway();
        EnrollGateway aEnrollCourseGateway = new EnrollGateway();
        CourseAssignGateway acoursAssignGateway = new CourseAssignGateway();

        public string Save(EnrollCourse enrollCourse)
        {
            if (aEnrollCourseGateway.AlreadyEnrolledInCourse(enrollCourse))
                return "Course already enrolled";
            else
            {
                int rowAffected = aEnrollCourseGateway.Save(enrollCourse);
                if (rowAffected > 0)
                {
                    return "Enrolled Successfully";
                }
                else
                {
                    return "Enrolled Failed";
                }
            }

        }
        public Student GetStudentByRegNo(int regNo)
        {
            Student student = aEnrollCourseGateway.GetStudentByRegNo(regNo);
            student.Department = aEnrollCourseGateway.GetDepartmentCodeById(student.DepartmentId);
            return student;
        }


        public List<Student> GetAllStudents()
        {
            return aEnrollCourseGateway.GetAllStudents();
        }

        public string GetDepartmentById(int Id)
        {
            return aEnrollCourseGateway.GetDepartmentById(Id);
        }
        public List<Course> GetAllCourses()
        {
            return acoursAssignGateway.GetAllCourses();
        }
       
        public string UnassignCourses()
        {
            int rowAffect = enrollGateway.UnassignCourses();
            if (rowAffect > 0)
            {
                return "Unassigned successfully";
            }
            else
            {
                return "Unassigned failed";
            }
        }

       
    }
}