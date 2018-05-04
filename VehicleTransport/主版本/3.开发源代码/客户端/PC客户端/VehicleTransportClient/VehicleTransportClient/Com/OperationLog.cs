using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Enum;
using DB_VehicleTransportManage.Model;

namespace VehicleTransportClient.Com
{
   public static class OperationLog
    {
        static DB_VehicleTransportManage.Model.m_SystemLog _model=new m_SystemLog();
        static DB_VehicleTransportManage.BLL.m_SystemLog bllSystemLog = new DB_VehicleTransportManage.BLL.m_SystemLog();

         /// <summary>数据库插入操作日志
        /// 数据库插入操作日志
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="enumActionType">操作类型</param>
        /// <param name="title">日志标题</param>
        /// <param name="description">日志内容</param>
        /// <param name="memo">备注</param>
        public static void InsertSqlLog(int userId,EnumActionType enumActionType,string title,string description,string memo)
        {
            _model.UserID = userId;
            _model.i_ActionType = (int) enumActionType;
            _model.vc_Title = title;
            _model.vc_Description = description;
            _model.vc_Memo = memo;
             _model.dt_DateTime = DateTime.Now;
            bllSystemLog.Add(_model);
        }

        /// <summary>数据库插入操作日志(默认当前登录用户)
        /// 数据库插入操作日志
        /// </summary>
        /// <param name="userId">当前登录用户ID</param>
        /// <param name="enumActionType">操作类型</param>
        /// <param name="title">日志标题</param>
        /// <param name="description">日志内容</param>
        /// <param name="memo">备注</param>
        public static void InsertSqlLog(EnumActionType enumActionType, string title, string description, string memo)
        {
            _model.UserID = Pub.UserId;
            _model.i_ActionType = (int)enumActionType;
            _model.vc_Title = title;
            _model.vc_Description = description;
            _model.vc_Memo = memo;
            _model.dt_DateTime = DateTime.Now;
            bllSystemLog.Add(_model);
        }

        //public static void InsertSqlLog(string title, string description, string memo)
        //{
            
        //}

        /// <summary>数据库插入操作日志(默认当前登录用户)
        /// 数据库插入操作日志
        /// </summary>
        /// <param name="userId">当前登录用户ID</param>
        /// <param name="enumActionType">操作类型</param>
        /// <param name="title">日志标题</param>
        /// <param name="description">日志内容</param>
        /// <param name="memo">备注</param>
        public static void InsertSqlLog(EnumActionType enumActionType, string title, string description)
        {
            _model.UserID = Pub.UserId;
            _model.i_ActionType = (int)enumActionType;
            switch (enumActionType)
            {
                   case EnumActionType.Add:
                    _model.vc_Title = "新增【" + title+"】";
                    _model.vc_Description = "【" + description + "】";
                    break;
                    case EnumActionType.Delete:
                    _model.vc_Title = "删除【" + title+"】";
                    _model.vc_Description = "【" + description + "】";
                    break;
                    case EnumActionType.Update:
                    _model.vc_Title = "修改【" + title+"】";
                    _model.vc_Description = "【" + description + "】";
                    break;
                    case EnumActionType.System:
                    _model.vc_Title = "系统操作【" + title+"】";
                    _model.vc_Description = "【" + description + "】";
                    break;
                default:
                    break;
            }
            _model.dt_DateTime = DateTime.Now;
            bllSystemLog.Add(_model);
        }

        //public static void InsertSqlLog(string description)
        //{

        //}
    }
}
