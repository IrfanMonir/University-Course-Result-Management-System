using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class CourseAssignGateway :BaseGateway
    {
        public int AssignCourseToTeacher(CourseAssignTeacher assignCourse)
        {
            Query = "INSERT INTO CourseAssignTeacher Values('" + assignCourse.DepartmentId + "','" + assignCourse.TeacherId + "','" + assignCourse.CourseId + "','1')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            UpdateTeacherRemainingCredit(assignCourse);

            return rowAffected;

        }

        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM Teacher";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();

                aTeacher.Id = (int)Reader["Id"];
                aTeacher.Name = Reader["Name"].ToString();
                aTeacher.Address = Reader["Address"].ToString();
                aTeacher.ContactNumber = Reader["ContactNumber"].ToString();
                aTeacher.Email = Reader["Email"].ToString();
                aTeacher.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                aTeacher.DepartmentId = (int)Reader["DepartmentId"];

                aTeacher.CreditToBeTaken = Convert.ToDecimal(Reader["CreditToBeTaken"]);
                aTeacher.RemainingCredit = Convert.ToDecimal(Reader["RemainingCredit"]);
                teachers.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
        public List<Course> GetAllCourses()
        {
            Query = "Select * From Course";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.Id = (int)Reader["Id"];
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Credit = Convert.ToDecimal(Reader["Credit"]);
                aCourse.Description = Reader["Description"].ToString();
                aCourse.DepartmentId = (int)Reader["DepartmentId"];
                aCourse.SemesterId = (int)Reader["SemesterId"];
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
        public bool IsCourseAlreadyAssigned(CourseAssignTeacher courseAssign)
        {
            Query = "SELECT * FROM  CourseAssignTeacher  Where CourseId = '" + courseAssign.CourseId + "' AND  Assign = 'Yes'";
            return GetIsExist(Query);
          
        }

        public int UpdateTeacherRemainingCredit(CourseAssignTeacher courseAssign)
        {
            double courseCredit = 0;
            Query = "SELECT Credit FROM Course Where Id = '" + courseAssign.CourseId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courseCredit = Convert.ToDouble(Reader["Credit"]);
            }
            Reader.Close();
            Connection.Close();

            Query = "Update Teacher Set RemainingCredit = RemainingCredit - '" + courseCredit + "' Where Id = '" + courseAssign.TeacherId + "'";
            return GetRowAffect(Query);
        }
        
    }
}