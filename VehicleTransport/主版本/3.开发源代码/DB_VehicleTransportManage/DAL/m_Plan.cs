/**  版本信息模板在安装目录下，可自行修改。
* m_Plan.cs
*
* 功 能： N/A
* 类 名： m_Plan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/16 13:27:31   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_VehicleTransportManage.DAL
{
    /// <summary>
    /// 数据访问类:m_Plan
    /// </summary>
    public partial class m_Plan
    {
        public m_Plan()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DB_VehicleTransportManage.Model.m_Plan model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.dt_ArriveDestinationDateTime != null)
            {
                strSql1.Append("dt_ArriveDestinationDateTime,");
                strSql2.Append("'" + model.dt_ArriveDestinationDateTime + "',");
            }
            if (model.ArriveDestinationAddressID != null)
            {
                strSql1.Append("ArriveDestinationAddressID,");
                strSql2.Append("" + model.ArriveDestinationAddressID + ",");
            }
            if (model.i_State != null)
            {
                strSql1.Append("i_State,");
                strSql2.Append("" + model.i_State + ",");
            }
            if (model.ApplyID != null)
            {
                strSql1.Append("ApplyID,");
                strSql2.Append("" + model.ApplyID + ",");
            }
            if (model.i_IsTemPlan != null)
            {
                strSql1.Append("i_IsTemPlan,");
                strSql2.Append("" + model.i_IsTemPlan + ",");
            }
            if (model.vc_PlanCode != null)
            {
                strSql1.Append("vc_PlanCode,");
                strSql2.Append("'" + model.vc_PlanCode + "',");
            }
            if (model.CheckPersonID != null)
            {
                strSql1.Append("CheckPersonID,");
                strSql2.Append("" + model.CheckPersonID + ",");
            }
            if (model.dt_CheckDateTime != null)
            {
                strSql1.Append("dt_CheckDateTime,");
                strSql2.Append("'" + model.dt_CheckDateTime + "',");
            }
            if (model.PlanGiveCarDepartmentID != null)
            {
                strSql1.Append("PlanGiveCarDepartmentID,");
                strSql2.Append("" + model.PlanGiveCarDepartmentID + ",");
            }
            if (model.vc_PDAUserIDs != null)
            {
                strSql1.Append("vc_PDAUserIDs,");
                strSql2.Append("'" + model.vc_PDAUserIDs + "',");
            }
            if (model.dt_PlanGiveCarDateTime != null)
            {
                strSql1.Append("dt_PlanGiveCarDateTime,");
                strSql2.Append("'" + model.dt_PlanGiveCarDateTime + "',");
            }
            if (model.PlanGiveCarAddressID != null)
            {
                strSql1.Append("PlanGiveCarAddressID,");
                strSql2.Append("" + model.PlanGiveCarAddressID + ",");
            }
            if (model.PlanUnLoadDepartmentID != null)
            {
                strSql1.Append("PlanUnLoadDepartmentID,");
                strSql2.Append("" + model.PlanUnLoadDepartmentID + ",");
            }
            if (model.PlanBackDepartmentID != null)
            {
                strSql1.Append("PlanBackDepartmentID,");
                strSql2.Append("" + model.PlanBackDepartmentID + ",");
            }
            if (model.dt_PlanBackDateTime != null)
            {
                strSql1.Append("dt_PlanBackDateTime,");
                strSql2.Append("'" + model.dt_PlanBackDateTime + "',");
            }
            if (model.PlanBackAddressID != null)
            {
                strSql1.Append("PlanBackAddressID,");
                strSql2.Append("" + model.PlanBackAddressID + ",");
            }
            if (model.PlanLoadDepartmentID != null)
            {
                strSql1.Append("PlanLoadDepartmentID,");
                strSql2.Append("" + model.PlanLoadDepartmentID + ",");
            }
            if (model.PlanLoadAddressID != null)
            {
                strSql1.Append("PlanLoadAddressID,");
                strSql2.Append("" + model.PlanLoadAddressID + ",");
            }
            if (model.dt_PlanLoadDateTime != null)
            {
                strSql1.Append("dt_PlanLoadDateTime,");
                strSql2.Append("'" + model.dt_PlanLoadDateTime + "',");
            }
            if (model.RealGiveCarDepartmentID != null)
            {
                strSql1.Append("RealGiveCarDepartmentID,");
                strSql2.Append("" + model.RealGiveCarDepartmentID + ",");
            }
            if (model.dt_RealGiveCarDateTime != null)
            {
                strSql1.Append("dt_RealGiveCarDateTime,");
                strSql2.Append("'" + model.dt_RealGiveCarDateTime + "',");
            }
            if (model.RealGiveCarAddressID != null)
            {
                strSql1.Append("RealGiveCarAddressID,");
                strSql2.Append("" + model.RealGiveCarAddressID + ",");
            }
            if (model.RealLoadDepartmentID != null)
            {
                strSql1.Append("RealLoadDepartmentID,");
                strSql2.Append("" + model.RealLoadDepartmentID + ",");
            }
            if (model.dt_RealLoadDateTime != null)
            {
                strSql1.Append("dt_RealLoadDateTime,");
                strSql2.Append("'" + model.dt_RealLoadDateTime + "',");
            }
            if (model.RealLoadAddressID != null)
            {
                strSql1.Append("RealLoadAddressID,");
                strSql2.Append("" + model.RealLoadAddressID + ",");
            }
            if (model.dt_RealArriveDestinationDateTime != null)
            {
                strSql1.Append("dt_RealArriveDestinationDateTime,");
                strSql2.Append("'" + model.dt_RealArriveDestinationDateTime + "',");
            }
            if (model.RealGiveCarPersonID != null)
            {
                strSql1.Append("RealGiveCarPersonID,");
                strSql2.Append("" + model.RealGiveCarPersonID + ",");
            }
            if (model.RealLoadPersonID != null)
            {
                strSql1.Append("RealLoadPersonID,");
                strSql2.Append("" + model.RealLoadPersonID + ",");
            }
            strSql.Append("insert into m_Plan(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DB.OleDbHelper.ExecuteScale(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DB_VehicleTransportManage.Model.m_Plan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_Plan set ");
            if (model.dt_ArriveDestinationDateTime != null)
            {
                strSql.Append("dt_ArriveDestinationDateTime='" + model.dt_ArriveDestinationDateTime + "',");
            }
            else
            {
                strSql.Append("dt_ArriveDestinationDateTime= null ,");
            }
            if (model.ArriveDestinationAddressID != null)
            {
                strSql.Append("ArriveDestinationAddressID=" + model.ArriveDestinationAddressID + ",");
            }
            else
            {
                strSql.Append("ArriveDestinationAddressID= null ,");
            }
            if (model.i_State != null)
            {
                strSql.Append("i_State=" + model.i_State + ",");
            }
            else
            {
                strSql.Append("i_State= null ,");
            }
            if (model.ApplyID != null)
            {
                strSql.Append("ApplyID=" + model.ApplyID + ",");
            }
            else
            {
                strSql.Append("ApplyID= null ,");
            }
            if (model.i_IsTemPlan != null)
            {
                strSql.Append("i_IsTemPlan=" + model.i_IsTemPlan + ",");
            }
            else
            {
                strSql.Append("i_IsTemPlan= null ,");
            }
            if (model.vc_PlanCode != null)
            {
                strSql.Append("vc_PlanCode='" + model.vc_PlanCode + "',");
            }
            else
            {
                strSql.Append("vc_PlanCode= null ,");
            }
            if (model.CheckPersonID != null)
            {
                strSql.Append("CheckPersonID=" + model.CheckPersonID + ",");
            }
            else
            {
                strSql.Append("CheckPersonID= null ,");
            }
            if (model.dt_CheckDateTime != null)
            {
                strSql.Append("dt_CheckDateTime='" + model.dt_CheckDateTime + "',");
            }
            else
            {
                strSql.Append("dt_CheckDateTime= null ,");
            }
            if (model.PlanGiveCarDepartmentID != null)
            {
                strSql.Append("PlanGiveCarDepartmentID=" + model.PlanGiveCarDepartmentID + ",");
            }
            else
            {
                strSql.Append("PlanGiveCarDepartmentID= null ,");
            }
            if (model.vc_PDAUserIDs != null)
            {
                strSql.Append("vc_PDAUserIDs='" + model.vc_PDAUserIDs + "',");
            }
            else
            {
                strSql.Append("vc_PDAUserIDs= null ,");
            }
            if (model.dt_PlanGiveCarDateTime != null)
            {
                strSql.Append("dt_PlanGiveCarDateTime='" + model.dt_PlanGiveCarDateTime + "',");
            }
            else
            {
                strSql.Append("dt_PlanGiveCarDateTime= null ,");
            }
            if (model.PlanGiveCarAddressID != null)
            {
                strSql.Append("PlanGiveCarAddressID=" + model.PlanGiveCarAddressID + ",");
            }
            else
            {
                strSql.Append("PlanGiveCarAddressID= null ,");
            }
            if (model.PlanUnLoadDepartmentID != null)
            {
                strSql.Append("PlanUnLoadDepartmentID=" + model.PlanUnLoadDepartmentID + ",");
            }
            else
            {
                strSql.Append("PlanUnLoadDepartmentID= null ,");
            }
            if (model.PlanBackDepartmentID != null)
            {
                strSql.Append("PlanBackDepartmentID=" + model.PlanBackDepartmentID + ",");
            }
            else
            {
                strSql.Append("PlanBackDepartmentID= null ,");
            }
            if (model.dt_PlanBackDateTime != null)
            {
                strSql.Append("dt_PlanBackDateTime='" + model.dt_PlanBackDateTime + "',");
            }
            else
            {
                strSql.Append("dt_PlanBackDateTime= null ,");
            }
            if (model.PlanBackAddressID != null)
            {
                strSql.Append("PlanBackAddressID=" + model.PlanBackAddressID + ",");
            }
            else
            {
                strSql.Append("PlanBackAddressID= null ,");
            }
            if (model.PlanLoadDepartmentID != null)
            {
                strSql.Append("PlanLoadDepartmentID=" + model.PlanLoadDepartmentID + ",");
            }
            else
            {
                strSql.Append("PlanLoadDepartmentID= null ,");
            }
            if (model.PlanLoadAddressID != null)
            {
                strSql.Append("PlanLoadAddressID=" + model.PlanLoadAddressID + ",");
            }
            else
            {
                strSql.Append("PlanLoadAddressID= null ,");
            }
            if (model.dt_PlanLoadDateTime != null)
            {
                strSql.Append("dt_PlanLoadDateTime='" + model.dt_PlanLoadDateTime + "',");
            }
            else
            {
                strSql.Append("dt_PlanLoadDateTime= null ,");
            }
            if (model.RealGiveCarDepartmentID != null)
            {
                strSql.Append("RealGiveCarDepartmentID=" + model.RealGiveCarDepartmentID + ",");
            }
            else
            {
                strSql.Append("RealGiveCarDepartmentID= null ,");
            }
            if (model.dt_RealGiveCarDateTime != null)
            {
                strSql.Append("dt_RealGiveCarDateTime='" + model.dt_RealGiveCarDateTime + "',");
            }
            else
            {
                strSql.Append("dt_RealGiveCarDateTime= null ,");
            }
            if (model.RealGiveCarAddressID != null)
            {
                strSql.Append("RealGiveCarAddressID=" + model.RealGiveCarAddressID + ",");
            }
            else
            {
                strSql.Append("RealGiveCarAddressID= null ,");
            }
            if (model.RealLoadDepartmentID != null)
            {
                strSql.Append("RealLoadDepartmentID=" + model.RealLoadDepartmentID + ",");
            }
            else
            {
                strSql.Append("RealLoadDepartmentID= null ,");
            }
            if (model.dt_RealLoadDateTime != null)
            {
                strSql.Append("dt_RealLoadDateTime='" + model.dt_RealLoadDateTime + "',");
            }
            else
            {
                strSql.Append("dt_RealLoadDateTime= null ,");
            }
            if (model.RealLoadAddressID != null)
            {
                strSql.Append("RealLoadAddressID=" + model.RealLoadAddressID + ",");
            }
            else
            {
                strSql.Append("RealLoadAddressID= null ,");
            }
            if (model.dt_RealArriveDestinationDateTime != null)
            {
                strSql.Append("dt_RealArriveDestinationDateTime='" + model.dt_RealArriveDestinationDateTime + "',");
            }
            else
            {
                strSql.Append("dt_RealArriveDestinationDateTime= null ,");
            }
            if (model.RealGiveCarPersonID != null)
            {
                strSql.Append("RealGiveCarPersonID=" + model.RealGiveCarPersonID + ",");
            }
            else
            {
                strSql.Append("RealGiveCarPersonID= null ,");
            }
            if (model.RealLoadPersonID != null)
            {
                strSql.Append("RealLoadPersonID=" + model.RealLoadPersonID + ",");
            }
            else
            {
                strSql.Append("RealLoadPersonID= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_Plan ");
            strSql.Append(" where ID=" + ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_Plan ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB_VehicleTransportManage.Model.m_Plan GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,dt_PlanLoadDateTime,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,RealGiveCarPersonID,RealLoadPersonID ");
            strSql.Append(" from m_Plan ");
            strSql.Append(" where ID=" + ID + "");
            DB_VehicleTransportManage.Model.m_Plan model = new DB_VehicleTransportManage.Model.m_Plan();
            DataSet ds = DB.OleDbHelper.GetDataSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB_VehicleTransportManage.Model.m_Plan DataRowToModel(DataRow row)
        {
            DB_VehicleTransportManage.Model.m_Plan model = new DB_VehicleTransportManage.Model.m_Plan();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["dt_ArriveDestinationDateTime"] != null && row["dt_ArriveDestinationDateTime"].ToString() != "")
                {
                    model.dt_ArriveDestinationDateTime = DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
                }
                if (row["ArriveDestinationAddressID"] != null && row["ArriveDestinationAddressID"].ToString() != "")
                {
                    model.ArriveDestinationAddressID = int.Parse(row["ArriveDestinationAddressID"].ToString());
                }
                if (row["i_State"] != null && row["i_State"].ToString() != "")
                {
                    model.i_State = int.Parse(row["i_State"].ToString());
                }
                if (row["ApplyID"] != null && row["ApplyID"].ToString() != "")
                {
                    model.ApplyID = int.Parse(row["ApplyID"].ToString());
                }
                if (row["i_IsTemPlan"] != null && row["i_IsTemPlan"].ToString() != "")
                {
                    model.i_IsTemPlan = int.Parse(row["i_IsTemPlan"].ToString());
                }
                if (row["vc_PlanCode"] != null)
                {
                    model.vc_PlanCode = row["vc_PlanCode"].ToString();
                }
                if (row["CheckPersonID"] != null && row["CheckPersonID"].ToString() != "")
                {
                    model.CheckPersonID = int.Parse(row["CheckPersonID"].ToString());
                }
                if (row["dt_CheckDateTime"] != null && row["dt_CheckDateTime"].ToString() != "")
                {
                    model.dt_CheckDateTime = DateTime.Parse(row["dt_CheckDateTime"].ToString());
                }
                if (row["PlanGiveCarDepartmentID"] != null && row["PlanGiveCarDepartmentID"].ToString() != "")
                {
                    model.PlanGiveCarDepartmentID = int.Parse(row["PlanGiveCarDepartmentID"].ToString());
                }
                if (row["vc_PDAUserIDs"] != null)
                {
                    model.vc_PDAUserIDs = row["vc_PDAUserIDs"].ToString();
                }
                if (row["dt_PlanGiveCarDateTime"] != null && row["dt_PlanGiveCarDateTime"].ToString() != "")
                {
                    model.dt_PlanGiveCarDateTime = DateTime.Parse(row["dt_PlanGiveCarDateTime"].ToString());
                }
                if (row["PlanGiveCarAddressID"] != null && row["PlanGiveCarAddressID"].ToString() != "")
                {
                    model.PlanGiveCarAddressID = int.Parse(row["PlanGiveCarAddressID"].ToString());
                }
                if (row["PlanUnLoadDepartmentID"] != null && row["PlanUnLoadDepartmentID"].ToString() != "")
                {
                    model.PlanUnLoadDepartmentID = int.Parse(row["PlanUnLoadDepartmentID"].ToString());
                }
                if (row["PlanBackDepartmentID"] != null && row["PlanBackDepartmentID"].ToString() != "")
                {
                    model.PlanBackDepartmentID = int.Parse(row["PlanBackDepartmentID"].ToString());
                }
                if (row["dt_PlanBackDateTime"] != null && row["dt_PlanBackDateTime"].ToString() != "")
                {
                    model.dt_PlanBackDateTime = DateTime.Parse(row["dt_PlanBackDateTime"].ToString());
                }
                if (row["PlanBackAddressID"] != null && row["PlanBackAddressID"].ToString() != "")
                {
                    model.PlanBackAddressID = int.Parse(row["PlanBackAddressID"].ToString());
                }
                if (row["PlanLoadDepartmentID"] != null && row["PlanLoadDepartmentID"].ToString() != "")
                {
                    model.PlanLoadDepartmentID = int.Parse(row["PlanLoadDepartmentID"].ToString());
                }
                if (row["PlanLoadAddressID"] != null && row["PlanLoadAddressID"].ToString() != "")
                {
                    model.PlanLoadAddressID = int.Parse(row["PlanLoadAddressID"].ToString());
                }
                if (row["dt_PlanLoadDateTime"] != null && row["dt_PlanLoadDateTime"].ToString() != "")
                {
                    model.dt_PlanLoadDateTime = DateTime.Parse(row["dt_PlanLoadDateTime"].ToString());
                }
                if (row["RealGiveCarDepartmentID"] != null && row["RealGiveCarDepartmentID"].ToString() != "")
                {
                    model.RealGiveCarDepartmentID = int.Parse(row["RealGiveCarDepartmentID"].ToString());
                }
                if (row["dt_RealGiveCarDateTime"] != null && row["dt_RealGiveCarDateTime"].ToString() != "")
                {
                    model.dt_RealGiveCarDateTime = DateTime.Parse(row["dt_RealGiveCarDateTime"].ToString());
                }
                if (row["RealGiveCarAddressID"] != null && row["RealGiveCarAddressID"].ToString() != "")
                {
                    model.RealGiveCarAddressID = int.Parse(row["RealGiveCarAddressID"].ToString());
                }
                if (row["RealLoadDepartmentID"] != null && row["RealLoadDepartmentID"].ToString() != "")
                {
                    model.RealLoadDepartmentID = int.Parse(row["RealLoadDepartmentID"].ToString());
                }
                if (row["dt_RealLoadDateTime"] != null && row["dt_RealLoadDateTime"].ToString() != "")
                {
                    model.dt_RealLoadDateTime = DateTime.Parse(row["dt_RealLoadDateTime"].ToString());
                }
                if (row["RealLoadAddressID"] != null && row["RealLoadAddressID"].ToString() != "")
                {
                    model.RealLoadAddressID = int.Parse(row["RealLoadAddressID"].ToString());
                }
                if (row["dt_RealArriveDestinationDateTime"] != null && row["dt_RealArriveDestinationDateTime"].ToString() != "")
                {
                    model.dt_RealArriveDestinationDateTime = DateTime.Parse(row["dt_RealArriveDestinationDateTime"].ToString());
                }
                if (row["RealGiveCarPersonID"] != null && row["RealGiveCarPersonID"].ToString() != "")
                {
                    model.RealGiveCarPersonID = int.Parse(row["RealGiveCarPersonID"].ToString());
                }
                if (row["RealLoadPersonID"] != null && row["RealLoadPersonID"].ToString() != "")
                {
                    model.RealLoadPersonID = int.Parse(row["RealLoadPersonID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,dt_PlanLoadDateTime,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,RealGiveCarPersonID,RealLoadPersonID ");
            strSql.Append(" FROM m_Plan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,dt_PlanLoadDateTime,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,RealGiveCarPersonID,RealLoadPersonID ");
            strSql.Append(" FROM m_Plan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM m_Plan ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
            //object obj = DB.OleDbHelper.GetDataSet(strSql.ToString());
            //if (obj == null)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from m_Plan T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());

        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPageEx(string strWhere, string orderby, int startIndex, int pageSize)
        {
            StringBuilder strSql = new StringBuilder();
            int index = 0;
            index = pageSize + startIndex ;
            int reCount = GetRecordCount(strWhere);

            if (index==reCount+pageSize)
            {
                pageSize = 0;
            }
            else if (index >= reCount)
            {
                pageSize = pageSize - (index - reCount);
            }

            strSql.Append("SELECT * FROM    ");
            strSql.Append("(SELECT TOP " + pageSize + " * FROM        ");
            strSql.Append(" (SELECT TOP " + index + " * FROM m_plan  ");
            strSql.Append("           where " + strWhere + " order by id asc ) ");
            strSql.Append("TB2 order by id desc) TB3 order by id asc");



            return DB.OleDbHelper.GetDataSet(strSql.ToString());

        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

