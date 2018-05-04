using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model
{
    public class InBaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID;

        /// <summary>
        /// 部门ID
        /// </summary>
        public int DepartmentID;

        /// <summary>
        /// 人的ID，PDA不知道时传0
        /// </summary>
        public int PersonID;

        /// <summary>
        /// 地点，PC操作时指定,PDA不使用
        /// </summary>
        public int AddressID;

        /// <summary>
        /// 计划ID
        /// </summary>
        public int PlanID;

        /// <summary>
        /// 运单号
        /// </summary>
        //public string PlanCode;

        /// <summary>
        /// 时间,实际时间PC,PDA一样
        /// </summary>
        public DateTime DateTime;
    }
}
