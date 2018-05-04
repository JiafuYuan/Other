using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.InDataCommand
{
    public class InGetPlanDetailModel 
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        //public DateTime BeginDateTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        //public DateTime  EndDateTime { get; set; }

        /// <summary>
        /// 申请部门
        /// </summary>
        //public int ApplyDepartmentID { get; set; }

        /// <summary>
        /// 目的地ID
        /// </summary>
        //public int ArriveAddressID { get; set; }

        /// <summary>
        /// 开始序号
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 流程点
        /// </summary>
        public Enum.EnumFlowPathType FlowType { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 是否为只查询申请部门
        /// </summary>
        public bool IsApplyDepartment = false;
    }
}
