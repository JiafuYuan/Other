using System;
using System.Data;

namespace BW.MMS.Web.Common
{
    public class AcNetStream : Object, AcReport.IAcNetStream
    {
        System.IO.Stream mStream;

        public AcNetStream(System.IO.Stream connectStream)
        {
            mStream = connectStream;
        }

        public void ConnectTo(System.IO.Stream connectStream)
        {
            mStream = connectStream;
        }

        public int GetSize()
        {
            return (int)mStream.Length;

        }

        public int Read(ref string Buffer, int Count)
        {

            byte[] buf = new byte[Count];

            int size = mStream.Read(buf, 0, Count);
            int i;

            Buffer = "";
            for (i = 0; i <= size - 1; i++)
                Buffer = Buffer + (Char)buf[i];

            return size;

        }

        public int Seek(int Offset, AcReport.SeekOrg Origin)
        {
            return (int)mStream.Seek(Offset, (System.IO.SeekOrigin)Origin);
        }

        public void SetSize(int NewSize)
        {
            mStream.SetLength(NewSize);
        }

        public int Write(string Buffer, int Count)
        {
            byte[] buf = new byte[Count];
            int i;
            for (i = 0; i <= Count - 1; i++)
                buf[i] = (byte)Buffer[i];
            mStream.Write(buf, 0, Count);

            return Count;
        }
    }

    public class AcUtils : Object
    {

        public static int MaxStringFieldLength = 300;
        // 摘要:
        //指定字符类型字段的最大长度


        public static void BuildTableStruct(DataTable table, AcReport.ICustDataBuilder tbBuilder)
        {
            // 摘要:
            //在AcCustDataBuilder对象中创建一个表结构
            int i;
            if (tbBuilder.TableExist(table.TableName))
            {
                tbBuilder.CloseTable(table.TableName);
                tbBuilder.RemoveTable(table.TableName);
            }

            tbBuilder.NewTable(table.TableName);

            for (i = 0; i <= table.Columns.Count - 1; i++)
            {
                if (table.Columns[i].DataType == typeof(string))
                    tbBuilder.AddStringField(table.TableName, table.Columns[i].ColumnName, MaxStringFieldLength);
                else if (table.Columns[i].DataType == typeof(int) || table.Columns[i].DataType == typeof(bool))
                    tbBuilder.AddIntegerField(table.TableName, table.Columns[i].ColumnName);
                else if (table.Columns[i].DataType == typeof(float) || table.Columns[i].DataType == typeof(double))
                    tbBuilder.AddFloatField(table.TableName, table.Columns[i].ColumnName);
                else if (table.Columns[i].DataType == typeof(DateTime))
                    tbBuilder.AddDateTimeField(table.TableName, table.Columns[i].ColumnName);
                else if (table.Columns[i].DataType == typeof(byte[]))
                    tbBuilder.AddBlobField(table.TableName, table.Columns[i].ColumnName);
                else
                    tbBuilder.AddStringField(table.TableName, table.Columns[i].ColumnName, MaxStringFieldLength);
            }
        }

        //复制一个表到AcCustDataBuilder对象中
        public static void CopyTableToAcRptDataBuilder(System.Data.DataTable table, AcReport.ICustDataBuilder tbBuilder)
        {
            tbBuilder.OpenTable(table.TableName);
            tbBuilder.SetCurrentTable(table.TableName);
            int nTblIndex = tbBuilder.GetTableIndex(table.TableName);

            for (int i = 0; i <= table.Rows.Count - 1; i++)
            {
                tbBuilder.AppendEmptyRow("");  //执行tbBuilder.SetCurrentTable(table.TableName);后，参数为空表示默认的table
                for (int c = 0; c <= table.Columns.Count - 1; c++)
                {
                    tbBuilder.SetFieldValue(nTblIndex, c, table.Rows[i].ItemArray[c]);
                }
            }
        }

        //复制一个表到AcReportEngine中，isGlobal表示是否全局
        public static void CopyTableToAcRptEngine(System.Data.DataTable table, AcReport.IAcRptEngine ac, bool isGlobal)
        {
            AcReport.CustDataBuilder builder;
            if (isGlobal)
                builder = ac.GlobalCustDataBuilder;
            else
                builder = ac.CustDataBuilder;
            BuildTableStruct(table, builder);
            CopyTableToAcRptDataBuilder(table, builder);
        }

        //将一个Dataset中的所有表复制到AcReportEngine中，isGlobal表示是否全局
        public static void CopyDatasetToAcRptEngine(System.Data.DataSet ds, AcReport.IAcRptEngine ac, bool isGlobal)
        {
            AcReport.CustDataBuilder builder;
            if (isGlobal)
                builder = ac.GlobalCustDataBuilder;
            else
                builder = ac.CustDataBuilder;

            for (int i = 0; i <= ds.Tables.Count - 1; i++)
            {
                BuildTableStruct(ds.Tables[i], builder);
                CopyTableToAcRptDataBuilder(ds.Tables[i], builder);
            }
        }
    }
}