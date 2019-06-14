using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class EnrollGateway : BaseGateway
    {
        public int Save(EnrollCourse enrollCourse)
        {
            Query = "Insert Into EnrollCourse(CourseId, Date, StudentId,Assign)" +
                    "Values ('" + enrollCourse.CourseId + "','" + enrollCourse.Date + "','" + enrollCourse.StudentId + "','1')";
            return GetRowAffect(Query);
          
        }
        public Student GetStudentByRegNo(int regNo)
        {
            string query = "SELECT Name, Email, DepartmentId FROM Student Where Id='" + regNo + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student student = null;
            if (Reader.Read())
            {
                student = new Student
                {
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"])
                };

            }
            Connection.Close();
            return student;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT * FROM  Student";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Student> students = new List<Student>();

            while (Reader.Read())
            {
                Student aStudent = new Student
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Address = Reader["Address"].ToString(),
                    ContactNumber = Reader["ContactNumber"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Date = Convert.ToDateTime(Reader["Date"]),
                    DepartmentId = (int) Reader["DepartmentId"],
                    RegNo = Reader["RegNo"].ToString()
                };



                students.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }
        public string GetDepartmentById(int Id)
        {
            string query = "SELECT Name From Department Where Id = " + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department department = null;
            if (Reader.Read())
            {
                department = new Department()
                {
                    Name = Reader["Name"].ToString()
                };
            }
            Connection.Close();
            return department.Name;
        }

        public string GetDepartmentCodeById(int Id)
        {
            string query = "SELECT Code From Department Where Id = " + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department department = null;
            if (Reader.Read())
            {
                department = new Department()
                {
                    Name = Reader["Code"].ToString()
                };
            }
            Connection.Close();
            return department.Name;
        }

        public bool AlreadyEnrolledInCourse(EnrollCourse enrollCourse)
        {
            Query = "Select * From EnrollCourse Where StudentId = '" + enrollCourse.StudentId + "' And CourseId = '" + enrollCourse.CourseId + "' And Assign = 'yes'";
            return GetIsExist(Query);
          
        }


        public int UnassignCourses()
        {
            string query = "UPDATE EnrollCourse SET Assign = 'No'";
            return GetRowAffect(Query);
        }
    }
}