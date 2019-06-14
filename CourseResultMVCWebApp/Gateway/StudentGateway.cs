using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class StudentGateway : BaseGateway
    {
        public int Save(Student student)
        {
            string query = "INSERT INTO Student(Name, Email, ContactNumber, Date, Address, DepartmentId, RegNo) VALUES " +
                           "('" + student.Name + "','" + student.Email + "','" + student.ContactNumber + "','" + student.Date + "','" + student.Address + "','" + student.DepartmentId + "','"+student.RegNo+"')";
            return GetRowAffect(query);
        }

        public bool IsEmailExist(string email)
        {
            string query = "SELECT * FROM Student WHERE Email = '" + email + "'";
            return GetIsExist(query);
          
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
            string query = "SELECT * FROM Student";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();

            while (Reader.Read())
            {
                Student student = new Student
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNumber = Reader["ContactNumber"].ToString(),
                    Address = Reader["Address"].ToString(),
                    Date = (DateTime)Reader["Date"],
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"]),
                    RegNo = Reader["RegNo"].ToString()
                };
                students.Add(student);
           }
            Connection.Close();
            return students;
        }

        public string GetRegNo(string regNo)
        {
            Query = "SELECT Count(RegNo) as Number FROM Student WHERE RegNo LIKE '%" + regNo + "%'";
            Command = new SqlCommand(Query, Connection);
            string number = null;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isRowExist = Reader.HasRows;
            if (isRowExist)
            {
                if (Reader.Read())
                {
                    number = Reader["Number"].ToString();
                }

            }

            Connection.Close();
            return number;
        }

        public List<StudentResultViewModel> GetAllCourseResult(int studentId)
        { 
            Query ="Select  c.Code, c.Name, ce.Grade from EnrollCourse ce inner join Course c on c.Id = ce.CourseId where ce.StudentId ="+studentId + " AND ce.Assign = '1'";

            Command = new SqlCommand(Query, Connection);
          
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentResultViewModel> studentResults = new List<StudentResultViewModel>();
            while (Reader.Read())
            {
                StudentResultViewModel studentResult = new StudentResultViewModel();
                studentResult.CourseCode = Reader["Code"].ToString();
                studentResult.CourseName = Reader["Name"].ToString();
                studentResult.Grade = Reader["Grade"].ToString();
                if (studentResult.Grade == "")
                {
                    studentResult.Grade = "Not Graded Yet";
                }
                studentResults.Add(studentResult);
            }
            Reader.Close();
            Connection.Close();
            return studentResults;
        }
        public Student GetStudentInfoForPdf(Student aStudent)
        {
            Query = "SELECT s.Name,s.Email,s.ContactNumber,s.Address,d.Name as Department,s.RegNo FROM Student s INNER JOIN Department d ON d.Id = s.DepartmentId WHERE s.Id = " +aStudent.Id;
            Command = new SqlCommand(Query, Connection);
         
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student student = null;
            while (Reader.Read())
            {
                student = new Student();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
                student.ContactNumber = Reader["ContactNumber"].ToString();
                student.Address = Reader["Address"].ToString();
                student.Department = Reader["Department"].ToString();
                student.RegNo = Reader["RegNo"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }
    }
}