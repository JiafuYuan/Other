﻿//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , DZD , Ltd .
//-------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


namespace MatchStall
{
    /// <summary>
    /// Excel操作类，这里的NPOI使用的是2.0.1 (beta1)版本的
    ///
    /// 修改纪录
    ///
    ///		2013-10-25 版本：1.0 yanghenglian 创建主键，注意命名空间的排序。
    ///		2013-11-01 版本：1.0 yanghenglian 添加了支持B/S的导出和导入以及C/S的导出和导入功能，代码感觉可以在优化，开心。
    ///		2014-01-16 版本：1.0 yanghenglian 添加了支持xlsxExcel文件读取判断
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>yanghenglian</name>
    ///		<date>2013-11-01</date>
    /// </author>
    /// </summary>
    public class ExcelHelper
    {
        private static HSSFWorkbook _hssfworkbook;

        /********************************************************下面的五个是最终版本适合B/S和C/S*****************************************************/

        #region ExcelToDataTable(string strExcelFileName, string strSheetName) Excel转换成DataTable--B/S和C/S都可以使用

        /// <summary>
        /// Excel转换成DataTable
        /// </summary>
        /// <param name="strExcelFileName">文件路径</param>
        /// <param name="strSheetName">Excel中对应的sheet表单名称,如:sheet1,sheet2</param>
        /// <returns>数据集</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:检查 SQL 查询是否存在安全漏洞")]
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" +
                             "Extended Properties=Excel 5.0;";
            string strExcel = string.Format("select * from [{0}$]", strSheetName);
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);
                conn.Close();
                return ds.Tables[strSheetName];
            }
        }

        #endregion

        #region DataTable ExcelToDataTable(string strFileName, int sheetIndex = 0) 根据索引读取Sheet表数据，默认读取第一个sheet--B/S和C/S都可以使用

        /// <summary>读取excel
        /// 根据索引读取Sheet表数据，默认读取第一个sheet
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <param name="sheetIndex">sheet表的索引，从0开始</param>
        /// <returns>数据集</returns>
        public static DataTable ExcelToDataTable(string strFileName, int sheetIndex = 0)
        {
            DateTime dateTime = DateTime.Now;
            DataTable dt = new DataTable();
            HSSFWorkbook hssfworkbook = null;
            XSSFWorkbook xssfworkbook = null;
            string fileExt = Path.GetExtension(strFileName);//获取文件的后缀名
            try
            {
                FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                if (fileExt == ".xls")
                    hssfworkbook = new HSSFWorkbook(file);
                else if (fileExt == ".xlsx")
                    xssfworkbook = new XSSFWorkbook(file);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            if (hssfworkbook != null)
            {
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(sheetIndex);
                if (sheet != null)
                {
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        HSSFRow row = (HSSFRow)sheet.GetRow(i);
                        DataRow dataRow = dt.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                if (row.GetCell(j).CellType == CellType.Numeric)
                                {
                                    if (DateUtil.IsCellDateFormatted(row.GetCell(j)))
                                    {
                                        dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue).ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    else
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            else if (xssfworkbook != null)
            {
                XSSFSheet xSheet = (XSSFSheet)xssfworkbook.GetSheetAt(sheetIndex);
                if (xSheet != null)
                {
                    System.Collections.IEnumerator rows = xSheet.GetRowEnumerator();
                    XSSFRow headerRow = (XSSFRow)xSheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        XSSFCell cell = (XSSFCell)headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i = (xSheet.FirstRowNum + 1); i <= xSheet.LastRowNum; i++)
                    {
                        XSSFRow row = (XSSFRow)xSheet.GetRow(i);
                        DataRow dataRow = dt.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {

                            if (row.GetCell(j) != null)
                            {
                                if (row.GetCell(j).CellType == CellType.Numeric)
                                {
                                    if (DateUtil.IsCellDateFormatted(row.GetCell(j)))
                                    {
                                        dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue).ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    else
                                    {

                                        dataRow[j] = row.GetCell(j).ToString();

                                    }
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            return dt;
        }

        #endregion

        #region DataGridViewToExcel(DataGridView myDgv, string strHeaderText, string strFileName) DataGridView导出到Excel文件--C/S

        /// <summary>
        /// C/S Winform中DataGridView导出数据到Excel
        /// </summary>
        /// <param name="myDgv">DataGridView控件名称</param>
        /// <param name="saveFileName">保存的文件名称，默认没有，调用的时候最好加上，中英文都支持</param>
        /// <param name="isOpen">导出后是否打开文件和所在文件夹</param>
        /// <param name="saveFilePath">默认保存在“我的文档”中，可自定义保存的文件夹路径</param>
        /// <param name="strHeaderText">Excel中第一行的标题文字，默认没有，可以自定义</param>
        /// <param name="titleNames">Excel中列名的数组，默认绑定GridView的列名</param>
      

        #endregion

        /********************************************************分割线往下方法不用与导入导出*********************************************************/

        #region DataGridViewToExcel(DataGridView myDgv, string strHeaderText) DataTable导出到Excel的MemoryStream

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="myDgv">DataGridView控件名称</param>
        /// <param name="strHeaderText">第一行标题头</param>
        /// <param name="titleNames">列名称数组</param>
        /// <returns>内存流</returns>
    
        #endregion

        #region GetExcelStream() 工作簿中的数据流写入到根目录

        /// <summary>
        /// 写入到内存流中
        /// </summary>
        /// <returns></returns>
        private static MemoryStream GetExcelStream()
        {
            //Write the stream data of workbook to the root directory--工作簿中的数据流写入到根目录
            MemoryStream file = new MemoryStream();
            _hssfworkbook.Write(file);
            return file;
        }

        #endregion

        #region GenerateData(DataTable sourceDt, string[] titleNames, string strHeadName, string sheetName = "Sheet1") 构建数据集，每一个Sheet表

        /// <summary>
        /// 构建数据集，每一个Sheet表
        /// </summary>
        /// <param name="sourceDt">数据源</param>
        /// <param name="titleNames">列名</param>
        /// <param name="strHeadName">第一行显示标题</param>
        /// <param name="sheetName">需要创建的表的名称，默认是Sheet1</param>
        /// <param name="isOpen">是否打开文件</param>
        private static void GenerateData(DataTable sourceDt, string[] titleNames, string strHeadName,
            string sheetName = "Sheet1")
        {
            ISheet sheet1 = _hssfworkbook.CreateSheet(sheetName);
            int rowIndex = 0;
            if (!string.IsNullOrEmpty(strHeadName)) //头部大标题
            {
                sheet1.CreateRow(rowIndex).CreateCell(0).SetCellValue(strHeadName);
                rowIndex++;
            }
            IRow rowSecond = sheet1.CreateRow(rowIndex);
            if (titleNames != null) //构建自定义列标题
            {
                if (titleNames.Length > 0)
                {
                    for (int k = 0; k < titleNames.Length; k++)
                    {
                        var cell = rowSecond.CreateCell(k);
                        cell.SetCellValue(titleNames[k]);
                        cell.CellStyle = Getcellstyle(_hssfworkbook, stylexls.头);
                    }
                    rowIndex++;
                }
            }
            else //构建DataTable的列标题
            {
                if (sourceDt.Columns.Count > 0)
                {
                    for (int i = 0; i < sourceDt.Columns.Count; i++)
                    {
                        var cell = rowSecond.CreateCell(i);
                        cell.SetCellValue(sourceDt.Columns[i].ColumnName);
                        cell.CellStyle = Getcellstyle(_hssfworkbook, stylexls.头);
                    }
                    rowIndex++;
                }
            }

            if (sourceDt != null && sourceDt.Rows.Count > 0)
            {
                for (int i = 0; i < sourceDt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(rowIndex++);
                    for (int j = 0; j < sourceDt.Columns.Count; j++)
                    {
                        row.CreateCell(j).SetCellValue(sourceDt.Rows[i][j].ToString());
                    }
                }
            }
        }

        #endregion

        #region InitializeWorkbook() 导出文件的属性详细信息

        /// <summary>
        /// 导出文件的属性详细信息
        /// </summary>
        private static void InitializeWorkbook()
        {
            _hssfworkbook = new HSSFWorkbook();

            #region 右击文件 属性信息

            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "DZD";
                _hssfworkbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息"; //填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                _hssfworkbook.SummaryInformation = si;
            }

            #endregion
        }

        #endregion

        #region 定义单元格常用到样式

        private static ICellStyle Getcellstyle(IWorkbook wb, stylexls str)
        {
            ICellStyle cellStyle = wb.CreateCellStyle();

            //定义几种字体  
            //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
            IFont font12 = wb.CreateFont();
            font12.FontHeightInPoints = 14;
            font12.FontName = "宋体";


            IFont font = wb.CreateFont();
            font.FontName = "宋体";
            //font.Underline = 1;下划线  


            IFont fontcolorblue = wb.CreateFont();
            fontcolorblue.Color = HSSFColor.OliveGreen.Blue.Index;
            fontcolorblue.IsItalic = true; //下划线  
            fontcolorblue.FontName = "宋体";


            //边框  
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Dotted;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Hair;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Hair;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Dotted;
            //边框颜色  
            cellStyle.BottomBorderColor = HSSFColor.OliveGreen.Blue.Index;
            cellStyle.TopBorderColor = HSSFColor.OliveGreen.Blue.Index;

            //背景图形，我没有用到过。感觉很丑  
            //   cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.GREEN.index;
            //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
            // cellStyle.FillForegroundColor = HSSFColor.WHITE.index;
            // cellStyle.FillPattern = FillPatternType.NO_FILL;  
            cellStyle.FillBackgroundColor = HSSFColor.Maroon.Index;

            //水平对齐  
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

            //垂直对齐  
            cellStyle.VerticalAlignment = VerticalAlignment.Center;

            //自动换行  
            // cellStyle.WrapText = true;

            //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
            cellStyle.Indention = 0;

            //上面基本都是设共公的设置  
            //下面列出了常用的字段类型  
            switch (str)
            {
                case stylexls.头:
                    // cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
                    cellStyle.SetFont(font12);
                    break;
                case stylexls.时间:
                    IDataFormat datastyle = wb.CreateDataFormat();

                    cellStyle.DataFormat = datastyle.GetFormat("yyyy/mm/dd");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.数字:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.钱:
                    IDataFormat format = wb.CreateDataFormat();
                    cellStyle.DataFormat = format.GetFormat("￥#,##0");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.url:
                    fontcolorblue.Underline = FontUnderlineType.Single;
                    cellStyle.SetFont(fontcolorblue);
                    break;
                case stylexls.百分比:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.中文大写:
                    IDataFormat format1 = wb.CreateDataFormat();
                    cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.科学计数法:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                    cellStyle.SetFont(font);
                    break;
                case stylexls.默认:
                    cellStyle.SetFont(font);
                    break;
            }
            return cellStyle;
        }

        #endregion

        #region 定义单元格常用到样式的枚举

        public enum stylexls
        {
            头,
            url,
            时间,
            数字,
            钱,
            百分比,
            中文大写,
            科学计数法,
            默认
        }

        #endregion

        #region 更新excel中的数据
        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[] updateData, int coluid, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int i = 0; i < updateData.Length; i++)
            {
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                    {
                        sheet1.CreateRow(i + rowid);
                    }
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                    {
                        sheet1.GetRow(i + rowid).CreateCell(coluid);
                    }

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    // wl.WriteLogs(ex.ToString());
                    throw;
                }
            }
            try
            {
                readfile.Close();
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                // wl.WriteLogs(ex.ToString());
            }

        }

        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, string[][] updateData, int[] coluids, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int j = 0; j < coluids.Length; j++)
            {
                for (int i = 0; i < updateData[j].Length; i++)
                {
                    try
                    {
                        if (sheet1.GetRow(i + rowid) == null)
                        {
                            sheet1.CreateRow(i + rowid);
                        }
                        if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        {
                            sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                        }
                        sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                    }
                    catch (Exception ex)
                    {
                        // wl.WriteLogs(ex.ToString());
                    }
                }
            }
            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }
        }

        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluid">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[] updateData, int coluid, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int i = 0; i < updateData.Length; i++)
            {
                try
                {
                    if (sheet1.GetRow(i + rowid) == null)
                    {
                        sheet1.CreateRow(i + rowid);
                    }
                    if (sheet1.GetRow(i + rowid).GetCell(coluid) == null)
                    {
                        sheet1.GetRow(i + rowid).CreateCell(coluid);
                    }

                    sheet1.GetRow(i + rowid).GetCell(coluid).SetCellValue(updateData[i]);
                }
                catch (Exception ex)
                {
                    //wl.WriteLogs(ex.ToString());
                    throw;
                }
            }
            try
            {
                readfile.Close();
                FileStream writefile = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }

        }

        /// <summary>
        /// 更新Excel表格
        /// </summary>
        /// <param name="outputFile">需更新的excel表格路径</param>
        /// <param name="sheetname">sheet名</param>
        /// <param name="updateData">需更新的数据</param>
        /// <param name="coluids">需更新的列号</param>
        /// <param name="rowid">需更新的开始行号</param>
        public static void UpdateExcel(string outputFile, string sheetname, double[][] updateData, int[] coluids, int rowid)
        {
            FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
            readfile.Close();
            ISheet sheet1 = hssfworkbook.GetSheet(sheetname);
            for (int j = 0; j < coluids.Length; j++)
            {
                for (int i = 0; i < updateData[j].Length; i++)
                {
                    try
                    {
                        if (sheet1.GetRow(i + rowid) == null)
                        {
                            sheet1.CreateRow(i + rowid);
                        }
                        if (sheet1.GetRow(i + rowid).GetCell(coluids[j]) == null)
                        {
                            sheet1.GetRow(i + rowid).CreateCell(coluids[j]);
                        }
                        sheet1.GetRow(i + rowid).GetCell(coluids[j]).SetCellValue(updateData[j][i]);
                    }
                    catch (Exception ex)
                    {
                        //wl.WriteLogs(ex.ToString());
                    }
                }
            }
            try
            {
                FileStream writefile = new FileStream(outputFile, FileMode.Create);
                hssfworkbook.Write(writefile);
                writefile.Close();
            }
            catch (Exception ex)
            {
                //wl.WriteLogs(ex.ToString());
            }
        }

        #endregion

        public static int GetSheetNumber(string outputFile)
        {
            int number = 0;
            try
            {
                FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                number = hssfworkbook.NumberOfSheets;

            }
            catch (Exception exception)
            {
                //wl.WriteLogs(exception.ToString());
            }
            return number;
        }

        public static ArrayList GetSheetName(string outputFile)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                FileStream readfile = new FileStream(outputFile, FileMode.Open, FileAccess.Read);

                HSSFWorkbook hssfworkbook = new HSSFWorkbook(readfile);
                for (int i = 0; i < hssfworkbook.NumberOfSheets; i++)
                {
                    arrayList.Add(hssfworkbook.GetSheetName(i));
                }
            }
            catch (Exception exception)
            {
                //wl.WriteLogs(exception.ToString());
            }
            return arrayList;
        }

        public static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?d+[.]?d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            else
                return false;

        }
    }
}
