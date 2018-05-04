using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace VehicleTransportServer.BLL
{
    public class SetSystemTime
    {
        //imports SetLocalTime function from kernel32.dll 
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int SetLocalTime(ref SystemTime lpSystemTime);

        //struct for date/time apis 
        public struct SystemTime
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        // And then set up a structure with the required properties and call the api from code: 
        public static void SetTime()
        {
            DateTime dt = new DB_VehicleTransportManage.BLL.m_SystemConfig().GetDBTime();
            SystemTime systNew = new SystemTime();

            // 设置属性 
            systNew.wDay =(short) dt.Day;
            systNew.wMonth = (short)dt.Month;
            systNew.wYear = (short)dt.Year;
            systNew.wHour = (short)dt.Hour;
            systNew.wMinute = (short)dt.Minute;
            systNew.wSecond = (short)dt.Second ;

            // 调用API，更新系统时间 
            SetLocalTime(ref systNew);
        }
    }
}

