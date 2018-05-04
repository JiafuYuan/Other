using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;

namespace Bestway.Windows.Tools.ADODB
{
    public class ExecuteErrorEventArgs : EventArgs
    {
        public string Sql { get; set; }
        public Exception Exception { get; set; }
    }
    public delegate void ExecuteErrorEventHandler(object sender, ExecuteErrorEventArgs e);



    public class OleDbHelper
    {
        private OleDbTransaction transaction=null;
        private OleDbCommand transCMD=new OleDbCommand();

        public OleDbHelper()
        {
            Init(null);
        }

        public OleDbHelper(StateChangeEventHandler stateChanged)
        {
            Init(stateChanged);
        }

        public OleDbHelper(DBInfo dbInfo)
            : this(dbInfo, null)
        {
        }

        public OleDbHelper(DBInfo dbInfo, StateChangeEventHandler stateChanged)
        {
            Init(stateChanged);

            DBInfo = dbInfo;
        }

        private void Init(StateChangeEventHandler stateChanged)
        {
            this.StateChanged = stateChanged;
            conn.StateChange += new StateChangeEventHandler(conn_StateChange);
        }
        /// <summary>开启事务
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            if ((this.conn.State == ConnectionState.Open) || this.Open())
            {
                this.transaction = this.conn.BeginTransaction();
                this.transCMD = new OleDbCommand();
                this.transCMD.Connection = this.conn;
                this.transCMD.Transaction = this.transaction;
            }

        }
        /// <summary>提交数据
        /// 提交数据
        /// </summary>
        public void Commit()
        {
            this.transaction.Commit();
            this.transaction = null;
        }
        /// <summary>回滚数据
        /// 回滚数据
        /// </summary>
        public void Rollback()
        {
            this.transaction.Rollback();
            this.transaction = null;
        }

        private object objSynLocker = new object();

        private DBInfo _dbInfo = new DBInfo();

        private OleDbConnection conn = new OleDbConnection();

        private int executeTimeOut = -1;
        public int ExecuteTimeOut
        {
            get { return executeTimeOut; }
            set { executeTimeOut = value; }
        }

        /// <summary>状态发生变化事件 </summary>
        public event StateChangeEventHandler StateChanged;

        /// <summary>数据处理失败</summary>
        public event ExecuteErrorEventHandler ExecuteError;

        private void conn_StateChange(object sender, StateChangeEventArgs e)
        {
            if (StateChanged != null) StateChanged(sender, e);
        }

        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>返回true为连接成功</returns>
        private bool Open()
        {
            System.Threading.Monitor.Enter(objSynLocker);
            try
            {
                if (conn.State != System.Data.ConnectionState.Closed) conn.Close();
                conn.ConnectionString = _dbInfo.GetConnectionString();

                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                if (this.ExecuteError != null)
                {
                    OnExecuteError(conn.ConnectionString, e);
                }
                return false;
            }
            finally
            {
                System.Threading.Monitor.Exit(objSynLocker);
            }
        }

        /// <summary>关闭数据源连接</summary>
        private void Close()
        {
            System.Threading.Monitor.Enter(objSynLocker);
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            System.Threading.Monitor.Exit(objSynLocker);
        }

        private void OnExecuteError(string strSql, string strError)
        {
            if (ExecuteError != null)
            {
                ExecuteErrorEventArgs e = new ExecuteErrorEventArgs();
                e.Sql = strSql;
                e.Exception = new Exception(strError);
                ExecuteError(this, e);
            }
        }
        private void OnExecuteError(string strSql, Exception exception)
        {
            if (ExecuteError != null)
            {
                ExecuteErrorEventArgs e = new ExecuteErrorEventArgs();
                e.Sql = strSql;
                e.Exception = exception;
                ExecuteError(this, e);
            }
        }

        public enum ELoggingResult
        {
            Connected,
            ConnectedByModify,
            Closed,
            Error
        }

        /// <summary>连接服务器</summary>
        /// <param name="dbInfo">服务器信息</param>
        /// <param name="dbDlg">连接失败时，是否显示连接DBLoggingInDialog对话框？为null时不显示</param>
        /// <returns>返回ELoggingResult类型的值</returns>
        public ELoggingResult Connection(DBInfo dbInfo, DBLoggingInDialog dbDlg)
        {
            DBInfo tempDBInfo = null;
            try
            {
                if (dbInfo != null)
                {
                    _dbInfo = dbInfo;
                    tempDBInfo = new DBInfo();
                    tempDBInfo = _dbInfo;
                }

                if (Open())
                {
                    return ELoggingResult.Connected;
                }

                if (dbDlg != null)
                {
                    if (dbDlg.Show(ref dbInfo))
                    {
                        if (ELoggingResult.Connected == Connection(dbInfo, dbDlg))
                        {
                            return ELoggingResult.ConnectedByModify;
                        }
                    }
                }
                if (tempDBInfo != null) _dbInfo = tempDBInfo;
                return ELoggingResult.Closed;
            }
            catch (Exception ex)
            {
                OnExecuteError(string.Format("HostID={0},DatabaseName={1},UserName={2},Password={3}", dbInfo.HostID, dbInfo.DatabaseName, dbInfo.UserName, dbInfo.Password), ex);
            }
            finally
            {

            }
            if (tempDBInfo != null) _dbInfo = tempDBInfo;
            return ELoggingResult.Error;
        }
        /// <summary>连接服务器。连接失败时，显示连接DBLoggingInDialog对话框</summary>
        /// <param name="dbInfo">服务器信息</param>
        /// <returns>返回ELoggingResult类型的值</returns>
        public ELoggingResult Connection(DBInfo dbInfo)
        {
            return Connection(dbInfo, new DBLoggingInDialog());
        }
        /// <summary>连接服务器</summary>
        /// <param name="dbDlg">连接失败时，是否显示连接DBLoggingInDialog对话框？为null时不显示</param>
        /// <returns>返回ELoggingResult类型的值</returns>
        public ELoggingResult Connection(DBLoggingInDialog dbDlg)
        {
            return Connection(null, dbDlg);
        }
        /// <summary>连接服务器。连接失败时，显示连接DBLoggingInDialog对话框</summary>
        /// <returns>返回ELoggingResult类型的值</returns>
        public ELoggingResult Connection()
        {
            return Connection(null, new DBLoggingInDialog());
        }

        /// <summary>释放对象</summary>
        public void Dispose()
        {
            Close();
        }

        /// <summary>数据库信息</summary>
        public DBInfo DBInfo
        {
            set
            {
                _dbInfo = value;
                Open();
            }
            get { return _dbInfo; }
        }

        /// <summary>数据库连接状态</summary>
        public ConnectionState ConnState
        {
            get { return conn.State; }
        }

        public DataSet GetDataSet(string strSql, CommandType commandType, OleDbParameter[] parameters, int timeout)
        {
            DataSet set2;
            Monitor.Enter(this.objSynLocker);
            try
            {
                if ((this.conn.State == ConnectionState.Open) || this.Open())
                {
                    OleDbCommand transCMD;
                    if (this.transaction != null)
                    {
                        transCMD = this.transCMD;
                        transCMD.CommandText = strSql;
                    }
                    else
                    {
                        transCMD = new OleDbCommand(strSql, this.conn);
                    }
                    if (timeout >= 0)
                    {
                        transCMD.CommandTimeout = timeout;
                    }
                    transCMD.CommandType = commandType;
                    transCMD.Parameters.Clear();
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            transCMD.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                            transCMD.Parameters[transCMD.Parameters.Count - 1].DbType = parameter.DbType;
                            transCMD.Parameters[transCMD.Parameters.Count - 1].Direction = parameter.Direction;
                            transCMD.Parameters[transCMD.Parameters.Count - 1].Size = parameter.Size;
                        }
                    }
                    OleDbDataAdapter adapter = new OleDbDataAdapter(transCMD);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
                set2 = null;
            }
            catch (Exception exception)
            {
                if (this.ExecuteError == null)
                {
                    throw exception;
                }
                this.OnExecuteError(strSql, exception);
                set2 = null;
            }
            finally
            {
                Monitor.Exit(this.objSynLocker);
            }
            return set2;

        }

        public DataSet GetDataSet(string strSql, CommandType commandType, OleDbParameter[] parameters)
        {
            return GetDataSet(strSql, commandType, parameters, executeTimeOut);
        }

        public DataSet GetDataSet(string strSql, CommandType commandType, int timeout)
        {
            return GetDataSet(strSql, commandType, null, timeout);
        }

        /// <summary>根据查询语句获取DataSet实例</summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <param name="commandType">命令类型</param>
        /// <returns>返回DataSet实例</returns>
        public DataSet GetDataSet(string strSql, CommandType commandType)
        {
            return this.GetDataSet(strSql, commandType, (OleDbParameter[])null);

        }

        public DataSet GetDataSet(string strSql, int timeout)
        {
            return GetDataSet(strSql, CommandType.Text, timeout);
        }

        /// <summary>根据查询语句获取DataSet实例</summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns>返回DataSet实例</returns>
        public DataSet GetDataSet(string strSql)
        {
            return GetDataSet(strSql, CommandType.Text);
        }

        /// <summary>根据SQL语句获取DataTable实例</summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <returns>返回DataTable实例</returns>
        public DataTable GetDataTable(string strSql)
        {
            return GetDataTable(strSql, CommandType.Text);
        }

        /// <summary>根据SQL语句获取DataTable实例</summary>
        /// <param name="strSql">SQL查询语句</param>
        /// <param name="commandType">命令类型</param>
        /// <returns>返回DataTable实例</returns>
        public DataTable GetDataTable(string strSql, CommandType commandType)
        {
            return GetDataTable(strSql, commandType, null);
        }

        public DataTable GetDataTable(string strSql, int timeout)
        {
            return GetDataTable(strSql, CommandType.Text, timeout);
        }

        public DataTable GetDataTable(string strSql, CommandType commandType, int timeout)
        {
            return GetDataTable(strSql, commandType, null, timeout);
        }

        public DataTable GetDataTable(string strSql, CommandType commandType, OleDbParameter[] parameters)
        {
            return GetDataTable(strSql, commandType, parameters, executeTimeOut);
        }

        public DataTable GetDataTable(string strSql, CommandType commandType, OleDbParameter[] parameters, int timeout)
        {
            System.Threading.Monitor.Enter(objSynLocker);
            try
            {
                if (conn.State == ConnectionState.Open || Open())
                {
                    OleDbCommand cmd = new OleDbCommand(strSql, conn);
                    if (timeout >= 0) cmd.CommandTimeout = timeout;
                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                            cmd.Parameters[cmd.Parameters.Count - 1].DbType = parameter.DbType;
                            cmd.Parameters[cmd.Parameters.Count - 1].Direction = parameter.Direction;
                            cmd.Parameters[cmd.Parameters.Count - 1].Size = parameter.Size;
                        }
                    }
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

                return null;
            }
            catch (Exception e)
            {
                if (this.ExecuteError != null)
                {
                    OnExecuteError(strSql, e);
                    return null;
                }
                throw e;
            }
            finally
            {
                System.Threading.Monitor.Exit(objSynLocker);
            }
        }

        /// <summary>执行SQL语句</summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功后影响的记录行数</returns>
        public int ExecuteSql(string strSql)
        {
            return ExecuteSql(strSql, null);
        }

        public int ExecuteSql(string strSql, OleDbParameter[] parameters)
        {
            return ExecuteSql(strSql, parameters, executeTimeOut);
        }

        public int ExecuteSql(string strSql, int timeout)
        {
            return ExecuteSql(strSql, null, timeout);
        }

        public int ExecuteSql(string strSql, OleDbParameter[] parameters, int timeout)
        {
            System.Threading.Monitor.Enter(objSynLocker);
            try
            {
                if (conn.State == ConnectionState.Open || Open())
                {
                    OleDbCommand cmd = new OleDbCommand(strSql, conn);
                    if (timeout >= 0) cmd.CommandTimeout = timeout;
                    cmd.Parameters.Clear();
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                            cmd.Parameters[cmd.Parameters.Count - 1].DbType = parameter.DbType;
                            cmd.Parameters[cmd.Parameters.Count - 1].Direction = parameter.Direction;
                            cmd.Parameters[cmd.Parameters.Count - 1].Size = parameter.Size;
                        }
                    }
                    int n = cmd.ExecuteNonQuery();
                    if (n < 0) n = 0;
                    return n;
                }

                return -1;
            }
            catch (Exception e)
            {
                if (this.ExecuteError != null)
                {
                    OnExecuteError(strSql, e);
                    return -1;
                }
                throw e;
            }
            finally
            {
                System.Threading.Monitor.Exit(objSynLocker);
            }
        }
        public int ExecuteSql(string strSql, OleDbParameter[] parameters, CommandType type)
        {
            System.Threading.Monitor.Enter(objSynLocker);
            try
            {
                if (conn.State == ConnectionState.Open || Open())
                {
                    OleDbCommand cmd = new OleDbCommand(strSql, conn);
                    cmd.CommandType = type;
                    cmd.Parameters.Clear();
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                            cmd.Parameters[cmd.Parameters.Count - 1].DbType = parameter.DbType;
                            cmd.Parameters[cmd.Parameters.Count - 1].Direction = parameter.Direction;
                            cmd.Parameters[cmd.Parameters.Count - 1].Size = parameter.Size;
                        }
                    }
                    int n = cmd.ExecuteNonQuery();
                    if (type == CommandType.StoredProcedure)
                    {
                        cmd.Parameters.CopyTo(parameters, 0);
                    }
                    if (n < 0) n = 0;
                    return n;
                }

                return -1;
            }
            catch (Exception e)
            {
                if (this.ExecuteError != null)
                {
                    OnExecuteError(strSql, e);
                    return -1;
                }
                throw e;
            }
            finally
            {
                System.Threading.Monitor.Exit(objSynLocker);
            }
        }

        /// <summary>执行SQL语句</summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>执行成功后影响的记录行数</returns>
        public object ExecuteScale(string strSql)
        {
            return this.ExecuteScale(strSql, null);
        }

        public object ExecuteScale(string strSql, OleDbParameter[] parameters)
        {
            object obj3;
            Monitor.Enter(this.objSynLocker);
            try
            {
                if ((this.conn.State == ConnectionState.Open) || this.Open())
                {
                    OleDbCommand transCMD;
                    if (this.transaction != null)
                    {
                        transCMD = this.transCMD;
                        transCMD.CommandText = strSql;
                    }
                    else
                    {
                        transCMD = new OleDbCommand(strSql, this.conn);
                    }
                    transCMD.CommandType = CommandType.Text;
                    transCMD.Parameters.Clear();
                    if (parameters != null)
                    {
                        foreach (OleDbParameter parameter in parameters)
                        {
                            transCMD.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                            transCMD.Parameters[transCMD.Parameters.Count - 1].DbType = parameter.DbType;
                            transCMD.Parameters[transCMD.Parameters.Count - 1].Direction = parameter.Direction;
                            transCMD.Parameters[transCMD.Parameters.Count - 1].Size = parameter.Size;
                        }
                    }
                    return transCMD.ExecuteScalar();
                }
                obj3 = -1;
            }
            catch (Exception exception)
            {
                if (this.ExecuteError == null)
                {
                    throw exception;
                }
                this.OnExecuteError(strSql, exception);
                obj3 = -1;
            }
            finally
            {
                Monitor.Exit(this.objSynLocker);
            }
            return obj3;
        }
    }

    /// <summary>
    /// OLEDB类型
    /// </summary>
    public enum OleDbEnum
    {
        SQLSERVER = 0,// "SQLOLEDB",
        ACCESS = 1,    // "Microsoft.Jet.OLEDB.2.0"//2.0-4.0
        SQL2005 = 2//SQLNCLI
    }

    public class OleDbUtility
    {
        public static string ToString(OleDbEnum providername)
        {
            string str = "";
            switch (providername)
            {
                case OleDbEnum.SQLSERVER:
                    str = "SQLOLEDB";
                    break;
                case OleDbEnum.ACCESS:
                    str = "Microsoft.Jet.OLEDB.4.0";
                    break;
                case OleDbEnum.SQL2005:
                    str = "SQLNCLI";
                    break;
                default:
                    str = "SQLOLEDB";
                    break;
            }
            return str;
        }
    }

    /// <summary>数据库信息</summary>
    public class DBInfo
    {
        public DBInfo()
        {
            Init(OleDbEnum.SQLSERVER, ".", "", "sa", "");
        }
        public DBInfo(OleDbEnum providerName)
        {
            Init(providerName, ".", "", "sa", "");
        }
        public DBInfo(string hostID, string databaseName, string userName, string passWord)
        {
            Init(OleDbEnum.SQLSERVER, hostID, databaseName, userName, passWord);
        }
        public DBInfo(OleDbEnum providerName, string hostID, string databaseName, string userName, string passWord)
        {
            Init(providerName, hostID, databaseName, userName, passWord);
        }
        private void Init(OleDbEnum providerName, string hostID, string databaseName, string userName, string passWord)
        {
            connectTimeout = 10;
            ProviderName = providerName;
            HostID = hostID;
            DatabaseName = databaseName;
            UserName = userName;
            Password = passWord;
        }

        ///<summary>数据提供者</summary>
        private OleDbEnum _providerName = OleDbEnum.SQLSERVER;
        public OleDbEnum ProviderName
        {
            get { return _providerName; }
            set { _providerName = value; }
        }

        ///<summary>数据源：SQL服务器或ACCESS数据库文件位置</summary>
        private string hostID;
        public string HostID
        {
            get { return hostID; }
            set { hostID = value; }
        }

        ///<summary>数据库名称，ACCESS数据库不需要设置</summary>
        private string databaseName;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        ///<summary>登录用户，ACCESS数据库不需要设置</summary>
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        ///<summary>用户密码</summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        ///<summary>连接超时时间</summary>
        private int connectTimeout = 10;
        public int ConnectTimeout
        {
            get { return connectTimeout; }
            set { connectTimeout = value; }
        }

        /// <summary>获取连接字符串 </summary>
        public string GetConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"Provider={0};Data Source={1};", OleDbUtility.ToString(ProviderName), HostID);
            if (ProviderName == OleDbEnum.SQLSERVER || ProviderName == OleDbEnum.SQL2005)
            {
                sb.AppendFormat("Initial Catalog={0};", DatabaseName);
                sb.AppendFormat("User ID={0};", UserName);

                //   Provider = SQLNCLI; 
            }
            else
            {
                sb.Append("Persist Security Info=False;Jet OLEDB:Database ");
            }


            sb.AppendFormat("Password={0}", Password);
            sb.AppendFormat(";Connect Timeout={0}", connectTimeout);
            return sb.ToString();
        }
            /// <summary>获取连接字符串 </summary>
        public string GetSqlConnectionString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"server={0};uid={1};pwd={2};database={3}",  HostID,UserName,Password,DatabaseName);
            return sb.ToString();
        }

    }
}
