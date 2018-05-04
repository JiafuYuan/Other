using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BW.MMS.BLL;
using BW.MMS.Model;
using BW.MMS.Web.HtmlExtension.Easyui;

namespace BW.MMS.Web.Common
{
    public static class GridHelper
    {
        private static readonly GridConfigBLL bll = new GridConfigBLL();
        private static readonly GridColumnConfigBLL column = new GridColumnConfigBLL();

        public static List<List<DataGridColumn>> GetGridColumns(string GridKey)
        {
            List<GridConfigEntity> gridList = bll.GetModelList(string.Format("GridKeyName='{0}'", GridKey));
            if (gridList.Count == 0)
            {
                throw new KeyNotFoundException("没有找到对应的GridKey");
            }
            GridConfigEntity grid = gridList[0];
            List<GridColumnConfigEntity> list = column.GetModelList(string.Format("gridconfigID={0} and ParentID=0 ORDER BY showposition ASC", grid.ID));

            List<List<DataGridColumn>> columns = GeneralColumns(list, new List<List<DataGridColumn>>(), grid.ischk);
            if (columns.Count > 0)
            {
                if (grid.ischk)
                {
                    columns[0][0].columnAttributes = new { checkbox = true, rowspan = columns.Count };
                }
                for (int i = 0; i < columns.Count - 1; i++)
                {
                    foreach (DataGridColumn item in columns[i])
                    {
                        Dictionary<string, object> attributes = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(Newtonsoft.Json.JsonConvert.SerializeObject(item.columnAttributes));
                        if (!attributes.ContainsKey("colspan") && !attributes.ContainsKey("rowspan"))
                        {
                            attributes.Add("rowspan", columns.Count);
                            item.columnAttributes = attributes;
                        }
                    }
                }
            }
            return columns;
        }

        private static List<List<DataGridColumn>> GeneralColumns(List<GridColumnConfigEntity> columns, List<List<DataGridColumn>> GridColumns, bool iscbk)
        {
            List<DataGridColumn> GridRow = new List<DataGridColumn>();
            if (iscbk)
            {
                GridRow.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
                iscbk = false;
            }
            string columnsID = string.Empty;
            foreach (GridColumnConfigEntity model in columns)
            {
                columnsID += "," + model.ID;
                DataGridColumn item = new DataGridColumn();
                item.title = model.title;
                item.field = model.field;
                List<GridColumnConfigEntity> colspan = column.GetModelList(string.Format("ParentID={0} ORDER BY showposition ASC", model.ID));
                if (colspan.Count > 0)
                {
                    item.columnAttributes = new
                    {
                        align = model.align,
                        hidden = model.hidden,
                        sortable = model.sortable,
                        colspan = colspan.Count
                    };
                }
                else
                {
                    item.columnAttributes = new
                    {
                        width = model.width,
                        align = model.align,
                        hidden = model.hidden,
                        sortable = model.sortable
                    };
                }
                GridRow.Add(item);
            }
            GridColumns.Add(GridRow);
            List<GridColumnConfigEntity> ChildrenColums = column.GetModelList(string.Format("ParentID in({0}) ORDER BY showposition ASC", columnsID.Substring(1)));
            if (ChildrenColums.Count > 0)
            {
                GeneralColumns(ChildrenColums, GridColumns, iscbk);
            }
            return GridColumns;
        }
    }
}