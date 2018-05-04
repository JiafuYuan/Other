using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSSQLScript.Properties;

namespace MSSQLScript
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        DataTable tables = new DataTable();
        DataTable scripts = new DataTable();
        DataTable trigger = new DataTable();
        DataTable types = new DataTable();
        string ConnectionString = string.Empty;
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            ConnectionString = this.txtConnectionString.Text.Trim();
            #region test Connection
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            #endregion

            // string tablesScript=Resources.tables;
            // string typesScript = Resources.types;

            string sql = "SELECT QUOTENAME(object_schema_name(t.object_id))+'.'+ QUOTENAME(object_name(t.object_id)) AS Table_Name FROM sys.tables t ORDER BY t.name";
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter ap = new SqlDataAdapter(sql, con);
                ap.Fill(dt);
                this.treeView1.Nodes[0].Text = con.Database;
            }

            TreeNode tablesNode = this.treeView1.Nodes.Find("tvTables", true)[0];
            foreach (DataRow row in dt.Rows)
            {
                string tableName = row["Table_Name"].ToString();
                TreeNode node = new TreeNode(tableName);
                node.Name = "tv" + tableName;
                node.Tag = "U";
                tablesNode.Nodes.Add(node);
            }


            sql = "SELECT QUOTENAME(object_schema_name(t.parent_id))+'.'+ QUOTENAME(object_name(t.parent_id)) AS Table_Name,"
                + " QUOTENAME(object_schema_name(t.object_id))+'.'+ QUOTENAME(object_name(t.object_id)) AS Trigger_Name"
                + "  FROM   sys.triggers t WHERE t.parent_id>0";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter ap = new SqlDataAdapter(sql, con);
                ap.Fill(trigger);

            }
            sql = Resources.tables;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter ap = new SqlDataAdapter(sql, con);
                ap.Fill(tables);

            }
            InitData();
        }

        private void InitData()
        {
            string sql = "SELECT  QUOTENAME(object_schema_name(m.object_id))+'.'+ QUOTENAME(object_name(m.object_id)) AS [name],o.type,m.definition "
                       + "FROM   sys.sql_modules m INNER JOIN sys.objects o  ON m.object_id = o.object_id ";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter ap = new SqlDataAdapter(sql, con);
                ap.Fill(scripts);
            }
            TreeNode rootNode = this.treeView1.Nodes[0];
            #region Views
            DataRow[] rowViews = scripts.Select("type='V'");
            if (rowViews.Length > 0)
            {
                TreeNode node = new TreeNode("Views");
                node.Name = "tvViews";
                rootNode.Nodes.Add(node);

                foreach (DataRow row in rowViews)
                {
                    string name = row["name"].ToString();
                    TreeNode newnode = new TreeNode(name);
                    newnode.Name = "tv" + name;
                    newnode.Tag = row["type"].ToString();
                    node.Nodes.Add(newnode);
                }
            }
            #endregion
            #region Triggers
            DataRow[] rowTriggers = scripts.Select("type='TR'");
            if (rowTriggers.Length > 0)
            {
                TreeNode node = new TreeNode("Triggers");
                node.Name = "tvTriggers";
                rootNode.Nodes.Add(node);

                foreach (DataRow row in rowTriggers)
                {
                    string name = row["name"].ToString();
                    TreeNode newnode = new TreeNode(name);
                    newnode.Name = "tv" + name;
                    newnode.Tag = row["type"].ToString();
                    node.Nodes.Add(newnode);
                }
            }
            #endregion
            #region Procedures
            DataRow[] rowProcs = scripts.Select("type='P'");
            if (rowProcs.Length > 0)
            {
                TreeNode node = new TreeNode("Procedures");
                node.Name = "tvProcedures";
                rootNode.Nodes.Add(node);

                foreach (DataRow row in rowProcs)
                {
                    string name = row["name"].ToString();
                    TreeNode newnode = new TreeNode(name);
                    newnode.Name = "tv" + name;
                    newnode.Tag = row["type"].ToString();
                    node.Nodes.Add(newnode);
                }
            }
            #endregion

            #region Functions
            DataRow[] rowFunctions = scripts.Select("type='Like %F%'");
            if (rowFunctions.Length > 0)
            {
                TreeNode node = new TreeNode("Functions");
                node.Name = "tvFunctions";
                rootNode.Nodes.Add(node);

                foreach (DataRow row in rowTriggers)
                {
                    string name = row["name"].ToString();
                    TreeNode newnode = new TreeNode(name);
                    newnode.Name = "tv" + name;
                    newnode.Tag = row["type"].ToString();
                    node.Nodes.Add(newnode);
                }
            }
            #endregion

            #region Types
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter ap = new SqlDataAdapter(Resources.types, con);
                ap.Fill(types);
            }
            if (types.Rows.Count > 0)
            {
                TreeNode node = new TreeNode("Types");
                node.Name = "tvTypes";
                node.Tag = "type";
                rootNode.Nodes.Add(node);
            }
            #endregion
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            string name = node.Text;
            if (node.Tag == null) return;
            string type = node.Tag.ToString();
            StringBuilder txt = new StringBuilder();

            switch (type)
            {
                case "U":
                    DataRow row = tables.Select("TableName='" + name + "'")[0];
                    txt.Append(row["definition"].ToString());
                    txt.AppendLine();
                    DataRow[] rows = trigger.Select("Table_Name='" + name + "'");
                    foreach (DataRow trow in rows)
                    {
                        string tname = trow["Trigger_Name"].ToString();
                        row = scripts.Select("name='" + tname + "'")[0];
                        txt.Append(row["definition"].ToString());
                        txt.AppendLine();
                    }
                    break;
                case "type":
                    
                    foreach (DataRow item in types.Rows)
                    {
                        txt.Append(item["definition"].ToString());
                        txt.AppendLine();
                    }
                    break;
                default:
                    DataRow sRow = scripts.Select("name='" + name + "'")[0];
                    txt.Append(sRow["definition"].ToString());
                    break;
            }

            this.richTextBox1.Text = txt.ToString();
        }

       
    }
}
