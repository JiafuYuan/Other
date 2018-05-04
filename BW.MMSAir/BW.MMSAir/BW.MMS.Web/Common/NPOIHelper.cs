using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.Util;
using System.Reflection;
using System.Data;

namespace BW.MMS.Web.Common
{
    public class NPOIHelper
    {
        private HSSFWorkbook _workbook;

        public NPOIHelper()
        {
            _workbook = new HSSFWorkbook();
            #region 文件属性相关信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "南京北路自动化系统有限责任公司";
                _workbook.DocumentSummaryInformation = dsi;
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "NjBestWay";
                si.ApplicationName = "创建程序信息";
                si.Comments = "软件部";
                si.Title = "报表导出";
                si.Subject = "报表导出";
                si.CreateDateTime = DateTime.Now;
                _workbook.SummaryInformation = si;
            }
            #endregion
        }

        private void CreateHead(HSSFSheet sheet, List<DataGridColumn> head)
        {
            HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;
            HSSFCellStyle style = _workbook.CreateCellStyle() as HSSFCellStyle;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
            style.FillForegroundColor = HSSFColor.GREY_50_PERCENT.index;
            HSSFFont font = _workbook.CreateFont() as HSSFFont;
            font.FontHeightInPoints = 10;
            font.Boldweight = 700;
            style.SetFont(font);
            for (int i = 0, columnsIndex = 0; i < head.Count; i++)
            {
                if (head[i].field == "cbk")
                {
                    continue;
                }
                ICell cell = headerRow.CreateCell(columnsIndex);
                cell.CellStyle = style;
                cell.SetCellValue(head[i].title);
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(head[i].columnAttributes);
                Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(str);
                if (dic.ContainsKey("width"))
                {
                    sheet.SetColumnWidth(columnsIndex, Convert.ToInt32(dic["width"]) * 40);
                }
                columnsIndex++;
            }
        }

        public MemoryStream ExportExcel<T>(List<DataGridColumn> head, List<T> data, string sheetName)
        {

            HSSFSheet sheet = _workbook.CreateSheet(sheetName) as HSSFSheet;

            HSSFCellStyle style = _workbook.CreateCellStyle() as HSSFCellStyle;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
            style.FillForegroundColor = HSSFColor.GREY_50_PERCENT.index;

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            for (int rowIndex = 0; rowIndex < data.Count; rowIndex++)
            {
                if (rowIndex + 1 == 65535 || rowIndex == 0)
                {
                    if (rowIndex + 1 == 65535)
                    {
                        sheet = _workbook.CreateSheet(sheetName + "-1") as HSSFSheet;
                    }
                    CreateHead(sheet, head);
                }
                HSSFRow dataRow = sheet.CreateRow(rowIndex + 1) as HSSFRow;
                int columnIndex = 0;
                foreach (DataGridColumn item in head)
                {
                    foreach (PropertyInfo column in properties)
                    {
                        if (item.field == column.Name)
                        {
                            ICell cell = dataRow.CreateCell(columnIndex);
                            cell.CellStyle = style;
                            cell.SetCellValue(column.GetValue(data[rowIndex], null) == null ? "" : column.GetValue(data[rowIndex], null).ToString());
                            columnIndex++;
                        }
                    }
                }
            }
            using (MemoryStream ms = new MemoryStream())
            {
                _workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }
        }

        public byte[] ExportExcel(List<DataGridColumn> head, DataTable data, string sheetName)
        {
            HSSFSheet sheet = _workbook.CreateSheet(sheetName) as HSSFSheet;
            HSSFCellStyle dateCellStyle = _workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFDataFormat format = _workbook.CreateDataFormat() as HSSFDataFormat;
            dateCellStyle.DataFormat = format.GetFormat("yyyy-mm-dd");


            HSSFCellStyle style = _workbook.CreateCellStyle() as HSSFCellStyle;
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;
            style.FillForegroundColor = HSSFColor.GREY_50_PERCENT.index;

            for (int rowIndex = 0; rowIndex < data.Rows.Count; rowIndex++)
            {
                if (rowIndex + 1 == 65535 || rowIndex == 0)
                {
                    if (rowIndex + 1 == 65535)
                    {
                        sheet = _workbook.CreateSheet(sheetName + "-1") as HSSFSheet;
                    }
                    CreateHead(sheet, head);
                }

                HSSFRow dataRow = sheet.CreateRow(rowIndex + 1) as HSSFRow;
                int columnIndex = 0;
                foreach (DataColumn column in data.Columns)
                {
                    foreach (DataGridColumn item in head)
                    {
                        if (column.ColumnName.Equals(item.field))
                        {
                            HSSFCell newCell = dataRow.CreateCell(columnIndex) as HSSFCell;
                            dataRow.GetCell(columnIndex).CellStyle = style;
                            string drValue = data.Rows[rowIndex][column.ColumnName].ToString();
                            switch (column.DataType.ToString())
                            {
                                case "System.String":
                                    newCell.SetCellValue(drValue);
                                    break;
                                case "System.DateTime":
                                    DateTime dateV;
                                    DateTime.TryParse(drValue, out dateV);
                                    newCell.SetCellValue(dateV);
                                    newCell.CellStyle = dateCellStyle;
                                    break;
                                case "System.Boolean":
                                    bool boolV = false;
                                    bool.TryParse(drValue, out boolV);
                                    newCell.SetCellValue(boolV);
                                    break;
                                case "System.Int16":
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(drValue, out intV);
                                    newCell.SetCellValue(intV);
                                    break;
                                case "System.Decimal":
                                case "System.Double":
                                    double doubV = 0;
                                    double.TryParse(drValue, out doubV);
                                    newCell.SetCellValue(doubV);
                                    break;
                                case "System.DBNull":
                                    newCell.SetCellValue("");
                                    break;
                                default:
                                    newCell.SetCellValue("");
                                    break;
                            }
                            columnIndex++;
                        }
                    }
                }

            }
            using (MemoryStream ms = new MemoryStream())
            {
                _workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms.ToArray();
            }
        }

    }
}