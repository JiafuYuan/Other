/**  版本信息模板在安装目录下，可自行修改。
* m_EnergyPlanEntity.cs
*
* 功 能： N/A
* 类 名： m_EnergyPlanEntity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-29 17:40:18   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BW.MMS.Model
{
    /// <summary>
    /// m_EnergyPlanEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class m_EnergyPlanEntity
    {
        public m_EnergyPlanEntity()
        { }
        #region Model
        private int _id;
        private int? _deptid;
        private int? _years;
        private decimal? _jan;
        private decimal? _feb;
        private decimal? _mar;
        private decimal? _apr;
        private decimal? _may;
        private decimal? _jun;
        private decimal? _jul;
        private decimal? _aug;
        private decimal? _sep;
        private decimal? _oct;
        private decimal? _nov;
        private decimal? _dec;
        private int? _type;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DeptID
        {
            set { _deptid = value; }
            get { return _deptid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Years
        {
            set { _years = value; }
            get { return _years; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Jan
        {
            set { _jan = value; }
            get { return _jan; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Feb
        {
            set { _feb = value; }
            get { return _feb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Mar
        {
            set { _mar = value; }
            get { return _mar; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Apr
        {
            set { _apr = value; }
            get { return _apr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? May
        {
            set { _may = value; }
            get { return _may; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Jun
        {
            set { _jun = value; }
            get { return _jun; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Jul
        {
            set { _jul = value; }
            get { return _jul; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Aug
        {
            set { _aug = value; }
            get { return _aug; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Sep
        {
            set { _sep = value; }
            get { return _sep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Oct
        {
            set { _oct = value; }
            get { return _oct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Nov
        {
            set { _nov = value; }
            get { return _nov; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Dec
        {
            set { _dec = value; }
            get { return _dec; }
        }
        /// <summary>
        /// 1:代表风，2:代表水，3:代表电
        /// </summary>
        public int? type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}

