using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CourseResultMVCWebApp.Gateway
{
    public class BaseGateway
    {

        public string ConnectionStirng =
           WebConfigurationManager.ConnectionStrings["CourseResultDBCon"].ConnectionString;


        public SqlConnection Connection;
        public BaseGateway()
        {
            Connection = new SqlConnection(ConnectionStirng);
        }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
         public String Query { get; set; }
        public int GetRowAffect(string query)
        {
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool GetIsExist(string query)
        {
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }
    }
}