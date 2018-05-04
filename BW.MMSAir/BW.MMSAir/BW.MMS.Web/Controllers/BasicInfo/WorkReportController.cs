using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Model;
using BW.MMS.Web.Common;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using MatchStall;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NPOI.SS.UserModel;
using WorkSend;
using m_WorkReport = BW.MMS.BLL.m_WorkReport;
using v_WorkReport = BW.MMS.BLL.v_WorkReport;
using WorkReportType = BW.MMS.BLL.WorkReportType;
using System.IO;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class WorkReportController : Controller
    {
        //
        // GET: /WorkReport/
        BLL.m_WorkReport bllWorkReport = new m_WorkReport();
        BLL.v_WorkReport bllvWorkReport = new v_WorkReport();
        BLL.WorkReportType bllWorkReportType=new WorkReportType();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "用户编号", field = "vc_RealName", columnAttributes = new { align = "center", width = 80, sortable = true } });
            column.Add(new DataGridColumn { title = "本次工作内容", field = "vc_Content", columnAttributes = new { align = "center", width = 200, sortable = true } });
            column.Add(new DataGridColumn { title = "本次完成情况", field = "vc_PracticalCompletion", columnAttributes = new { align = "center", width = 200, sortable = true } }); 
            column.Add(new DataGridColumn { title = "下次工作内容", field = "vc_NextContent", columnAttributes = new { align = "center", width = 200, sortable = true } });
            column.Add(new DataGridColumn { title = "领导批复", field = "vc_Reply", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "报告类型", field = "workreporttypename", columnAttributes = new { align = "center", width = 80, sortable = true } });
            column.Add(new DataGridColumn { title = "上报时间", field = "dt_AddTime", columnAttributes = new { align = "center", width = 150, sortable = true, formatter = new { function = "data_string" } } });


            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }
        [ExceptionFilter]
        public JsonResult GetWorkReportList(int page, int rows, string sort, string order)
        {
            int record = 0;
            string paramSearchPersonName = Request["PersonName"];
            string paramSearchWorkReportType = Request["WorkReportType"];
            Session["WorkReportType"] = paramSearchWorkReportType;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(paramSearchPersonName))
            {

                sb.AppendFormat(" AND vc_RealName like '%{0}%'", paramSearchPersonName);
               
            }
            if (!string.IsNullOrEmpty(paramSearchWorkReportType))
            {
                sb.AppendFormat(" AND workreporttypename='{0}'", paramSearchWorkReportType);
            }
            List<Model.v_WorkReport> list = bllvWorkReport.GetPagingList(sb.ToString(), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };

            return Json(data);

        }


        /// <summary>
        /// 传感器信息删除
        /// </summary>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            string[] strs = id.Split(',');
            bool b = true;
            foreach (var str in strs)
            {
                Model.m_WorkReport model = bllWorkReport.GetModel(int.Parse(str));
                model.i_flag = 1;

                if (!bllWorkReport.Update(model))
                {
                    b = false;
                  
                }
               
            }

            if (b)
            {
        
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        /// <summary>
        /// 工作报告转发
        /// </summary>
        /// <returns></returns>
        public JsonResult Forward(string id)
        {
            string[] strs = id.Split(',');
            bool b = true;
            foreach (var str in strs)
            {
                Model.v_WorkReport model = bllvWorkReport.GetModel(int.Parse(str));
                string paramSearchWorkReportType = Session["WorkReportType"].ToString();
                string strFullPath = "";
                string strNewFullPath = "";
                
                if (paramSearchWorkReportType.Contains("日"))
                {
                    strFullPath = Server.MapPath("~/Reports/软件袁加富工作日报 15-08-25.xls");
                    strNewFullPath =strFullPath.Replace("袁加富", model.vc_RealName).Replace("15-08-25", DateTime.Now.ToString("yy-MM-dd"));
                    System.IO.File.Copy(strFullPath, strNewFullPath, true);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "本日完成" + DateTime.Now.ToString("(MM月dd日)") }, 4, 2);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "次日计划" + DateTime.Now.AddDays(1).ToString("(MM月dd日)") }, 8, 2);
                }
                 if (paramSearchWorkReportType.Contains("周"))
                {
                    strFullPath = Server.MapPath("~/Reports/软件袁加富工作周报 15-09-01.xls");
                    strNewFullPath = strFullPath.Replace("袁加富", model.vc_RealName).Replace("15-09-01", DateTime.Now.ToString("yy-MM-dd"));
                    System.IO.File.Copy(strFullPath, strNewFullPath, true);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "本周完成" + CalculateFirstDateOfWeek().ToString("(MM月dd日-") + CalculateFirstDateOfWeek().AddDays(4).ToString("MM月dd日)") }, 4, 2);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "次周计划" +  CalculateFirstDateOfWeek().AddDays(7).ToString("(MM月dd日-") + CalculateFirstDateOfWeek().AddDays(11).ToString("MM月dd日)") }, 8, 2);
                }
                
            

                DataTable dataTable = ExcelHelper.ExcelToDataTable(strNewFullPath, paramSearchWorkReportType);
                ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "被考核人：" + model.vc_Content }, 4, 4);
                ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "被考核人：" + model.vc_PracticalCompletion }, 5, 4);
                ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "被考核人：" + model.vc_NextContent }, 8, 4);
                ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "汇报人：" + model.vc_RealName }, 0, 1);
              
               
                SendEmail sendEmail = new SendEmail();

                sendEmail.SendMail(new string[] { "369961187@qq.com", "yuanjiafu2008@gmail.com" }, "yuanjiafu2008@163.com", model.vc_Reply, "软件袁加富工作" + paramSearchWorkReportType + " 15-08-25".Replace("袁加富", model.vc_RealName).Replace("15-08-25", DateTime.Now.ToString("yy-MM-dd")), "hale870424163");
                sendEmail.Attachments(strNewFullPath);
                sendEmail.Send();
            }

            if (b)
            {
                return Json(new { success = true, message = "转发成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        public  DateTime CalculateFirstDateOfWeek()
        {
            int i = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);
            return DateTime.Now.Subtract(ts);
        }
        /// <summary>
        /// 管理者工作报告
        /// </summary>
        /// <returns></returns>
        public JsonResult SendAdminEmail(string id)
        {
            string[] strs = id.Split(',');
            bool b = true;
            string paramSearchWorkReportType = Session["WorkReportType"].ToString();
            string strFullPath = Server.MapPath("~/Reports/软件李圣渠工作周报 15-09-02.xls");
            string strNewFullPath = "";
            if (paramSearchWorkReportType.Contains("日"))
            {
                 strFullPath = Server.MapPath("~/Reports/软件袁加富工作日报 15-08-25.xls");
                 strNewFullPath = strFullPath.Replace("袁加富", "李圣渠").Replace("15-08-25", DateTime.Now.ToString("yy-MM-dd"));
                 System.IO.File.Copy(strFullPath, strNewFullPath, true);
                 ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "本日完成" + DateTime.Now.ToString("(MM月dd日)") }, 4, 2);
                 ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "次日计划" + DateTime.Now.AddDays(1).ToString("(MM月dd日)") }, 8, 2);
            }
              if (paramSearchWorkReportType.Contains("周"))
            
            {

                strFullPath = Server.MapPath("~/Reports/软件袁加富工作周报 15-09-01.xls");
                strNewFullPath = strFullPath.Replace("袁加富", "李圣渠").Replace("15-09-01", CalculateFirstDateOfWeek().AddDays(4).ToString("yy-MM-dd"));
                   System.IO.File.Copy(strFullPath, strNewFullPath, true);
                 ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "本周完成" + CalculateFirstDateOfWeek().ToString("(MM月dd日-") + CalculateFirstDateOfWeek().AddDays(4).ToString("MM月dd日)") }, 4, 2);
                 ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "次周计划" + CalculateFirstDateOfWeek().AddDays(7).ToString("(MM月dd日-") + CalculateFirstDateOfWeek().AddDays(11).ToString("MM月dd日)") }, 8, 2);
            }
          

            ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "汇报人：" + "李圣渠" }, 0, 1);
         
            foreach (var str in strs)
            {
                Model.v_WorkReport model = bllvWorkReport.GetModel(int.Parse(str));
              
                if (model.vc_RealName == "李圣渠")
                {
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "李圣渠：" + model.vc_Content }, 4, 4);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "李圣渠：" + model.vc_PracticalCompletion }, 5, 4);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "李圣渠：" + model.vc_NextContent }, 8, 4);
                }
                if (model.vc_RealName == "袁加富")
                {
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "袁加富：" + model.vc_Content }, 4, 5);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "袁加富：" + model.vc_PracticalCompletion }, 5, 5);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "袁加富：" + model.vc_NextContent }, 8, 5);
                }
                if (model.vc_RealName == "吴芸芸")
                {
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "吴芸芸：" + model.vc_Content }, 4, 6);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "吴芸芸：" + model.vc_PracticalCompletion }, 5, 6);
                    ExcelHelper.UpdateExcel(strNewFullPath, paramSearchWorkReportType, new string[] { "吴芸芸：" + model.vc_NextContent }, 8, 6);
                }
               
             
             
            }
            SendEmail sendEmail = new SendEmail();
            sendEmail.SendMail(new string[] { "369961187@qq.com", "yuanjiafu2008@gmail.com" }, "yuanjiafu2008@163.com", "", "软件袁加富工作" + paramSearchWorkReportType + " 15-08-25".Replace("袁加富", "李圣渠").Replace("15-08-25", DateTime.Now.ToString("yy-MM-dd")), "hale870424163");
            sendEmail.Attachments(strNewFullPath);
            sendEmail.Send();
            if (b)
            {
                return Json(new { success = true, message = "转发成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        /// <summary>传感器信息修改
        /// 传感器信息修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {

            Model.m_WorkReport model = bllWorkReport.GetModel(id);
            if (model == null)
            {
                model = new Model.m_WorkReport();
                model.WorkReportType = 1;
            }
            return View(model);
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(Model.m_WorkReport entity)
        {
            if (entity.ID == 0)
            {
                if (Session["UserInfo"]!=null)
                entity.UserID = (Session["UserInfo"] as sys_UserEntity).ID;
                if (bllWorkReport.Add(entity) > 0)
                {
                    return Json(new { success = true, message = "添加成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "添加失败！" });
                }
            }
            else
            {

                if (bllWorkReport.Update(entity))
                {
                   
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "修改失败！" });
                }
            }

        }

        ///// <summary>绑定传感器类型
        /// 绑定传感器类型
        /// </summary>
        /// <returns></returns>
        public JsonResult GetWorkReportType()
        {
            return Json(bllWorkReportType.GetModelList(""));
        }

    }

}
