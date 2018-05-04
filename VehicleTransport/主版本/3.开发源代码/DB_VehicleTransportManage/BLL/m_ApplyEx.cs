using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Apply
    {
        /// <summary>
        /// 得到最新的一个对象实体
        /// </summary>
        public DB_VehicleTransportManage.Model.m_Apply GetOneNewModel()
        {
            DataSet ds = dal.GetList(1, "", "id desc");
            List<DB_VehicleTransportManage.Model.m_Apply> lst = DataTableToList(ds.Tables[0]);

            if (lst.Count == 1)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到最新的一个对象实体
        /// </summary>
        public int GetOneNewModelID()
        {
            DataSet ds = dal.GetList(1, "", "id desc");
            List<DB_VehicleTransportManage.Model.m_Apply> lst = DataTableToList(ds.Tables[0]);

            if (lst.Count == 1)
            {
                return lst[0].ID;
            }
            else
            {
                return 0;
            }
        }

        public bool IsPersonUsed(int ID)
        {
            DataSet dataSet = dal.GetList(String.Format("  (i_state=0 or i_state=-1) and ApplyPersonID ={0} ", ID));
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

    }
}
