using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class DesignationGateway :BaseGateway
    {
        public List<TeacherDesignation> GetAllDesignationsInfo()
        {
            Query = "SELECT * FROM Designation";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TeacherDesignation> getAllDesignationsInfo = new List<TeacherDesignation>();
            while (Reader.Read())
            {
                TeacherDesignation aDesignation = new TeacherDesignation()
                {
                    Id = (int)Reader["Id"],
                    Designation = Reader["Designation"].ToString()
                };


                getAllDesignationsInfo.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();


            return getAllDesignationsInfo;

        }
    }
}