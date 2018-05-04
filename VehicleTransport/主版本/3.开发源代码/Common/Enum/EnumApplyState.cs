using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    /// <summary>
    /// 申请状态
    /// </summary>
    public enum EnumApplyState
    {
        /// <summary>
        /// 不通过
        /// </summary>
        NoPass=-1,
        /// <summary>
        /// 待审核
        /// </summary>
        WaitCheck=0,
        /// <summary>
        /// 已审部分
        /// </summary>
        CheckPart=1,
        /// <summary>
        /// 已审核
        /// </summary>
        Checked=2
    }
}
