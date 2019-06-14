using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseResultMVCWebApp.Models;

namespace CourseResultMVCWebApp.Manager
{
    public class RoomManager : Manager
    {
        public string CheckAmPm(int time)
        {
            if (time >= 720)
            {
                return "PM";
            }
            else
            {
                return "AM";
            }
        }

        public int ChangeToHour(int time)
        {
            int hour = time / 60;
            if (hour > 12)
            {
                return hour - 12;
            }
            else
            {
                return hour;
            }

        }

        public string ChangeToMin(int time)
        {
            string Min = Convert.ToString(time % 60);
            if (Min.Length == 1)
            {
                Min = "0" + Min;
            }
            return Min;
        }
        public List<ClassRoom> GetAllClassRooms(int id)
        {
            List<ClassRoom> classRooms = room.GetAllClassRooms(id);
            foreach (ClassRoom classRoom in classRooms)
            {
                int fromTime = Convert.ToInt32(classRoom.FromTime);

                int fHr = ChangeToHour(fromTime);
                string fromMin = ChangeToMin(fromTime);
                string sFrom = CheckAmPm(fromTime);

                int toTime = Convert.ToInt32(classRoom.ToTime);

                int tHr = ChangeToHour(toTime);
                string toMin = ChangeToMin(toTime);
                string sTo = CheckAmPm(toTime);

                classRoom.FromTime = fHr + ":" + fromMin + " " + sFrom;
                classRoom.ToTime = tHr + ":" + toMin + " " + sTo;

               
            }
            return classRooms;
        }
    }
}