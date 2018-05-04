 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    public enum EnumAlarmType
    {
        //        i_AlarmType
        //1.检修超期告警
        MaintainTimeOutAlarm = 1,
        //2.报废超期告警
        ScrapTimeOutAlarm = 2,
        //3.供车不及时告警（计划供车时间）
        GiveTimeOutAlarm = 3,
        //4.装车不及时告警（接车的一段时间后）
        LoadTimeOutAlarm = 4,
        //5.未按时运送告警（计划到达时间）
        TransportTimeOutAlarm = 5,
        //6.卸车不及时告警（到达后一定时间不卸车的）
        UnLoadTimeOutAlarm = 6,
        //7.还车不及时告警（到达后一定时间不还车的）
        BackTimeOutAlarm = 7,
        //8.闲置告警（在基站下停留超时）
        NoUseAlarm = 8,
        //9.运行方向不正确告警（见地点管理）
        RunDerictionAlarm = 9,
        //10.未置换状态（到达目的地后，空重车状态没有变化就离开）
        NoChanageStateAlarm = 10
    }
}
