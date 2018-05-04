using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Message
    {
        /// <summary>
        /// 根据用户名更新消息为已接收
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public bool UpdateGetedMessage(int userID)
        {
            string sql = string.Format(
                "Update m_Message set  i_State=1 , dt_ReceiveDateTime='{0}' where toUserID={1} and (dt_ReceiveDateTime is null or dt_ReceiveDateTime<'1901-1-1') ", DateTime.Now, userID);
            return DB.OleDbHelper.ExecuteSql(sql) > 0;
        }

        public bool UpdateReadMessage(int userID)
        {
            return DB.OleDbHelper.ExecuteSql("Update m_Message set  i_read=1  where i_state=1 and toUserID=" + userID) > 0;
        }
        public bool UpdateReceiveMessage(int userID)
        {
            string sql = "Update m_Message set  i_State=1 , dt_ReceiveDateTime='" + DateTime.Now + "' where toUserID=" + userID + " and i_state=0";
            return DB.OleDbHelper.ExecuteSql(sql) > 0;
        }


    }
}
