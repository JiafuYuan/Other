using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.BLL;
using BW.MMS.Web.Common;
using System.IO;

namespace BW.MMS.Web.Controllers
{
    public class AreaController : BaseController
    {
        private readonly m_AreaBLL bll = new m_AreaBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "vc_Name", title = "区域名称", columnAttributes = new { align = "left", width = 180, sortable = true } });
            column.Add(new DataGridColumn { field = "vc_Code", title = "区域编号", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { field = "vc_Memo", title = "备注", columnAttributes = new { align = "center", width = 100 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        /// <summary>
        /// 首页视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }
        /// <summary>
        /// 编辑视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            m_AreaEntity entity = bll.GetModel(id);
            if (entity == null)
            {
                entity = new m_AreaEntity { i_parentid = 0 };
            }
            return View(entity);
        }
        /// <summary>
        /// 获取TreeGrid数据
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetGridList(string sort, string order)
        {
            string txtValue = Request["txtValue"];
            string where = " 1=1 and i_Flag=0 ";
            if (!string.IsNullOrEmpty(txtValue))
            {
                where += string.Format(" AND (vc_Code LIKE '%{0}%' OR vc_Name LIKE '%{0}%') ", Texthelper.SqlFilter(txtValue));
            }
            else
            {
                where += " AND i_parentid=0";
            }
            where += " ORDER BY " + sort + " " + order + "";
            List<m_AreaEntity> list = bll.GetModelList(where);



            if (list.Count > 0)
            {
                if (string.IsNullOrEmpty(txtValue))
                {
                    return Json(InitTree(list, true));
                }
                else
                {
                    return Json(InitTree(list, false));
                }
            }
            return Json(new List<TreeGridItem>());
        }
        /// <summary>
        /// 获取区域Tree目录
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetAreaDirectory()
        {
            TreeGridItem item = new TreeGridItem();
            item.id = 0;
            item.text = "所有区域";
            List<m_AreaEntity> list = bll.GetModelList(string.Format("i_parentid={0}  and i_Flag=0 ", item.id));
            item.children = InitTree(list, false);
            List<TreeGridItem> tree = new List<TreeGridItem>();
            tree.Add(item);
            return Json(tree);
        }
        /// <summary>
        /// 获取区域Tree列表
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetAreaList()
        {
            List<m_AreaEntity> list = bll.GetModelList("i_parentid=0  and i_Flag=0 ");
            return Json(InitTree(list, true));
        }
        /// <summary>
        /// 编辑区域
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_AreaEntity entity)
        {
            entity.i_parentid = 0;
            if (entity.ID == 0)
            {
                if (bll.GetModelList(string.Format("vc_Name='{0}' and i_Flag=0", entity.vc_Name)).Count > 0)
                {
                    return Json(new { success = false, message = "区域名称已存在！" });
                }
                if (bll.GetModelList(string.Format("vc_Code='{0}' and i_Flag=0", entity.vc_Code)).Count > 0)
                {
                    return Json(new { success = false, message = "区域编号已存在！" });
                }
                if (bll.Add(entity) > 0)
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
                if (bll.GetModelList(string.Format("vc_Name='{0}' AND ID<>{1} and i_Flag=0", entity.vc_Name, entity.ID)).Count > 0)
                {
                    return Json(new { success = false, message = "区域名称已存在！" });
                }
                if (bll.GetModelList(string.Format("vc_Code='{0}' AND ID<>{1} and i_Flag=0", entity.vc_Code, entity.ID)).Count > 0)
                {
                    return Json(new { success = false, message = "区域编号已存在！" });
                }
                if (bll.Update(entity))
                {
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "修改失败！" });
                }
            }
        }
        /// <summary>
        /// 删除区域
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Delete(string id)
        {
            v_SensorBLL sensor = new v_SensorBLL();
            if (sensor.GetModelList(string.Format("AreaID in(select * from dbo.GetAreaChildID({0}))", id)).Count > 0)
            {
                return Json(new { success = false, message = "区域已存在传感器，无法删除！" });
            }
            if (bll.Delete(Convert.ToInt32(id)))
            {
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }

        /// <summary>
        /// 递归添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<TreeGridItem> InitTree(List<m_AreaEntity> list, bool recursion)
        {
            List<TreeGridItem> nodes = new List<TreeGridItem>();
            TreeGridItem node;
            foreach (m_AreaEntity entity in list)
            {
                node = new TreeGridItem();
                node.id = entity.ID;
                node.vc_Code = entity.vc_Code;
                node.vc_Name = entity.vc_Name;
                node.text = entity.vc_Name;
                node.vc_Memo = entity.vc_Memo;
                node.i_parentid = entity.i_parentid;
                List<m_AreaEntity> children = bll.GetModelList(string.Format("i_parentid={0}  and i_Flag=0 ", entity.ID));
                if (children.Count > 0 && recursion)
                {
                    node.children = InitTree(children, recursion);
                    node.leaf = false;
                }
                else
                {
                    node.leaf = true;
                }
                nodes.Add(node);
            }
            return nodes;
        }

        /// <summary>
        /// TreeGrid模版
        /// </summary>
        class TreeGridItem
        {
            public int id { get; set; }
            public string vc_Code { get; set; }
            public string text { get; set; }
            public string vc_Name { get; set; }
            public string vc_Memo { get; set; }
            public bool leaf { get; set; }
            public int? i_parentid { get; set; }
            public List<TreeGridItem> children { get; set; }

        }
    }
}
