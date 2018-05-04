using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Enum
{
    public enum EnumFlowPathType
    {
          /// <summary>
        /// 申请
        /// </summary>
        Apply ,

        /// <summary>
        /// 审核
        /// </summary>
       Check ,

        /// <summary>
        /// 供车
        /// </summary>
        Give ,
        /// <summary>
        /// 装车
        /// </summary>
        Load,

        /// <summary>
        /// 交接车
        /// </summary>
         Handover,

        /// <summary>
        /// 卸车
        /// </summary>
         UnLoad ,
        /// <summary>
        /// 还车
        /// </summary>
        Back
    }
}
