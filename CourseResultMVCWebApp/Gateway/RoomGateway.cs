using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Gateway
{
    public class RoomGateway :BaseGateway
    {
        public List<ClassRoom> GetAllClassRooms(int id)
        {
            Query ="SELECT r.RoomNo,a.Day,a.FromTime,a.ToTime FROM AllocateClassroom as a  INNER JOIN Room as r ON r.Id = a.RoomId WHERE a.CourseId ='"+id+"' AND Allocate = 'Yes'";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ClassRoom> classRooms = new List<ClassRoom>();
            while (Reader.Read())
            {
                ClassRoom aClassRoom = new ClassRoom();
                aClassRoom.RoomNo = Reader["RoomNo"].ToString();
                aClassRoom.Day = Reader["Day"].ToString();
                aClassRoom.FromTime =Reader["FromTime"].ToString();
                aClassRoom.ToTime = Reader["ToTime"].ToString();
                
                classRooms.Add(aClassRoom);
            }

            Reader.Close();
            Connection.Close();
            return classRooms;
        }
    }
}