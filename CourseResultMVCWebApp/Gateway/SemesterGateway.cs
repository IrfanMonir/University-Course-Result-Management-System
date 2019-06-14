using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class SemesterGateway : BaseGateway
    {
        public List<Semester> GetAllSemestersInfo()
        {
            Query = "SELECT * FROM Semester";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> getAllSemestersInfo = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };


                getAllSemestersInfo.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();


            return getAllSemestersInfo;

        }

       
    }
}