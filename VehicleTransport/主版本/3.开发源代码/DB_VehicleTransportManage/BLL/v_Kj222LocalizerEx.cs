using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class v_Kj222Localizer
    {
        public string GetLocalizerStationName(int ID)
        {
            Model.v_Kj222Localizer _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }

        public DataSet DropDownSource()
        {
            string sql = "SELECT  ID,vc_Code as '基站编号', vc_Name as '基站名称' FROM v_Kj222Localizer where i_Flag=0";
            
            return  DB.OleDbHelper.GetDataSet(sql);
        }
    }
}
