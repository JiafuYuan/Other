using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// ϵͳ��־������
    /// </summary>
    public class SysLogController : PublicController<Base_SysLog>
    {
        private Base_SysLogBll base_syslogbll = new Base_SysLogBll();
        /// <summary>
        /// ��ϵͳ��־������ϵͳ��־�б�JSON
        /// </summary>
        /// <param name="ModuleId">ģ��ID</param>
        /// <param name="ParameterJson">��������</param>
        /// <param name="jqgridparam">������</param>
        /// <returns></returns>
        public ActionResult GridPageListJson(string ModuleId, string ParameterJson, JqGridParam jqgridparam)
        {
            try
            {
                Stopwatch watch = CommonHelper.TimerStart();
                //if (!string.IsNullOrEmpty(ParameterJson) && ParameterJson.Length > 2)
                //{
                //    List<DbParameter> parameter = new List<DbParameter>();
                //    IList conditions = ParameterJson.JonsToList<Condition>();
                //    string WhereSql = ConditionBuilder.GetWhereSql(conditions, out parameter);
                //}
                List<Base_SysLog> ListData = base_syslogbll.GetPageList(ModuleId, ParameterJson, ref jqgridparam);
                var JsonData = new
                {
                    total = jqgridparam.total,
                    page = jqgridparam.page,
                    records = jqgridparam.records,
                    costtime = CommonHelper.TimerEnd(watch),
                    rows = ListData,
                };
                return Content(JsonData.ToJson());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Query, "-1", "�쳣����" + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// ��ϵͳ��־��ϸ�����ر��JSON
        /// </summary>
        /// <param name="SysLogId">����ֵ</param>
        /// <returns></returns>
        public JsonResult GetSysLogDetailJson(string SysLogId)
        {
            List<Base_SysLogDetail> list = base_syslogbll.GetSysLogDetailList(SysLogId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// �������־��
        /// </summary>
        /// <returns></returns>
        [ManagerPermission(PermissionMode.Enforce)]
        public ActionResult RemoveLog()
        {
            return View();
        }
        /// <summary>
        /// �������־�� ���ύ�¼�
        /// </summary>
        /// <param name="KeepTime">��־����ʱ��</param>
        public ActionResult SubmitRemoveLog(string KeepTime)
        {
            string Remark = "";
            if (KeepTime == "7")//������һ��
            {
                Remark = "������һ��";
            }
            else if (KeepTime == "1")//������һ����
            {
                Remark = "������һ����";
            }
            else if (KeepTime == "3")//������������
            {
                Remark = "������������";
            }
            if (KeepTime == "0")//
            {
                Remark = "��������ȫ��ɾ��";
            }
            try
            {
                var Message = "���ʧ�ܡ�";
                int IsOk = Base_SysLogBll.Instance.RemoveLog(KeepTime);
                if (IsOk >= 0)
                {
                    IsOk = 1;
                    Message = "ɾ���ɹ���";
                }
                Base_SysLogBll.Instance.WriteLog("", OperationType.Other, IsOk.ToString(), Message + Remark);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                Base_SysLogBll.Instance.WriteLog("", OperationType.Other, "-1", Remark + "," + "����" + ex.Message);
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�����" + ex.Message }.ToString());
            }
        }
        #region ��־�ļ�
        /// <summary>
        /// ��־�ļ���ͼ
        /// </summary>
        /// <returns></returns>
        public ActionResult FileIndex()
        {
            return View();
        }
        /// <summary>
        /// ��־�ļ��б�
        /// </summary>
        /// <returns></returns>
        public ActionResult FileList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/log"));
            FileInfo[] files = dir.GetFiles();
            FileDateSorter.QuickSort(files, 0, files.Length - 1);//��ʱ������
            foreach (FileInfo fsi in files)
            {
                sb.Append("{");
                sb.Append("\"id\":\"" + fsi.Name + "\",");
                sb.Append("\"text\":\"" + fsi.Name + "\",");
                sb.Append("\"value\":\"" + fsi.Name + "\",");
                sb.Append("\"img\":\"/Content/Images/Icon16/page_white_error.png\",");
                sb.Append("\"isexpand\":true,");
                sb.Append("\"hasChildren\":false");
                sb.Append("},");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return Content(sb.ToString());
        }
        /// <summary>
        /// ����־
        /// </summary>
        /// <param name="FileName">�ļ���</param>
        /// <returns></returns>
        public ActionResult ReadTxtLog(string FileName)
        {
            string filepath = Server.MapPath("~/log/" + FileName);
            FileStream fs = new System.IO.FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));//ȡ����txt�ļ��ı���
            string txtvalue = sr.ReadToEnd().ToString();
            sr.Close();
            return Content(txtvalue);
        }
        #endregion

        #region ��½����ͳ��
        /// <summary>
        /// ��½����ͳ��
        /// </summary>
        /// <returns></returns>
        public ActionResult LogChartIndex()
        {
            return View();
        }
        /// <summary>
        /// ��½�����б�
        /// </summary>
        /// <param name="day">��</param>
        /// <returns></returns>
        public ActionResult LoginList(string day)
        {
            string datatime = DateTime.Now.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(day))
            {
                datatime = CommonHelper.GetDateTime(DateTime.Now.ToString("yyyy-MM-") + day).ToString("yyyy-MM-dd");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  convert(varchar(100),CreateDate,120) AS CreateDate ,
                                    IPAddress ,
                                    IPAddressName
                            FROM    [Login].dbo.BPMS_SysLoginLog
                            WHERE   convert(varchar(10),CreateDate,120) = '" + datatime + "' ORDER BY CreateDate DESC ,IPAddress DESC");
            DataTable dt = DataFactory.Database().FindTableBySql(strSql.ToString());
            return Content(dt.ToJson());
        }
        /// <summary>
        /// ��½����ͳ�ƣ�����JSON��
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginChart()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@y", year));
            parameter.Add(DbFactory.CreateDbParameter("@m", month));
            DataTable dt = DataFactory.Database().FindTableByProc("[Login].dbo.[PROC_Get_LoginCnt]", parameter.ToArray());
            //StringBuilder sb_cnt = new StringBuilder();
            //StringBuilder sb_ip = new StringBuilder();
            //for (int i = 1; i < 31; i++)
            //{
            //    sb_cnt.Append(dt.Rows[0][i].ToString() + ",");
            //    sb_ip.Append(dt.Rows[1][i].ToString() + ",");
            //}
            //object[] cnt = sb_cnt.ToString().Split(',');
            //object[] ip = sb_ip.ToString().Split(',');
            //var JsonData = new
            //{
            //    cntData = cnt,
            //    ipData = ip,
            //};
            return Content(dt.ToJson());
        }
        #endregion
    }
}