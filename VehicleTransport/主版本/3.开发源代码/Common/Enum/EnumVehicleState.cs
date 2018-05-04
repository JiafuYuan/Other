using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    /// <summary>
    /// 车辆状态
    /// </summary>
    public enum EnumVehicleState
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal=0,
        /// <summary>
        /// 使用中
        /// </summary>
        Using=1,
        /// <summary>
        /// 维护中
        /// </summary>
        Maintaining=2,
        /// <summary>
        /// 已报废
        /// </summary>
        Scrap=3
    }
}
