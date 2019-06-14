using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class AllocateClassroomGateway : BaseGateway
    {
        public int Save(AllocateClassroom allocate)
        {
            Query = "INSERT INTO AllocateClassroom (DepartmentId, CourseId, RoomId, FromTime, ToTime, Allocate, Day)" +
                             " VALUES ('" + allocate.DepartmentId + "','" + allocate.CourseId + "','" + allocate.RoomId + "','"
                             + allocate.FromTime + "','" + allocate.ToTime + "','" + allocate.Allocate + "','" + allocate.Day + "')";
            return GetRowAffect(Query);
        }
        //getCourseByDepartment
        public List<Course> GetCourseByDepartment(int departmentId)
        {
            string query = "SELECT Id, Name,Code FROM Course WHERE DepartmentId = " + departmentId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    Name = Reader["Name"].ToString(),
                    Code = Reader["Code"].ToString()

                };
                courses.Add(course);
            }
            Connection.Close();
            return courses;
        }

        //GetRoomNo
        public List<Room> GetAllRoom()
        {
            string query = "SELECT * FROM Room ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room()
                {
                    Id = Convert.ToInt32(Reader["Id"]),
                    RoomNo = Reader["RoomNo"].ToString()
                };
                rooms.Add(room);
            }
            Connection.Close();
            return rooms;
        }

        //public bool IsScheduleExist(AllocateClassroom allocate)
        //{
        //    return false;
        //}
        public List<AllocateClassroom> IsScheduleExists(AllocateClassroom allocate)
        {
            Query = "SELECT * FROM AllocateClassroom WHERE RoomId = '" + allocate.RoomId + "' AND Day = '" + allocate.Day + "'" +
                    " AND Allocate ='" + allocate.Allocate + "' ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<AllocateClassroom> allocateClassrooms = new List<AllocateClassroom>();

            if (Reader.Read())
            {
                AllocateClassroom classroom = new AllocateClassroom()
                {
                    FromTime = Reader["FromTime"].ToString(),
                    ToTime = Reader["ToTime"].ToString()
                };
                allocateClassrooms.Add(classroom);
            }
            Reader.Close();
            Connection.Close();
            return allocateClassrooms;
        }
    }
}