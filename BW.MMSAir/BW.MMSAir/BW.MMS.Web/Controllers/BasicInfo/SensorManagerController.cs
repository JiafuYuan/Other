using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.Web.Common;
using System.IO;
using BW.MMS.BLL;
using System.Text;
using System.Data;

namespace BW.MMS.Web.Controllers
{
    public class SensorManagerController : BaseController
    {

        // GET: /SensorManager/
        private readonly m_SensorBLL bll = new m_SensorBLL();
        private readonly v_SensorBLL vbll = new v_SensorBLL();
        m_SensorNodesBLL snBll = new m_SensorNodesBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "传感器编号", field = "vc_Code", columnAttributes = new { align = "center", width = 80, sortable = true } });
            column.Add(new DataGridColumn { title = "传感器类型", field = "TypeName", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "安装位置", field = "vc_Address", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "所属区域", field = "AreaName", columnAttributes = new { align = "center", width = 80, sortable = true } });
            column.Add(new DataGridColumn { title = "使用单位", field = "DeptName", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "能耗类型", field = "EnergyTypeName", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "备注", field = "vc_Memo", columnAttributes = new { align = "center", width = 100, sortable = true } });

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
        public JsonResult GetSensorList(int page, int rows, string sort, string order)
        {
            int record = 0;
            string paramSearchName = Request["name"];
            string paramSearchType = Request["type"];
            string paramSearchArea = Request["area"];
            string paramSearchDept = Request["dept"];
            string paramSearchEnergy = Request["energy"];

            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(paramSearchName))
            {
                sb.Append(" AND vc_code LIKE '%" + Texthelper.SqlFilter(paramSearchName) + "%'");
            }
            if (!string.IsNullOrEmpty(paramSearchType))
            {
                sb.AppendFormat(" AND TypeName='{0}'", paramSearchType);
            }
            if (!string.IsNullOrEmpty(paramSearchArea))
            {
                sb.AppendFormat(" AND AreaID in(select * from dbo.GetAreaChildID({0}))", paramSearchArea);
            }
            if (!string.IsNullOrEmpty(paramSearchDept))
            {
                sb.AppendFormat(" AND DeptID in(select * from  dbo.GetDeptIDs({0}))", paramSearchDept);
            }
            if (!string.IsNullOrEmpty(paramSearchEnergy))
            {
                sb.AppendFormat(" AND EnergyTypeName='{0}'", paramSearchEnergy);
            }

            List<v_SensorEntity> list = vbll.GetPagingList(sb.ToString(), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
            return Json(data);
        }


        /// <summary>
        /// 传感器信息删除
        /// </summary>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            if (bll.DeleteList(id))
            {
                Boolean b = snBll.DeleteWhere(" SensorID in(" + id + ")");
                return Json(new { success = true, message = "删除成功！" });
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
            ViewData["GridColumn"] = GetSensorNodesColumns();
            m_SensorEntity model = bll.GetModel(id);
            if (model == null)
            {
                model = new m_SensorEntity();
            }
            return View(model);
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_SensorEntity entity)
        {

            DataTable dtNodes = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Request["NodesData"]);
            if (dtNodes.Rows.Count > 0)
            {
                DataView dv = new DataView(dtNodes);
                if (dv.ToTable(true, "vc_Address").Rows.Count < dtNodes.Rows.Count)
                {
                    DataRow[] dN = dtNodes.Select(" vc_Address=''");
                    if (dN.Length < 2)
                    {
                        return Json(new { success = false, message = "插入数据有重复结点地址" });
                    }
                }
            }
            m_SensorNodesEntity snEntity = new m_SensorNodesEntity();
            if (entity.ID == 0)
            {

                List<m_SensorEntity> sensors = bll.GetModelList(string.Format("vc_Code='{0}'", entity.vc_Code));
                if (sensors.Count > 0)
                {
                    return Json(new { success = false, message = "传感器编号已经存在！" });
                }

                for (int i = 0; i < dtNodes.Rows.Count; i++)
                {
                    DataTable dtSensorNodes = snBll.GetList(" vc_Address='" + dtNodes.Rows[i]["vc_Address"].ToString() + "'").Tables[0];
                    if (dtSensorNodes.Rows.Count > 0)
                    {
                        return Json(new { success = false, message = "" + dtNodes.Rows[i]["sensorAddress"].ToString() + "传感器" + dtNodes.Rows[i]["sensorCode"].ToString() + "已存在结点地址'" + dtNodes.Rows[i]["vc_Address"].ToString() + "'！" });
                    }
                }
                if (bll.Add(entity) > 0)
                {
                    int getsensorID = bll.GetMaxId() - 1;
                    snEntity.SensorID = getsensorID;
                    for (int i = 0; i < dtNodes.Rows.Count; i++)
                    {
                        DataTable dtSensorNodes = snBll.GetList(" vc_Address='" + dtNodes.Rows[i]["vc_Address"].ToString() + "'").Tables[0];
                        if (!string.IsNullOrEmpty(dtNodes.Rows[i]["vc_Address"].ToString()))
                        {
                            snEntity.NodeID = int.Parse(dtNodes.Rows[i]["ID"].ToString());
                            snEntity.vc_Address = dtNodes.Rows[i]["vc_Address"].ToString();
                            snBll.Add(snEntity);
                        }
                    }
                    return Json(new { success = true, message = "添加成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "添加失败！" });
                }
            }
            else
            {
                List<m_SensorEntity> sensors = bll.GetModelList(string.Format("vc_Code='{0}' and ID<>{1}", entity.vc_Code, entity.ID));
                if (sensors.Count > 0)
                {
                    return Json(new { success = false, message = "传感器编号已经存在！" });
                }
                if (true)
                {
                    snEntity.SensorID = entity.ID;
                    for (int i = 0; i < dtNodes.Rows.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(dtNodes.Rows[i]["vc_Address"].ToString()))
                        {
                            DataTable dtSensorNodes = snBll.GetList("  vc_Address='" + dtNodes.Rows[i]["vc_Address"].ToString() + "'").Tables[0];

                            if (!string.IsNullOrEmpty(dtNodes.Rows[i]["vc_Address"].ToString()))
                            {
                                DataRow[] dr = dtSensorNodes.Select(" SensorID=" + entity.ID + " ");
                                if (dr.Length == 0)
                                {
                                    if (dtSensorNodes.Rows.Count > 0)
                                    {
                                        if (dtSensorNodes.Rows.Count > 0)
                                        {
                                            return Json(new { success = false, message = "" + dtNodes.Rows[i]["sensorAddress"].ToString() + "传感器" + dtNodes.Rows[i]["sensorCode"].ToString() + "已存在结点地址'" + dtNodes.Rows[i]["vc_Address"].ToString() + "'！" });
                                        }
                                    }
                                }
                            }
                        }
                    }


                    if (bll.Update(entity))
                    {
                        for (int i = 0; i < dtNodes.Rows.Count; i++)
                        {
                            //DataTable dtSensorNodes = snBll.GetList(" vc_Address='" + dtNodes.Rows[i]["vc_Address"].ToString() + "'").Tables[0];
                            if (!string.IsNullOrEmpty(dtNodes.Rows[i]["nodesID"].ToString()))
                            {
                                snEntity.ID = int.Parse(dtNodes.Rows[i]["nodesID"].ToString());
                                snEntity.NodeID = int.Parse(dtNodes.Rows[i]["ID"].ToString());
                                if (string.IsNullOrEmpty(dtNodes.Rows[i]["vc_Address"].ToString()))
                                {
                                    snBll.Delete(snEntity.ID);
                                }
                                else
                                {
                                    snEntity.vc_Address = dtNodes.Rows[i]["vc_Address"].ToString();
                                    snBll.Update(snEntity);
                                }
                            }
                            else
                            {
                                snEntity.NodeID = int.Parse(dtNodes.Rows[i]["ID"].ToString());
                                if (!string.IsNullOrEmpty(dtNodes.Rows[i]["vc_Address"].ToString()))
                                {
                                    snEntity.vc_Address = dtNodes.Rows[i]["vc_Address"].ToString();
                                    snBll.Add(snEntity);
                                }
                            }
                        }
                        return Json(new { success = true, message = "修改成功！" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "修改失败！" });
                    }
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<List<DataGridColumn>> GetSensorNodesColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            string editor = "{type:'text'}";
            column.Add(new DataGridColumn { title = "结点名称", field = "vc_Name", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "结点地址", field = "vc_Address", columnAttributes = new { align = "center", width = 150, editor = new { function = editor } } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetSensorNodesList()
        {

            DataTable dt = snBll.GetNodesList(int.Parse(Request["sensorId"].ToString())).Tables[0];
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        #region 下拉菜单数据绑定

        private readonly m_SensorTypeBLL SensorTypeBLL = new m_SensorTypeBLL();
        ///// <summary>绑定传感器类型
        /// 绑定传感器类型
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSensorType()
        {
            return Json(SensorTypeBLL.GetModelList("i_Flag=0"));
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetSensor(int id)
        {
            return Json(vbll.GetModelList(string.Format("TypeID={0}", id)));
        }
        ///// <summary>绑定区域信息
        ///// 绑定区域信息
        ///// </summary>
        ///// <returns></returns>
        ////private readonly m_AreaBLL areabll = new m_AreaBLL();
        ////public JsonResult GetArea()
        ////{
        ////    return Json(areabll.GetModelList(""));
        ////}

        //private readonly m_DeptBLL deptbll = new m_DeptBLL();
        ///// <summary>绑定使用单位
        ///// 绑定使用单位
        ///// </summary>
        ///// <returns></returns>
        //public JsonResult GetDeptType()
        //{
        //    return Json(deptbll.GetModelList(""));
        //}

        private readonly m_EnergyTypeBLL enertypebll = new m_EnergyTypeBLL();


        /// <summary>
        /// 绑定能耗类型
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetEnergyType()
        {
            return Json(enertypebll.GetModelList(""));
        }


        /// <summary>
        /// 绑定PLCID
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetPLCID()
        {
            m_PLCBLL plcbll = new m_PLCBLL();
            m_PLCEntity plcEntity = new m_PLCEntity();
            plcEntity.id = 0;
            plcEntity.vc_name = "==请选择==";
            plcEntity.vc_IP = "";
            List<m_PLCEntity> list = new List<m_PLCEntity>();
            list = plcbll.GetModelList("i_Flag<>1");
            list.Insert(0, plcEntity);
            return Json(list);
        }
        #endregion


    }
}