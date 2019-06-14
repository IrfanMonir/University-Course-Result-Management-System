using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class StudentResultGateway : BaseGateway
    {
        public int Save(StudentResult studentResult)
        {
            Query = " Update EnrollCourse Set Grade = '"+studentResult.Grade+"' WHERE studentId = '"+studentResult.StudentId+"' AND courseId = '"+studentResult.CourseId+"'  ";
           return GetRowAffect(Query);
        }
        //public int Update(StudentResult studentResult)
        //{
        //    string query = "UPDATE StudentsResult SET Grade = '"+studentResult.Grade+"' WHERE CourseId = " + studentResult.CourseId;
        //    return GetRowAffect(query);
        //}
        public bool IsCourseExist(int courseId)
        {
            string query = "SELECT * FROM StudentsResult WHERE CourseId = '" + courseId + "'";
            return GetIsExist(query);
        }

        public List<EnrollCourse> GetCourseByStudentId(int studentId)
        {
            Command = new SqlCommand
            {
                CommandText = " SELECT CourseId, Name FROM EnrollCourse as e FULL JOIN Course as c on c.Id = e.CourseId WHERE StudentId = '"+studentId+"' AND Assign = 'Yes'",
                Connection = Connection
            };
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollCourse> courses = new List<EnrollCourse>();
            while (Reader.Read())
            {
                EnrollCourse course = new EnrollCourse
                {
                    CourseId = (int) Reader["CourseId"],
                    Course = Reader["Name"].ToString()
                };
             
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

    }
}