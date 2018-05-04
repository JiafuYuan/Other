using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Vehicle
    {
        public bool IsVehicleTypeUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and VehicleTypeID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //车辆在修
        public bool IsVehicleMainTain(int ID)
        {
            DataSet dataSet = dal.GetList(" i_State=2 and i_Flag=0 and ID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        //车辆在用
        public bool IsVehicleUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_State=1 and i_Flag=0 and ID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string[] GetVehicleName(int ID)
        {
            DataSet dataSet = new DataSet();
            dataSet = dal.GetList("i_Flag=0 and ID=" + ID.ToString());
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return new string[]
                {dataSet.Tables[0].Rows[0]["vc_Code"].ToString(), dataSet.Tables[0].Rows[0]["vc_Name"].ToString()};
            }
            return new string[]{"",""};
        }
        public string[] GetVehicleNameAll(int ID)
        {
            DataSet dataSet = new DataSet();
            dataSet = dal.GetList(" ID=" + ID.ToString());
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return new string[] { dataSet.Tables[0].Rows[0]["vc_Code"].ToString(), dataSet.Tables[0].Rows[0]["vc_Name"].ToString() };
            }
            return new string[] { "", "" };
        }
        public int GetVehicleTypeID(int VehicleID)
        {
            DataSet dataSet = new DataSet();
            dataSet = dal.GetList("i_Flag=0 and ID=" + VehicleID.ToString());
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return (int)dataSet.Tables[0].Rows[0]["VehicleTypeID"];
            }
            return 0;
        }
       
        public int GetLocalizerStationID(string VehicleCode)
        {
            DataSet dataSet = new DataSet();
            dataSet = dal.GetList("i_Flag=0 and vc_Code='" + VehicleCode+"'");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return (int)dataSet.Tables[0].Rows[0]["i_LocalizerStationID"];
            }
            return 0;
        }
        public DataSet DropDownSource()
        {
            string sql = "SELECT  ID,vc_Code as '车辆编号', vc_Name as '车辆名称' FROM m_Vehicle where i_Flag=0";
          
            return DB.OleDbHelper.GetDataSet(sql);
        }

        public DataSet DropDownSource( string where )
        {
            string sql = "SELECT  ID,vc_Code as '车辆编号', vc_Name as '车辆名称' FROM m_Vehicle where i_Flag=0";
            if (where.Length > 0)
            {
                sql+=" and "+ where;
            }

            return DB.OleDbHelper.GetDataSet(sql);
        }
        /// <summary>
        /// 空车类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmptyCarinfo()
        {
            string sql = "select distinct VehicleTypeID,COUNT(ID) as carcount from m_Vehicle where i_Flag=0 and i_State=0"
                        + " group by VehicleTypeID ";
            return DB.OleDbHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 重车类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetHeightCarinfo()
        {
            string sql = "select distinct VehicleTypeID,COUNT(ID) as carcount from m_Vehicle where i_Flag=0 and i_State=1"
                        + " group by VehicleTypeID ";
            return DB.OleDbHelper.GetDataTable(sql);
        }
      
        /// <summary>
        /// 更新车辆状态
        /// </summary>
        /// <param name="VehicleID"></param>
        /// <param name="i_State"></param>
        public bool UpdateVehicleState(int VehicleID, int i_State)
        {
            Model.m_Vehicle _model = dal.GetModel(VehicleID);
            if (_model != null)
            {
                _model.i_State = i_State;
                if (i_State == 0)
                {
                    _model.i_LastLocalizerStationID = 0;
                }
                return Update(_model);
            }
            return false;
        }

        /// <summary>
        /// 清除车辆上一次经过基站 的信息
        /// </summary>
        /// <param name="VehicleID"></param>
        /// <param name="i_State"></param>
        /// <returns></returns>
        public bool ClearVehicleLastLociler(int VehicleID)
        {
            Model.m_Vehicle _model = dal.GetModel(VehicleID);
            if (_model != null)
            {
                _model.i_LastLocalizerStationID = 0;
                return Update(_model);
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
        public DataSet RunProUpdateVehicleAddress()
        {
            OleDbParameter[] parameters = new OleDbParameter[0];
            
            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("VehicleAddress", CommandType.StoredProcedure, parameters);

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
                DataSet ds = DB.OleDbHelper.GetDataSet("VehicleMonth", CommandType.StoredProcedure, parameters);

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
        /// <summary>执行存储过程VehicleTypeDept
        /// 执行存储过程VehicleTypeDept
        public DataSet RunProUpdateVehicleTypeDept(string dtStart, string dtEnd, int deptID)
        {
            OleDbParameter[] parameters = new OleDbParameter[3];
            parameters[0] = new OleDbParameter("@startDate", OleDbType.VarChar);
            parameters[1] = new OleDbParameter("@stopDate", OleDbType.VarChar);
            parameters[2] = new OleDbParameter("@ApplyDepartmentID", OleDbType.Integer);
            parameters[0].Value = dtStart;
            parameters[1].Value = dtEnd;
            parameters[2].Value = deptID;

            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("VehicleTypeDept", CommandType.StoredProcedure, parameters);

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
        public DataTable GetLocalinfo()
        {
            return dal.GetLocalinfo();
        }
        /// <summary>
        /// 井下空车数量
        /// </summary>
        /// <returns></returns>
        public int GetDownCarempty()
        {
            string sql = "select COUNT(*) from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                        + "a.i_Flag=0 and a.i_State=0 and b.i_IsUpMine=0 and  b.i_Flag=0";
            object o= DB.OleDbHelper.ExecuteScale(sql);
            return int.Parse(o.ToString());
        }
        /// <summary>
        /// 井下重车数量
        /// </summary>
        /// <returns></returns>
        public int GetDownCarHeight()
        {
            string sql = "select COUNT(*) from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                        + "a.i_Flag=0 and a.i_State=1 and b.i_IsUpMine=0 and  b.i_Flag=0";
            object o = DB.OleDbHelper.ExecuteScale(sql);
            return int.Parse(o.ToString());
        }

        /// <summary>
        /// 井上重车数量
        /// </summary>
        /// <returns></returns>
        public int GetUpCarHeight()
        {
            string sql = "select COUNT(*) from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                        + "a.i_Flag=0 and a.i_State=1 and b.i_IsUpMine=1 and  b.i_Flag=0";
            object o = DB.OleDbHelper.ExecuteScale(sql);
            return int.Parse(o.ToString());
        }
        /// <summary>
        /// 井上空车数量
        /// </summary>
        /// <returns></returns>
        public int GetUpCarempty()
        {
            string sql = "select COUNT(*) from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                        + "a.i_Flag=0 and a.i_State=0 and b.i_IsUpMine=1 and  b.i_Flag=0";
            object o = DB.OleDbHelper.ExecuteScale(sql);
            return int.Parse(o.ToString());
        }
        /// <summary>
        /// 车辆类型数量
        /// </summary>
        /// <param name="empty"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public DataTable GetCarTypeinfo(bool empty, bool up)
        {
            string sql = "";
            if (empty && up)
            {
                sql = "select distinct VehicleTypeID,COUNT(*) as carcount from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                            + "a.i_Flag=0 and a.i_State=0 and b.i_IsUpMine=1 and  b.i_Flag=0 group by VehicleTypeID";
            }
            else if (empty == true && up == false)
            {
                sql = "select distinct VehicleTypeID,COUNT(*) as carcount from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                                         + "a.i_Flag=0 and a.i_State=0 and b.i_IsUpMine=0 and  b.i_Flag=0 group by VehicleTypeID";
            }
            else if (empty == false && up)
            {
                sql = "select distinct VehicleTypeID,COUNT(*) as carcount from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                          + "a.i_Flag=0 and a.i_State=1 and b.i_IsUpMine=1 and  b.i_Flag=0 group by VehicleTypeID";
            }
            else if (empty == false && up==false)
            {
                sql = "select distinct VehicleTypeID,COUNT(*) as carcount from m_Vehicle a,m_Address b where a.i_LocalizerStationID=b.LocalizerStationID and "
                          + "a.i_Flag=0 and a.i_State=1 and b.i_IsUpMine=0 and  b.i_Flag=0 group by VehicleTypeID";
            }
            return DB.OleDbHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 根据区域ID，查询下面的车辆
        /// </summary>
        /// <param name="areaID"></param>
        /// <returns></returns>
        public List<DB_VehicleTransportManage.Model.m_Vehicle> GetModelListByAreaID(int areaID)
        {
            DataSet ds = DB.OleDbHelper.GetDataSet("select v.* from m_Vehicle v ,m_Address a where v.i_LocalizerStationID=a.LocalizerStationID and (v.i_State=0 or v.i_State=1) and a.i_Flag=0 and v.i_Flag=0 and a.AreaID=" + areaID);
           if (ds!=null && ds.Tables.Count>0)
           {
               return DataTableToList(ds.Tables[0]);
           }
            return null;
        }

        /// <summary>
        /// 可以审核的车辆数量
        /// </summary>
        /// <param name="cartype"></param>
        /// <returns></returns>
        public int GetCheckCarTypeNum(int cartype)
        {
            string sql = "select COUNT(*) as num from m_Vehicle where i_Flag=0 and i_State=0 and VehicleTypeID=" + cartype.ToString()
                        + " and ID in (select VehicleID from m_Card where i_Flag=0) group by VehicleTypeID ";
            Object obj=DB.OleDbHelper.ExecuteScale(sql);
            int emptynum=0;
            if (obj!=null && !string.IsNullOrEmpty(obj.ToString()))
            {
                emptynum = int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }
            string listid = "";
            BLL.m_Plan bllplan = new m_Plan();
            List<Model.m_Plan> listplan = bllplan.GetModelList("i_state=0");
            for (int i = 0; i < listplan.Count; i++)
            {
                listid = listid + "," + listplan[i].ID;
            }
            if (!string.IsNullOrEmpty(listid))
            {
                listid = listid.Remove(0,1);
            }
            else
            {
                return emptynum;
            }
            sql = "select SUM(i_Count) from m_Plan_CheckVehicle where PlanID in (" + listid + ") and VehicleTypeID=" + cartype;
            obj = DB.OleDbHelper.ExecuteScale(sql);
            int checkcount = 0;
            if (obj!=null && !string.IsNullOrEmpty(obj.ToString()))
            {
                checkcount = int.Parse(obj.ToString());
            }
            if (emptynum - checkcount > 0)
            {
                return emptynum - checkcount;
            }
            else
            {
                return 0;
            }
            
        }
    }

}
