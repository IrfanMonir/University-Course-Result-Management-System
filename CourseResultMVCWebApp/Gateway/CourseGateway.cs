using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class CourseGateway : BaseGateway
    {
        public int SaveCourse(Course aCourse)
        {
            Query = "Insert INTO Course(Code, Name, Credit, SemesterId, Description, DepartmentId) VALUES ('" + aCourse.Code + "','" + aCourse.Name + "','" + aCourse.Credit + "','" + aCourse.SemesterId + "','" + aCourse.Description + "','" + aCourse.DepartmentId + "')";
            return GetRowAffect(Query);
        }

        public Course IsUniqeCode(string code)
        {
            Query = "SELECT * FROM Course WHERE Code = '" + code + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            Course aCourse = new Course();

            if (!Reader.HasRows)
            {
                aCourse = null;
               }

            Reader.Close();
            Connection.Close();
            return aCourse;
        }

        public Course IsUniqeName(string name)
        {
            Query = "SELECT * FROM Course WHERE Name = '" + name + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            Course aCourse = new Course();

            if (!Reader.HasRows)
            {
                aCourse = null;
              }

            Reader.Close();
            Connection.Close();
            return aCourse;
        }
      //  proma
        public List<CourseStaticViewModel> GetCourseStatic(int? departmentId)
        {
            Command = new SqlCommand
            {
                CommandText = "SELECT * FROM CourseView WHERE DepartmentId = '" + departmentId + "'",
                Connection = Connection
            };

            Connection.Open();

            Reader = Command.ExecuteReader();
            
            List<CourseStaticViewModel> courseStatics = new List<CourseStaticViewModel>();
            
            while (Reader.Read())
            {
                CourseStaticViewModel courseStatic = new CourseStaticViewModel
                {
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Semester = Reader["Semester"].ToString(),
                    AssignedTo = Reader["AssignedTo"].ToString(),
                    Assign = Reader["Assign"].ToString(),
                    DepartmentId = (int)Reader["DepartmentId"],
                };

                courseStatics.Add(courseStatic);
            }
            
            Reader.Close();
            
            Connection.Close();

            return courseStatics;
        }
        public List<Course> GetAllCourses(int departmentId)
        {
            Command = new SqlCommand
            {
                CommandText = "SELECT * FROM Course WHERE DepartmentId = '" + departmentId + "'",
                Connection = Connection
            };

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course course = new Course
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    SemesterId = (int)Reader["SemesterId"],
                    Description = Reader["Description"].ToString(),
                    DepartmentId = (int)Reader["DepartmentId"],
                };

                courses.Add(course);
            }

            Reader.Close();

            Connection.Close();

            return courses;
        }
        
    }
}