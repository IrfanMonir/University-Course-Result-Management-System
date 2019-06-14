using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Gateway;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class StudentManager : Manager
    {
        public string Save(Student student)
        {
            bool isEmailExist = StudentGateway.IsEmailExist(student.Email);
            if (isEmailExist)
            {
                return "This email is already used";
            }
            else
            {
                RowAffect = StudentGateway.Save(student);
                return "Student register " + Message(RowAffect);
            }
        }
        public List<Student> GetAllStudents()
        {
            return StudentGateway.GetAllStudents();
        }

        public Student GetStudentByRegNo(int regNo)
        {
          Student student =  StudentGateway.GetStudentByRegNo(regNo);
            DepartmentGateway departmentGateway = new DepartmentGateway();
          student.Department=  departmentGateway.GetDepartmentCodeById(student.DepartmentId);
            return student;
        }

        public string GetRegNo(string regNo)
        {
            string RegNo = null;

            string num = StudentGateway.GetRegNo(regNo);
            int number = Convert.ToInt32(num);
            number++;

            if (number >= 0 & number < 10)
            {
                RegNo = "00" + number;

            }
            else if (number > 9 & number < 100)
            {
             RegNo = "0" +number;
            }
            else
            {
                RegNo = "" + number;
            }
            return regNo + RegNo;
        }

        public string GetRegNoByStudent(Student student)
        {
            string date = student.Date.ToString();
            string sub = null;
            int temp = 0;
            if (date[1] == '/')
            {
                if (date[3] == '/')
                {
                    temp = 4;
                }
                else
                {
                    temp = 5;
                }
            }
            else
            {
                if (date[4] == '/')
                {
                    temp = 5;
                }
                else
                {
                    temp = 6;
                }
            }
            sub = date.Substring(temp, 4);
            DepartmentGateway departmentGateway = new DepartmentGateway();

            string department = departmentGateway.GetDepartmentCodeById(student.DepartmentId);

          //  string sub2 = department.Substring(0, 3);

            string substring = department + "-" + sub + "-";
            return GetRegNo(substring);
        }
        public List<StudentResultViewModel> GetAllCourseResult(int studentId)
        {
            return StudentGateway.GetAllCourseResult(studentId);
        }

        public Student GetStudentInfoForPdf(Student aStudent)
        {
            return StudentGateway.GetStudentInfoForPdf(aStudent);
        }

    }
}