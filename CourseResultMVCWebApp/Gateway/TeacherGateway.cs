using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class TeacherGateway : BaseGateway
    {
        public int SaveTeacher(Teacher aTeacher)
        {
            Query = "Insert INTO Teacher(Name,Address,Email,ContactNumber,CreditToBeTaken,RemainingCredit,DesignationId,DepartmentId) VALUES ('" + aTeacher.Name + "','" + aTeacher.Address + "','" + aTeacher.Email + "','" + aTeacher.ContactNumber + "','" + aTeacher.CreditToBeTaken + "','" + aTeacher.CreditToBeTaken + "','" + aTeacher.DesignationId + "','" + aTeacher.DepartmentId + "')";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
        public Teacher IsUniqeEmail(string email)
        {
            Query = "SELECT * FROM Teacher WHERE Email = '" + email + "'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            Teacher aTeacher = new Teacher();

            if (!Reader.HasRows)
            {

                aTeacher = null;


            }

            Reader.Close();
            Connection.Close();
            return aTeacher;
        }
     
    
          public String GetTeacher(int courseId)
        {
            Command = new SqlCommand
            {
                CommandText = "SELECT Teacher.Name FROM CourseAssignTeacher cat INNER JOIN Teacher on cat.TeacherId = Teacher.Id Where cat.CourseId = '"+courseId+"' AND cat.Assign = '1'",
                Connection = Connection
            };

            Connection.Open();

            Reader = Command.ExecuteReader();
              string Name;

              if (Reader.Read())
            {
                Name = Reader["Name"].ToString();
           }
              else
              {
                  Name = "Not Assigned Yet";
              }

            Reader.Close();

            Connection.Close();

            return Name;
        }

    }
}