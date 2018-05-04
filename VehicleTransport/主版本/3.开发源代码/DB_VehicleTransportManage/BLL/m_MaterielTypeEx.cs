using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_MaterielType
    {
        public string GetMaterielTypeName(int parentID)
        {
            Model.m_MaterielType modelMaterielType = GetModel(parentID);

            if (modelMaterielType != null && modelMaterielType.i_Flag == 0)
            {
                return modelMaterielType.vc_Name;
            }
            return "";
        }

        public string GetMaterielTypeUnit(int parentID)
        {
            Model.m_MaterielType modelMaterielType = GetModel(parentID);

            if (modelMaterielType != null && modelMaterielType.i_Flag == 0)
            {
                return modelMaterielType.vc_Unit;
            }
            return "";
        }
        public bool IsMaterielTypeUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and parentID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //申请中物料
        public bool IsApplyMaterielTypeUsed(int ID)
        {
            BLL.m_Plan_ApplyMaterie bllPlanApplyMaterie=new m_Plan_ApplyMaterie();
            DataSet dataSet = bllPlanApplyMaterie.GetList("i_Flag=0 and ApplyID in (select ID from m_Apply where  i_state=0 or i_state=-1 ) and MaterieTypeID="+ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        //计划中物料
        public bool IsPlanMaterielTypeUsed(int ID)
        {
            BLL.m_Plan_CheckVehicle bllCheckVehicle = new m_Plan_CheckVehicle();
            DataSet dataSet = bllCheckVehicle.GetList("i_Flag=0 and PlanID in (select ID from m_plan where  i_state<>6 ) and MaterieTypeID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>执行存储过程
        /// 执行存储过程
        /// </summary>
        /// <param name="CallingNum"></param>
        /// <param name="CalledNum"></param>
        /// <param name="PathTime"></param>
        /// <param name="recpath"></param>
        /// <returns></returns>
        public DataSet RunProUpdate(string month)
        {
            OleDbParameter[] parameters = new OleDbParameter[1];
            parameters[0] = new OleDbParameter("@Date", OleDbType.Date);
            parameters[0].Value = month;

            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("MaterielTypeMonth", CommandType.StoredProcedure, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

       /// <summary>部门物料使用月报表
        /// MaterieTypeDept
       /// </summary>
       /// <param name="month"></param>
       /// <param name="DeptID"></param>
       /// <returns></returns>
        public DataSet RunProUpdateDept(string dtStart, string dtEnd, int DeptID)
        {
            OleDbParameter[] parameters = new OleDbParameter[3];
            parameters[0] = new OleDbParameter("@startDate", OleDbType.VarChar);
            parameters[1] = new OleDbParameter("@stopDate", OleDbType.VarChar);
            parameters[2] = new OleDbParameter("@ApplyDepartmentID", OleDbType.Integer);
            parameters[0].Value = dtStart;
            parameters[1].Value = dtEnd;
            parameters[2].Value = DeptID;

            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("MaterieTypeDept", CommandType.StoredProcedure, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
