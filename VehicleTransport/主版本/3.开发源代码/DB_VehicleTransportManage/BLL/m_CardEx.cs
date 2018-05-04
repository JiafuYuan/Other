using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Card
    {
        public bool InsertKj222Hid(int HID)
        {
            string sqlKJ222CardSelect = "select * from BW_KJ222.dbo.m_Card where i_Flag=0 and i_HID="+HID ;
            string sqlKJ222Card = "insert into BW_KJ222.dbo.m_Card(i_HID,i_UseUnit,i_Flag) values(" + HID + ",2,0)";
            DataSet dataSet =  DB.OleDbHelper.GetDataSet(sqlKJ222CardSelect);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            int iState = DB.OleDbHelper.ExecuteSql(sqlKJ222Card);
            if (iState>0)
            {
                return true;
            }
            return false;
        }

        public bool VehicleCard(int VehicleID)
        {
            DataSet dataSet = dal.GetList("i_Flag=0 and VehicleID=" + VehicleID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;

        }
        public bool DeleteKj222Hid(int HID)
        {
            string sqlKJ222CardSelect = "select * from BW_KJ222.dbo.m_Card where i_Flag=0 and i_HID=" + HID;
            string sqlKJ222Card = "delete from  BW_KJ222.dbo.m_Card where i_HID=" + HID ;
            DataSet dataSet = new DataSet();
            int iState = DB.OleDbHelper.ExecuteSql(sqlKJ222CardSelect);
            if (iState > 0)
            {
                iState = DB.OleDbHelper.ExecuteSql(sqlKJ222Card);
                if (iState > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateKj222Hid(int oldHID,int newHID)
        {
            string sqlKJ222CardSelect = "select * from BW_KJ222.dbo.m_Card where i_Flag=0 and i_HID=" + oldHID;
            string sqlKJ222Card = "update  BW_KJ222.dbo.m_Card set i_HID=" + newHID + " where i_HID=" + oldHID;
            string sqlKJ222CardInsert = "insert into BW_KJ222.dbo.m_Card(i_HID,i_UseUnit,i_Flag) values(" + newHID + ",2,0)";
            DataSet dataSet = new DataSet();
            int iState = DB.OleDbHelper.ExecuteSql(sqlKJ222CardSelect);
            if (iState > 0)
            {
                iState = DB.OleDbHelper.ExecuteSql(sqlKJ222Card);
                if (iState > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                iState = DB.OleDbHelper.ExecuteSql(sqlKJ222CardInsert);
                if (iState > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
          
        }

        public bool Kj222HIDUsed(int iStart, int iOver)
        {
            string sqlKJ222Card = "select * FROM   BW_KJ222.dbo.m_Card where i_Flag=0 and i_HID>=" + iStart + " and  i_HID<=" + iOver;
            DataSet dataSet = DB.OleDbHelper.GetDataSet(sqlKJ222Card);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
