using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();
        private DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string GetDepartmentById(int Id)
        {
            return departmentGateway.GetDepartmentById(Id);
        }
        public string GetDepartmentCodeById(int Id)
        {
          return  departmentGateway.GetDepartmentCodeById(Id);
        }
        //Irfan 
        public List<Department> GetAllDepartmentsInfo()
        {
            return aDepartmentGateway.GetAllDepartmentsInfo();
        }
        public string Save(Department department)
        {
            bool isCodeExist = departmentGateway.IsCodeExist(department.Code);
            bool isNameExist = departmentGateway.IsNameExist(department.Name);
            if (isCodeExist == true)
            {
                return "Code Already Exists";
            }
            else if (isNameExist == true)
            {
                return "Name Already Exists";
            }
            else
            {
                int rowAffect = departmentGateway.Save(department);
                if (rowAffect > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "Saved failed";

                }
            }

        }

        //proma
        public List<Department> GetAll()
        {
           return departmentGateway.GetAll();
        }
    }
}