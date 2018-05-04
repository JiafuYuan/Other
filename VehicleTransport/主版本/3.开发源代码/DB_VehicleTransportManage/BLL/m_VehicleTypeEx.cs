using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_VehicleType
    {
        public string GetVehicleTypeName(int ID)
        {
            Model.m_VehicleType _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }

       

        public DataSet DropDownSource()
        {
            string sql = "SELECT  ID, vc_Name as '类型名称',vc_Memo as '备注' FROM m_VehicleType where i_Flag=0";

            return DB.OleDbHelper.GetDataSet(sql);
        }

        public DataSet AddCardDropDownSource()
        {
            string sql = "select 0 as ID, '所有类型' as '类型名称','' as '备注' union all select ID, vc_Name as '类型名称',vc_Memo as '备注' from dbo.m_VehicleType where i_Flag=0 and ID in( select VehicleTypeID from dbo.m_Vehicle where i_Flag=0 group by VehicleTypeID)";

            return DB.OleDbHelper.GetDataSet(sql);
        }
        
    }
}
