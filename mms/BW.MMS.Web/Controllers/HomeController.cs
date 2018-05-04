using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using System.Text;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Common;
using System.Data;
using Newtonsoft.Json.Converters;
using System.IO;

namespace BW.MMS.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        // GET: /SensorManager/
        private readonly m_CDR bll = new m_CDR();


        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();

            column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { hidden = true } });
            column.Add(new DataGridColumn { title = "当前时间标签", field = "dt_SetupTime", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "主叫号码", field = "vc_CallingNum", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "被叫号码", field = "vc_CalledNum", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "呼叫时间", field = "dt_ConnectTime", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "接通时间", field = "dt_AnswerTime", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "挂断时间", field = "dt_DisconnectTime", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "持续时长", field = "i_Duration", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "录音播放", field = "vc_RecPath", columnAttributes = new { align = "center", width = 100, sortable = true, formatter = new { function = "RecPath" } } });

            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult GetCdrList(int page, int rows, string sort, string order)
        {
            int record = 0;
            string paramCallingName = Request["CallingName"];
            string paramCalledName = Request["CalledName"];
            string paramStartTime = Request["StartTime"];
            string paramOverTime = Request["OverTime"];

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(paramCallingName))
            {
                sb.Append(" AND vc_CallingNum LIKE '%" + Texthelper.SqlFilter(paramCallingName) + "%'");
            }
            if (!string.IsNullOrEmpty(paramCalledName))
            {
                sb.Append(" AND vc_CalledNum LIKE '%" + Texthelper.SqlFilter(paramCalledName) + "%'");
            }
            if (!string.IsNullOrEmpty(paramStartTime))
            {
                paramStartTime = (DateTime.Parse(paramStartTime)).ToString("yyyy-MM-dd 00:00:00");
                sb.Append(" AND dt_ConnectTime >= '" + paramStartTime + "'");
            }
            if (!string.IsNullOrEmpty(paramOverTime))
            {
                paramOverTime = (DateTime.Parse(paramOverTime)).ToString("yyyy-MM-dd 23:59:59");
                sb.Append(" AND dt_DisconnectTime<= '" + paramOverTime + "'");
            }
            DataTable list = bll.GetPagingList(sb.ToString(), page, rows, sort, order, out record);
            IsoDateTimeConverter itc = new IsoDateTimeConverter();
            itc.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(new { total = record, rows = list }, itc));
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult PlayWav()
        {
            string paramwav = Request["playWav"];
            string paramw = Path.GetFileNameWithoutExtension(paramwav);
            try
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(paramw, @"^(\d{8}_)(\d{6}_)(\d{4}_)(\d{4})$"))
                {
                    string[] strs = paramwav.Split('_');
                    DateTime dt = DateTime.ParseExact(strs[0] + "_" + strs[1], "yyyyMMdd_HHmmss",
                                                      System.Globalization.CultureInfo.CurrentCulture);
                    ViewData["recname"] = String.Format("正在播放{0}与{1}在{2}时的录音", strs[0], strs[1],
                                                        dt.ToString("yyyy-MM-dd HH:mm:ss"));
                    string parampath = Server.MapPath("~/Resouce/" + paramwav);
                    if (!System.IO.File.Exists(parampath))
                    {
                        TempData["recname"] = "录音文件不存在";
                        return RedirectToAction("Error");
                    }
                    ViewData["playWav"] = paramwav;
                }
                else
                {
                    TempData["recname"] = "录音格式不正确";
                    return RedirectToAction("Error");
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["recname"] = ex.Message;
                return RedirectToAction("Error");
            }
        }
    }
}