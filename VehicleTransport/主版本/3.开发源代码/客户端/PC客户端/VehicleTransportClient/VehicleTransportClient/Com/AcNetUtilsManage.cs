using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ACRptEngineX;
using System.Data;
using System.IO;
using System.Windows.Forms;
using AcReport;

namespace VehicleTransportClient.Com
{
    public class AcNetUtilsManage
    {

        string ReportPath = "";
      
        AcRptEngine mac;
        public AcNetUtilsManage()
        {
            mac = new AcRptEngine();
            string RegCode = "3338495E46463540202341584C5894C7C7C24E351F08AB1FC7A44BFCFC7C6DC867594D85461F8BC9BC5F33BF38B47C14250ED3B7A64F698B7FD6DEDA479A71329980F2DF3085B46CF2F40FC34CCD0B99979568434117C78106ED170549997191AC111A4E";
            int ErrCode = 0;
            string ErrMsg = "";
            mac.SetRegisterInfo(RegCode, "南京北路自动化", "c005", "南京市江宁开发区菲尼克斯路99号",
                "", "", "", ref ErrCode, ref ErrMsg);
        }
        bool IsAddFile = false;
        bool FileIsExit = false;
        bool IsHaveData;
        public bool Init(string reportDirectory,string reportFileName )
        {
            try
            {
                if (!Directory.Exists(reportDirectory))
                    Directory.CreateDirectory(reportDirectory);
                ReportPath = reportDirectory + "\\" + reportFileName;
                if (File.Exists(ReportPath))
                {
                    mac.SetReportFile(ReportPath);
                    IsAddFile = true;
                    FileIsExit = true;
                    return true;
                }
                else
                {
                    return  false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void dispose()
        {
            //mac.Close();
        }

        public void AddVariable(string vName, object obj)
        {
            mac.AddVariable(vName, obj);
        }

        public void AddVariable(DataGridView gridView)
        {
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                mac.AddVariable(column.Name, column.HeaderText);
            }
        }

        public void AddVariable(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mac.AddVariable(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
            }
        }

        public void FillDataTableToAcFromGridView(DataGridView gridView)
        {
            FillDataTableToAcFromGridView(gridView,"主表");
        }

        public void FillDataTableToAcFromGridView(DataGridView gridView ,string TableName)
        {
            if (mac == null) return;
            DataTable dt = GetDataTableFromDataGridView(gridView, TableName);
            FillDataTableToAC(dt, TableName); 
        }

        public void FillDataSetToAcFromGridView(DataGridView[] gridViews, string[] DataTablesName)
        {
            if (mac == null) return;
            DataSet ds = GetDataSetFromDataGridViews(gridViews, DataTablesName);
            FillDatasetToAC(ds);
        }

        public void CopyDataTableToAcFromGridView(DataGridView gridView, string DataTableName)
        {
            if (mac == null) return;
            DataTable dt = GetDataTableFromDataGridView(gridView, DataTableName);
            CopyDataTableToAC(dt);
        }
  
        public void CopyDataSetToAcFromGridView(DataGridView[] gridViews, string[] DataTablesName)
        {
            if (mac == null) return;
            DataSet ds = GetDataSetFromDataGridViews(gridViews, DataTablesName);
            CopyDatasetToAC(ds);
        }

        public void FillDataTableToAC(DataTable dt)
        {
            FillDataTableToAC(dt,"主表");
        }

        public void FillDataTableToAC(DataTable dt,string TableName)
        {
            if (mac == null) return;
            dt.TableName = TableName;
            AcNetUtils.DbAdapter.FillDataTableToAC(dt, mac);
            // AcNetUtils..DbAdapter.
            DataTableIsHaveData(dt);
        }

        public void FillDatasetToAC(DataSet ds, string DataSetName)
        {
            ds.DataSetName = DataSetName;
            FillDatasetToAC(ds);
        }

        public void FillDatasetToAC(DataSet ds)
        {
            if (mac == null) return;
            AcNetUtils.DbAdapter.FillDatasetToAC(ds, mac);
            DataSetIsHaveData(ds);
        }

        public void CopyDataTableToAC(DataTable dt)
        {
            if (mac == null) return;
            AcNetUtils.AcUtils.CopyTableToAcRptEngine(dt, mac, false);
            DataTableIsHaveData(dt);
        }

        //主从报表 从表必须用copy的方式，用AcNetUtils.DbAdapter.FillDatasetToAC(ds, mac)无效
        public void CopyDatasetToAC(DataSet ds)
        {
            if (mac == null) return;
            AcNetUtils.AcUtils.CopyDatasetToAcRptEngine(ds, mac, false);
            DataSetIsHaveData(ds);
        }

        public void AddDatasetRelation(string MasterName,string DetailName,string Relation)
        {
            mac.AddDatasetRelation(MasterName, DetailName, Relation);
        }

        public DataSet GetDataSetFromDataGridViews(DataGridView[] gridViews, string[] DataTablesName)
        {
            DataSet ds = new DataSet();
            for (int k = 0; k < gridViews.Count(); k++)
            {
                DataTable dt = GetDataTableFromDataGridView(gridViews[k], DataTablesName[k]);
                ds.Tables.Add(dt);
            }
            return ds;
        }

        public DataTable GetDataTableFromDataGridView(DataGridView gridView, string DataTableName)
        {
            DataTable dt = new DataTable();
            dt.TableName = DataTableName;
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                dt.Columns.Add(column.Name);
            }
            foreach (DataGridViewRow row in gridView.Rows)
            {
                string[] str = new string[row.Cells.Count];
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value == null)
                    {
                        str[i] = "";
                    }
                    else
                    {
                        str[i] = row.Cells[i].Value.ToString();
                    }
                }
                dt.Rows.Add(str);
            }
            return dt;
        }

        public void DataSetIsHaveData(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                if (DataTableIsHaveData(dt))
                    break;
            }
        }
        public bool DataTableIsHaveData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                IsHaveData = true;
                return true;
            }
            return false;
        }

        public string Print()
        {
           
            string str = "";
            try
            {
                if (!IsAddFile || !FileIsExit)
                {
                    str = "报表文件【" + ReportPath + "】不存在";
                }
                if (!IsHaveData)
                {

                    str = "无数据，无法打印";
                }
                if (str == "") mac.Preview();
            }
            catch { }
            return str;
        }

        public string Preview()
        {
            string str = "";
            try
            {
                if (!IsAddFile || !FileIsExit)
                {
                    str = "报表文件【" + ReportPath + "】不存在";
                }
                if (!IsHaveData)
                {
                    str = "无数据，无法打印";
                }
                if (str == "") mac.Preview();
            }
            catch { }
            return str;
        }

        public string ShowDesigner()
        {
            string str = "";
            //try
            //{
            //    if (!IsAddFile || !FileIsExit)
            //    {
            //        str = "报表文件【" + ReportPath + "】不存在";
            //    }
            //    else
            //    {
                    mac.ShowDesigner();
            //    }
            //}
            //catch { }
            return str;
        }


    }
}
