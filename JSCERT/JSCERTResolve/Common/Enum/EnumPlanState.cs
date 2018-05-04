using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    /// <summary>
    /// 计划状态
    /// </summary>
    public enum EnumPlanState
    {
        /// <summary>
        /// 已审核
        /// </summary>
        Checked=0,
        /// <summary>
        /// 已供车
        /// </summary>
        Gived=1,
        /// <summary>
        /// 已装车
        /// </summary>
        Loaded=2,
        /// <summary>
        /// 运输中
        /// </summary>
        Transporting=3,
        /// <summary>
        /// 已卸车
        /// </summary>
        UnLoaded=4,
        /// <summary>
        /// 已还车
        /// </summary>
        Backed=5,
        /// <summary>
        /// 已完成
        /// </summary>
        Complete=6
    }
}
