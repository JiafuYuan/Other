using System;
using System.Collections.Generic;
using System.Text;

namespace Bestway
{
    /// <summary>
    /// 传感器类型
    /// </summary>
    public enum EnumSensorType
    {
        Unknow = -1,        //未知
        Production = 0,     //产量
        Wind = 1,           //风量
        Water = 2,          //水量
        Power = 3           //电量
    }

    /// <summary>
    /// 传感器状态
    /// </summary>
    public enum EnumSensorState
    {
        UnKnow = -1,
        Online = 0,
        Unline = 1
    }

    /// <summary>实时数据</summary>
    [Serializable]
    public class SensorMode
    {
        public int SensorID { get; set; }
        public int DeptID { get; set; }
        public int AreaID { get; set; }
        public EnumSensorType Type { get; set; }
        public float RealData { get; set; }
        public float TotalData { get; set; }
        public EnumSensorState State { get; set; }
        public DateTime DataTime { get; set; }
    }


}
