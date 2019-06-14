using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class DepartmentGateway : BaseGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department(Code,Name) VALUES ('" + department.Code + "','" + department.Name +"')";
            return GetRowAffect(query);
        }

        public List<Department> GetAll()
        {

            Command = new SqlCommand
            {
                CommandText = "SELECT * FROM Department",
                Connection = Connection
            };
            Connection.Open();
           Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department department = new Department
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };
                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }
        //Irfan vai GetDepartment Method

        public List<Department> GetAllDepartmentsInfo()
        {
            Query = "SELECT * FROM Department";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> getAllDepartmentsInfo = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department()
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };


                getAllDepartmentsInfo.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();


            return getAllDepartmentsInfo;
        }

        public bool IsCodeExist(string code)
        {
            string query = "SELECT * FROM Department WHERE Code = '" + code + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isCodeExist = Reader.HasRows;
            Connection.Close();
            return isCodeExist;
        }
        public bool IsNameExist(string name)
        {
            string query = "SELECT * FROM Department WHERE Name = '" + name + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isNameExist = Reader.HasRows;
            Connection.Close();
            return isNameExist;
        }
        public string GetDepartmentById(int Id)
        {
            string query = "SELECT Name From Department Where Id = "+Id;
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
                department = new Department();

                department.Code = Reader["Code"].ToString();

            }
            Connection.Close();
            return department.Code;
        }
    }
}