using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Person
    {
        public bool IsDeptUsed(int DeptID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and DepartmentID=" + DeptID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DataSet DropDownSource()
        {
            string sql = "SELECT  ID,vc_Code as '人员编号', vc_Name as '人员名称' FROM m_Person where i_Flag=0";

            return DB.OleDbHelper.GetDataSet(sql);
        }

        public string GetName(int ID)
        {
           
            Model.m_Person _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }

        public DataTable GetUserinfo(string strwhere)
        {
            string sql = "select a.vc_Name,a.DepartmentID,b.ID ,b.PersonID from m_Person a,m_User b where b.PersonID=a.ID and a.i_Flag=0 and b.i_Flag=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql = sql + " and " + strwhere;
            }
            return DB.OleDbHelper.GetDataTable(sql);
        }
        


        public int GetDeptName(int ID)
        {

            Model.m_Person _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.DepartmentID;
            }
            return 0;
        }


        public int GetDeptID(int ID)
        {
            Model.m_Person _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.DepartmentID;
            }
            return 0;
        }
    }
}
