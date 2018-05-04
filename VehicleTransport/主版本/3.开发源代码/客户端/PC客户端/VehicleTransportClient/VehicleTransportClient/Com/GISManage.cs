using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TGMAPXLib;
using System.Data;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
using System.IO;
using VehicleTransportClient.Com;
namespace VehicleTransportClient
{
    public class GroupEventArgs : EventArgs
    {
        //public DB.Model.v_UnSafe UnSafe { get; set; }
        public string code { get; set; }
    }
    /// <summary></summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void UnSafeClickedEventHandler(object sender, GroupEventArgs e);
    public class GISManage
    {
        Form form = null;
        private AxTGMAPXLib.AxTGMAPX _tgMap = null;
        private int _iXCount = 0;
        private int _iYcount = 0;
        

        //轨迹变量
        //private int iXCount = 0;
        //private int iYcount = 0;
        private string path = Application.StartupPath + "\\GisMap";
        TGOPoints points = new TGOPoints();
        TGOFeaturePolyline feaLine = new TGOFeaturePolyline();
        //////////////////////定义最短路径变量///////////////////////
        public string toolShort;
        TGOValuesString KeepField = new TGOValuesString();
        TGOValuesString CalcField = new TGOValuesString();

        int layer;
        //int nodecount;
        int currentlocation = 0;
        TGOQueryFilterEx QueryFilterEx = new TGOQueryFilterEx();
        TGORecordSet SDPRecordSet = new TGORecordSet();
        TGOFeature pFeature = new TGOFeature();
        TGOFeatureSymbol FeatureSymbol = new TGOFeatureSymbol();
        //int i;
        //TGOPoints[] PointXY = null;
        //int pointcount;
        double dbFindLength;
        double dbAllLength;
        double dbStep = 200; //'移动的距离
        double iStep;    // '移动的次数
        TGOPoint FeatureStation = new TGOPoint();//'移动实体时，记录前一坐标
        int MoveLeftCount; //'向左移动的分别次数
        int MoveRigthCount;//'向右移动的分别次数
        TGOPoints Points = new TGOPoints();//    '记录单击地图的坐标
        //long[] colFeatureIDs = new long[3] { 12, 20, 11 };
        long[] colFeatureIDs;
        int TrackJzNum = 0;

        jzIDandZB[] mapTrackJzIDZB = null;
        string PersonName;
        //'为了添加走过的蓝线
        TGOQueryFilterEx QueryLine = new TGOQueryFilterEx();
        TGORecordSet SDPRecLine = new TGORecordSet();
        TGOFeaturePolyline AddLine = new TGOFeaturePolyline();
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        BLL.m_Address blladdress = new BLL.m_Address();
        BLL.m_User blluser = new BLL.m_User();
        BLL.m_Area bllarea = new BLL.m_Area();
        BLL.m_WifiBaseStation bllwifi = new BLL.m_WifiBaseStation();
        BLL.v_Address bllvaddress = new BLL.v_Address();
        public event EventHandler Moved;
        public class StationEventArgs : EventArgs
        {
            public EnumLayerName LayerName { get; set; }
            public int ID { get; set; }
        }
        public delegate void StationClickedEventHandler(object sender, StationEventArgs e);
        public event StationClickedEventHandler OnStationClick;


        public GISManage()
        {
           
            //_iYcount = 20;
            // _iXCount = 20;
        }
        public void InitMap(Control c)
        {
            _tgMap = new AxTGMAPXLib.AxTGMAPX();
            ((System.ComponentModel.ISupportInitialize)(_tgMap)).BeginInit();
            c.Controls.Add(_tgMap);
            ((System.ComponentModel.ISupportInitialize)(_tgMap)).EndInit();
            _tgMap.Dock = DockStyle.Fill;

            //int a = _tgMap.MapLoad(Application.StartupPath + "\\jc\\map.tgf");
            int a = _tgMap.MapLoad(Pub.APP_FILE_FULLNAME_GISMAP);


            _tgMap.LayerMoveTo(GetLayerIndex(EnumLayerName.车辆), 0);
            _tgMap.LayerSet(0, TGMAPXLib.emLayerFlag.ETGLayerIsDynamic, true);//设为动态层

            _tgMap.DrawMapFull();
            _tgMap.AfterClick += new AxTGMAPXLib._DTGMAPXEvents_AfterClickEventHandler(tgMap_AfterClick);
           
            
        }

        bool queryResult = false;
        int featureid = 0;
        double mapx = 0;
        double mapy = 0;
        void _tgMap_AfterMouseDown(object sender, AxTGMAPXLib._DTGMAPXEvents_AfterMouseDownEvent e)
        {
            if (e.button != 1) return;
            TGMAPXLib.TGOQueryResult queryresult = new TGMAPXLib.TGOQueryResultClass();
            _tgMap.FeatureQuery(TGMAPXLib.emFeatureQueryType.ETGFeatureQueryDotInclude, GetLayerIndex(EnumLayerName.定位基站), e.x.ToString() + "," + e.y.ToString(), ref queryresult);
            string strResult = "";
            if (queryresult.ResultCount > 0) //有值
            {
                queryResult = true;
                string id=queryresult.get_Results(0);
                TGMAPXLib.TGOValuesLong IDs = new TGMAPXLib.TGOValuesLongClass();
                _tgMap.FeatureIDGetByString(GetLayerIndex(EnumLayerName.定位基站), 0, id, IDs);
                featureid=IDs.Values[0];
                object Valuex = null;
                object Valuey = null;
                _tgMap.FeatureAttribGet(GetLayerIndex(EnumLayerName.定位基站), featureid, emFeatureFlag.ETGFeatureCenterX, ref Valuex);
                _tgMap.FeatureAttribGet(GetLayerIndex(EnumLayerName.定位基站), featureid, emFeatureFlag.ETGFeatureCenterY, ref Valuey);
                mapx = Convert.ToDouble(Valuex);
                mapy = Convert.ToDouble(Valuey);

            }

            else
            {
                strResult = "没有符合条件的实体";
            }

           // MessageBox.Show(strResult);


        }

        void _tgMap_AfterMouseUp(object sender, AxTGMAPXLib._DTGMAPXEvents_AfterMouseUpEvent e)
        {
            if (e.button != 1)
            {
                _tgMap.AfterMouseDown -= new AxTGMAPXLib._DTGMAPXEvents_AfterMouseDownEventHandler(_tgMap_AfterMouseDown);
                _tgMap.AfterMouseUp -= new AxTGMAPXLib._DTGMAPXEvents_AfterMouseUpEventHandler(_tgMap_AfterMouseUp);
                return;
            }
         
            object leftpt = null;
            object rightpt = null;
            object uppt = null;
            object downpt = null;
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundLeft, ref leftpt);
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundRight, ref rightpt);
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundTop, ref uppt);
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundBottom, ref downpt);
            if (e.mapx > double.Parse(leftpt.ToString()) && e.mapx < double.Parse(rightpt.ToString()) && e.mapy > double.Parse(downpt.ToString()) && e.mapy < double.Parse(uppt.ToString()))
            {
               
                    //MessageBox.Show("ok");
            }
            else
            {
                if (queryResult)
                {
                    MessageBox.Show("错误");
                    _tgMap.FeatureOffset(GetLayerIndex(EnumLayerName.定位基站),featureid, mapx-e.mapx, mapy-e.mapy);
                    _tgMap.DrawMap();
                }
                queryResult = false;
            }
         
            
        }
 
     
     
        /// <summary>数据库加载地图</summary>
        /// <param name="GisFilesDs"></param>
        /// <returns></returns>
       object obj = new object();
       public bool DBExportToMapFile(DataSet GisFilesDs, bool IsFrist)
        {

            try
            {
                lock (obj)
                {
                    if (GisFilesDs == null || GisFilesDs.Tables.Count == 0 || GisFilesDs.Tables[0].Rows.Count == 0)
                    {
                        WriteLog.AppendErrorLog("DBExportToMapFile,查询数据库中的地图信息失败或者无地图信息");
                        return false;
                    }

                    if (IsFrist)  //软件打开时加载地图，先删除后写，其他重新加载地图都是覆盖不删除
                    {
                        try
                        {
                            if (Directory.Exists(Pub.APP_FILE_PATH_GISMAP))
                            {
                                Directory.Delete(Pub.APP_FILE_PATH_GISMAP, true);
                            }
                            Directory.CreateDirectory(Pub.APP_FILE_PATH_GISMAP);

                        }
                        catch (Exception ex)
                        {
                            WriteLog.AppendErrorLog("DBExportToMapFile删除GIS文件报错" + ex.StackTrace.ToString());
                            return false;
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(Pub.APP_FILE_PATH_GISMAP))
                        {
                            Directory.CreateDirectory(Pub.APP_FILE_PATH_GISMAP);
                        }
                    }
                    try
                    {
                        for (int i = 0; i < GisFilesDs.Tables[0].Rows.Count; i++)
                        {
                            //写文件
                            byte[] by = (byte[])(GisFilesDs.Tables[0].Rows[i]["file_data"]);
                            int ArraySize = by.GetUpperBound(0) + 1;
                            FileStream stream = new FileStream(Pub.APP_FILE_PATH_GISMAP + "\\" + GisFilesDs.Tables[0].Rows[i]["file_name"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
                            stream.Write(by, 0, ArraySize);
                            stream.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return false;
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                WriteLog.AppendErrorLog("DBExportToMapFile外层报错" + e.StackTrace.ToString());
                return false;
            }
        }

        public  bool ReloadMap()
        {
            //先保存到数据库
            //MapFileSaveToDB();

            DB_VehicleTransportManage.BLL.m_GisMapFiles gismap = new DB_VehicleTransportManage.BLL.m_GisMapFiles();
            DataSet ds = gismap.GetList("");
            //导出到本地
            if (DBExportToMapFile(ds,false))
            {
                Com.WriteLog.AppendErrorLog("重新从数据库加载地图文件到本地");
            }
            else
            {
                return false;
            }
            //重新加载
            if (Pub.GisManage.LoadMap(Pub.APP_FILE_FULLNAME_GISMAP))
            {
                Com.WriteLog.AppendErrorLog("重新加载本地地图");
                return true;
            }
            return false;
        }
        /// <summary>
        /// 显示订单的车辆位置
        /// </summary>
        /// <param name="listLoacalid"></param>
        /// <returns></returns>
        public void ShowPlanCar(Dictionary<int, string> listCar)
        {
            try
            {
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;
                QueryFilterEX.sSQLString = "";

                int layerID = GetLayerIndex(EnumLayerName.定位基站);
                //wifi基站层可不见
                int wifilayerid = GetLayerIndex(EnumLayerName.wifi基站);
                _tgMap.LayerSet(wifilayerid, emLayerFlag.ETGLayerVisibleStatus, false);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);
                while (!SDPRecordSet.EOF)
                {

                    string localid = SDPRecordSet.get_field("LocalizerStationID").value.ToString();
                    pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                    if (listCar.ContainsKey(int.Parse(localid)))
                    {
                        pFeatureSymbol.SymStyle.index = EnumStyleIndex.CarNormal.GetHashCode();
                        pFeatureSymbol.SymStyle.Width = 5;
                        pFeatureSymbol.SymStyle.Height = 5;
                        SDPRecordSet.get_field("vc_remark").value = listCar[int.Parse(localid)].ToString();
                    }
                    else
                    {
                        pFeatureSymbol.SymStyle.Status = 2;//2为实体不可见，0为实体可见

                    }
                    
                    SDPRecordSet.feature = pFeatureSymbol;
                    SDPRecordSet.MoveNext();
                }
                SDPRecordSet.Close();
                _tgMap.DrawMap();
            }
            catch
            {
 
            }
        }

        /// <summary>导入地图</summary>
        public  void ImportMap()
        {
            try
            {
                if (Common.MessageBoxEx.MessageBoxEx.Show("导入地图将覆盖本地地图文件，确定要导入？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //选择地图
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "TopMap File(" + Pub.APP_FILE_NAME_GISMAP + ")|" + Pub.APP_FILE_NAME_GISMAP;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (openFileDialog1.FileName != "")
                        {
                            //首先删除原来的地图文件
                            Directory.Delete(Pub.APP_FILE_PATH_GISMAP, true);
                            Directory.CreateDirectory(Pub.APP_FILE_PATH_GISMAP);

                            //将新地图文件复制到本地  文件的全路径.Split("/"+文件的名称,"");
                            CopyMapFile(Path.GetDirectoryName(openFileDialog1.FileName), Pub.APP_FILE_PATH_GISMAP + "\\");

                            if (LoadMap(Pub.APP_FILE_FULLNAME_GISMAP))
                            {
                                UpdateGisAndDB();
                                
                                //MapFileSaveToDB();
                                MessageBox.Show("地图导入成功！", "提示", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("地图导入不成功！", "提示", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public  bool MapFileSaveToDB()
        {
            object obj = new object();
            try
            {

                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                try
                {
                    lock (obj)
                {
                        //Global.Params.OleDbHelper.ExecuteSql("delete from m_GisMapFiles");
                        (new DB_VehicleTransportManage.BLL.m_GisMapFiles()).Delete();
                        string filename;
                        string[] strFiles = Directory.GetFiles(Pub.APP_FILE_PATH_GISMAP);
                        foreach (string strFile in strFiles)
                        {
                            string mp = strFile.ToString();//包含路径
                            FileStream fs = new FileStream(mp, FileMode.Open, FileAccess.Read);
                            Byte[] byte2 = new byte[fs.Length];
                            fs.Read(byte2, 0, Convert.ToInt32(fs.Length));
                            fs.Close();
                            filename = Path.GetFileName(strFile.ToString());//去掉路径只保留文件名
                            DB_VehicleTransportManage.Model.m_GisMapFiles gismapfiles = new DB_VehicleTransportManage.Model.m_GisMapFiles();
                            gismapfiles.File_Name = filename;
                            gismapfiles.File_Data = byte2;
                            (new DB_VehicleTransportManage.BLL.m_GisMapFiles()).Add(gismapfiles);
                        }
                       DB_VehicleTransportManage.DB.OleDbHelper.Commit();
                    }
                    return true;
                }
                catch
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>拷贝地图文件 </summary>
        /// <param name="da">源文件夹</param>
        /// <param name="db">目标文件夹</param>
        public  void CopyMapFile(string da, string db)
        {
            DirectoryInfo d1 = new DirectoryInfo(da);

            if (!Directory.Exists(db))
                Directory.CreateDirectory(db);

            foreach (FileInfo f in d1.GetFiles())
            {
                System.Windows.Forms.Application.DoEvents();
                File.Copy(f.FullName, db + "\\" + f.Name, true);
            }

            foreach (DirectoryInfo d in d1.GetDirectories())
            {
                CopyMapFile(d.FullName, db + "\\" + d.Name);
            }
        }

        //地图导出
        public  void GISOut()
        {
            try
            {
                string path = "";
                FolderBrowserDialog fbDlg = new FolderBrowserDialog();
                fbDlg.Description = "请选择地图保存的路径：";
                if (DialogResult.OK == fbDlg.ShowDialog())
                {
                    path = fbDlg.SelectedPath + @"\GisMap\";
                }
                else
                {
                    return;
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                DB_VehicleTransportManage.BLL.m_GisMapFiles gismap = new DB_VehicleTransportManage.BLL.m_GisMapFiles();
                DataSet GisFilesDs = gismap.GetList("");
                for (int i = 0; i < GisFilesDs.Tables[0].Rows.Count; i++)
                {
                    //写文件
                    byte[] by = (byte[])(GisFilesDs.Tables[0].Rows[i]["file_data"]);
                    int ArraySize = by.GetUpperBound(0) + 1;
                    FileStream stream = new FileStream(path + GisFilesDs.Tables[0].Rows[i]["file_name"].ToString(), FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(by, 0, ArraySize);
                    stream.Close();
                }
                Common.MessageBoxEx.MessageBoxEx.Show("地图文件导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请确认数据库地图文件的正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

       
        /// <summary>加载地图</summary>
        /// <param name="filefullname">Map.TGF地图文件</param>
        public bool LoadMap(string filefullname)
        {
            if (_tgMap.MapLoad(filefullname) > 0)
            {
                _tgMap.DrawMapFull();
                return true;
            }
            return false;
        }

        /// <summary>放大地图</summary>
        public bool ZoomIn()
        {
            return _tgMap.ToolSet(TGMAPXLib.emTools.ETGToolZoomIn) == TGMAPXLib.emTools.ETGToolZoomIn;
        }
        /// <summary> 缩小地图</summary>
        public bool ZoomOut()
        {
            return TGMAPXLib.emTools.ETGToolZoomOut == _tgMap.ToolSet(TGMAPXLib.emTools.ETGToolZoomOut);
        }
        /// <summary> 漫游地图</summary>
        public bool Move()
        {
            return TGMAPXLib.emTools.ETGToolPan == _tgMap.ToolSet(TGMAPXLib.emTools.ETGToolPan);
        }
        /// <summary> 全图显示</summary>
        public bool DrawFull()
        {
            return _tgMap.DrawMapFull() > 0;
        }
        /// <summary> 重新绘制</summary>
        public void   DrawMap()
        {
             _tgMap.DrawMap();
        }
        /// <summary>设置成移动状态</summary>
        public bool FeatureMove()
        {
            //设置工具状态为"移动"
            //_tgMap.AfterMouseDown -= new AxTGMAPXLib._DTGMAPXEvents_AfterMouseDownEventHandler(_tgMap_AfterMouseDown);
            //_tgMap.AfterMouseUp -= new AxTGMAPXLib._DTGMAPXEvents_AfterMouseUpEventHandler(_tgMap_AfterMouseUp);
            //_tgMap.AfterMouseDown += new AxTGMAPXLib._DTGMAPXEvents_AfterMouseDownEventHandler(_tgMap_AfterMouseDown);
            //_tgMap.AfterMouseUp += new AxTGMAPXLib._DTGMAPXEvents_AfterMouseUpEventHandler(_tgMap_AfterMouseUp);
            return TGMAPXLib.emTools.ETGToolFeatureMove == _tgMap.ToolSet(TGMAPXLib.emTools.ETGToolFeatureMove);


        }
        /// <summary>设置成点选状态</summary>
        public bool PointSelect()
        {
            return TGMAPXLib.emTools.ETGToolPointSelect == _tgMap.ToolSet(TGMAPXLib.emTools.ETGToolPointSelect);
        }
        /// <summary>保存地图 </summary>
        public bool MapSave()
        {
            if (_tgMap.MapSave("") >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //增加图层
        public int AddUnSafe(string name, int i)
        {
            TGMAPXLib.TGOWorkSpaceSDP ws = new TGMAPXLib.TGOWorkSpaceSDP();
            ws.SetParameter("DataSourceType", "DataSourceFile");
            ws.SetParameter("SDPFileType", "SDPFileType_TG"); //'创建shp图层文件
            ws.SetParameter("DataBase", Pub.APP_FILE_PATH_GISMAP); //图层文件存放目录
            ws.CurrentDataSet = name;
            _tgMap.LayerCreate(i, ws, TGMAPXLib.emLayerType.ETGLayerTypePoint, true);
            return _tgMap.MapSave("");
        }
        //添加字段
        public void AddField()
        {
            int i = 0;
            _tgMap.LayerIndexGet("隐患层",ref i);
            //添加字段测试
            TGMAPXLib.TGOFieldInfo fieldInfo = new TGMAPXLib.TGOFieldInfo();
            fieldInfo.FieldName = "UnSafe";
            fieldInfo.FieldType = TGMAPXLib.emFieldType.ETGFieldTypeString;
            fieldInfo.FieldWidth = 20;
            this._tgMap.FieldAdd(i, 0, fieldInfo);
            fieldInfo.FieldName = "UnSafeMemo";
            fieldInfo.FieldType = TGMAPXLib.emFieldType.ETGFieldTypeString;
            fieldInfo.FieldWidth = 20;
            this._tgMap.FieldAdd(i, 1, fieldInfo);

            _tgMap.LayerSet(i, emLayerFlag.ETGLayerLabelFieldName, "UnSafeMemo");
            _tgMap.LayerSet(i, emLayerFlag.ETGLayerLabelPostion, 5);
            _tgMap.LayerSet(i, emLayerFlag.ETGLayerShowLabel, true);


        }

        public void ShowAll()
        {
            TGORecordSet SDPRecordSet = new TGORecordSet();
            TGOFeature pFeature = new TGOFeature();
            TGOFeatureSymbol FeatureSymbol = new TGOFeatureSymbol();
            int k = 0;
            _tgMap.LayerIndexGet("基站层", ref k);
            _tgMap.LayerSet(k, TGMAPXLib.emLayerFlag.ETGLayerEditStatus, true);
            SDPRecordSet = GetSDPRecordSet(_tgMap, k);
            if (SDPRecordSet != null)
            {
                SDPRecordSet.MoveFirst();
                while (!SDPRecordSet.EOF)
                {
                    _tgMap.FeatureAttribSet(k, SDPRecordSet.CurrentFeatureID, TGMAPXLib.emFeatureFlag.ETGFeatureVisible, true);
                    SDPRecordSet.MoveNext();
                }
                SDPRecordSet.Close();
                _tgMap.DrawMap();
            }

        }
       
        public Boolean GetJzGatherZB(long[] colFeatureIDs, ref  jzIDandZB[] jzIdZB)
        {
            jzIdZB = new jzIDandZB[colFeatureIDs.Length];
            try
            {

                TGORecordSet SDPRecordSet = new TGORecordSet();
                TGMAPXLib.TGOFeature qqq = new TGOFeature();
                TGOFeature pFeature = new TGOFeature();
                TGOFeatureSymbol FeatureSymbol = new TGOFeatureSymbol();
                int lJzIdNum;
                lJzIdNum = colFeatureIDs.Length;
                if (lJzIdNum <= 0)
                {
                    return false;
                }
                int k = 0;
                _tgMap.LayerIndexGet("基站层", ref k);
                SDPRecordSet = GetSDPRecordSet(_tgMap, k);
                if (SDPRecordSet.RowCount < 0) return false;
                for (int i = 0; i < lJzIdNum; i++)
                {
                    SDPRecordSet.MoveFirst();
                    while (!SDPRecordSet.EOF)
                    {
                        if ((long)SDPRecordSet.field["自增ID"].value  == colFeatureIDs[i])
                        {
                            pFeature = (TGOFeature)SDPRecordSet.feature;
                            if (pFeature.FeatureType == emFeatureType.ETGFeatureTypeSymbol)
                            {
                                FeatureSymbol = (TGOFeatureSymbol)pFeature;//实体位置
                                jzIdZB[i] = new jzIDandZB();
                                jzIdZB[i].jzZB.x = FeatureSymbol.Symbol.x;
                                jzIdZB[i].jzZB.y = FeatureSymbol.Symbol.y;
                            }
                        }
                        SDPRecordSet.MoveNext();
                    }
                }

                SDPRecordSet.Close();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("获取基站坐标2" + e.Message + e.StackTrace);
                return false;
            }

        }

     
     
        public void AddPersonName(string Name)
        {
            PersonName = Name;
        }

        //GIS记录集
        public TGORecordSet GetSDPRecordSet(AxTGMAPXLib.AxTGMAPX TGMAPX, int LayerIndex)
        {
            return GetSDPRecordSet(TGMAPX, LayerIndex, "");
        }

        public TGORecordSet GetSDPRecordSet(AxTGMAPXLib.AxTGMAPX TGMAPX, int LayerIndex, string strSQL)
        {
            TGOQueryFilterEx QueryFilterEx = new TGOQueryFilterEx();
            TGORecordSet SDPRecordSet = new TGORecordSet();
            QueryFilterEx.AllColumns = true;
            QueryFilterEx.HasFeatureField = true;
            QueryFilterEx.sSQLString = strSQL;
            if (LayerIndex <= 0) LayerIndex = -1;
            SDPRecordSet = TGMAPX.LayerQuery(LayerIndex, QueryFilterEx);
            return SDPRecordSet;
        }

        public event UnSafeClickedEventHandler PointClicked;
        //单击地图实体事件
        private void tgMap_AfterClick(object sender, AxTGMAPXLib._DTGMAPXEvents_AfterClickEvent e)
        {

            if (e.button == 2) this.PointSelect();
            if (e.button != 1) return;


            TGMAPXLib.TGOSelections sel = new TGMAPXLib.TGOSelections();
            _tgMap.SelectionsGet(ref sel);
            int iLayer = 0, iFeature = 0;
            object LayerName = null;
            if (sel.SelectionCount > 0 && sel.FeatureCount > 0)
            {

                iLayer = sel.Selections[0].LayerIndex;
                iFeature = sel.Selections[0].FeatureIDs[0];
                _tgMap.LayerGet(iLayer, TGMAPXLib.emLayerFlag.ETGLayerName, ref LayerName);
            }
            else
            {
                return;
            }

            //int id = -1;
            string id;
            Point pt = new Point(e.x, e.y);
            pt = _tgMap.PointToScreen(pt);


            EnumLayerName layer = EnumLayerName.None;
            try
            {
                //GetLayerNameEnum(LayerName.ToString());
                layer = (EnumLayerName)Enum.Parse(typeof(EnumLayerName), LayerName.ToString());
            }
            catch (Exception)
            {


            }
            switch (layer)
            {
                case EnumLayerName.区域层:
                case EnumLayerName.定位基站:
                case EnumLayerName.wifi基站:
                    StationEventArgs carE = new StationEventArgs();
                    object vValue = null;
                    _tgMap.ValueGet(iLayer, iFeature, 0, ref vValue);
                    try
                    {
                        id = vValue.ToString();
                    }
                    catch
                    {
                        id = "";
                    }

                    if (id != null)
                    {
                        carE.ID = Convert.ToInt32(id);
                        carE.LayerName =layer;
                    }
                    if (this.OnStationClick != null)
                    {
                        this.OnStationClick.Invoke(this, carE);
                    }
                    break;
                default:
                    break;
            }
        }


        /// <summary>轨迹</summary>
        public void Track()
        {
            PerVisual(_tgMap, false);
        }

        /// <summary>小人显隐过程</summary>
        public void PerVisual(AxTGMAPXLib.AxTGMAPX tgMap1, Boolean TF)
        {
            int person = 0;
            _tgMap.LayerIndexGet("移动实体", ref person);
            if (TF)
            {
                _tgMap.LayerSet(person, emLayerFlag.ETGLayerVisibleStatus, true);
            }
            else
            {
                _tgMap.LayerSet(person, emLayerFlag.ETGLayerVisibleStatus, false);
            }

        }

        /// <summary>清除地图上小人图标</summary>
        public void PersonClear()
        {
            int person = 0;
            _tgMap.LayerIndexGet("移动实体", ref person);
            _tgMap.LayerSet(person, emLayerFlag.ETGLayerVisibleStatus, false);
        }

        /// <summary>清空路径</summary>
        public void ClearTrack()
        {
   
            //.Enabled = false;
            int tm = 0;
            _tgMap.LayerIndexGet("temp",ref  tm);
            _tgMap.LayerClear(tm);

            points.Clear();
            Points=new TGOPoints();
            toolShort = "";
            //feaLine=null   ;
            feaLine = new TGOFeaturePolyline();
        }

        /// <summary>设定鼠标选点工具 </summary>
        public void ToolSet()
        {
            _tgMap.ToolSet(emTools.ETGToolNull);
            toolShort = "begin";
            points.Clear();
        }

        /// <summary>选中车辆实体</summary>
        /// <param name="layer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SelectCarFeature(int carid)
        {

            _tgMap.SelectionsClear();
            Model.m_Vehicle entity = bllcar.GetModel(carid);
            if (entity == null)
                return false;
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGMAPXLib.TGOQueryFilterExClass();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;
            object mapScale = null;
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapCurrentScale, ref mapScale);

            // SDPQueryFilterEx =new TGOQueryFilterExClass();// new TGMAPXLib.TGOQueryFilterExClass();
            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[LocalizerStationID]=" + entity.i_LocalizerStationID;

            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.定位基站), SDPQueryFilterEx);
            if (SDPRs == null)
            {
                return false;
            }
            while (SDPRs != null && !SDPRs.EOF)
            {

                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                //long i = _tgMap.ZoomToCenterScale(500, 200, (double)mapScale);
                long i=_tgMap.ZoomToCenterScale(feature.Symbol.x, feature.Symbol.y, (double)mapScale);
                _tgMap.FeatureSelect(GetLayerIndex(EnumLayerName.定位基站), SDPRs.CurrentFeatureID);
                _tgMap.DrawMap();
                break;
                //SDPRs.Delete();

            }
            SDPRs.Close();
            //_tgMap.DrawMapDynamic(); //重新绘制地图
            //_tgMap.DrawMapFull();
            //_tgMap.MapSave("");
            return true;
        }

        /// <summary>
        /// 选中定位基站
        /// </summary>
        /// <param name="carid"></param>
        /// <returns></returns>
        public bool SelectDWFeature(int dwid)
        {

            _tgMap.SelectionsClear();
            Model.m_Address entity = blladdress.GetModel(dwid);
            if (entity == null)
                return false;
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGMAPXLib.TGOQueryFilterExClass();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            // SDPQueryFilterEx =new TGOQueryFilterExClass();// new TGMAPXLib.TGOQueryFilterExClass();
            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[ID]=" + dwid;
            object mapScale = null;
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapCurrentScale, ref mapScale);
            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.定位基站), SDPQueryFilterEx);
            if (SDPRs == null)
            {
                return false;
            }
            while (SDPRs != null && !SDPRs.EOF)
            {
                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                //long i = _tgMap.ZoomToCenterScale(500, 200, (double)mapScale);
                long i = _tgMap.ZoomToCenterScale(feature.Symbol.x, feature.Symbol.y, (double)mapScale);
                _tgMap.FeatureSelect(GetLayerIndex(EnumLayerName.定位基站), SDPRs.CurrentFeatureID);
                _tgMap.DrawMap();
                break;
            }
            SDPRs.Close();
            //_tgMap.DrawMapDynamic(); //重新绘制地图
            //_tgMap.DrawMapFull();
            //_tgMap.MapSave("");
            return true;
        }

        public bool SelectAreaFeature(int areaid)
        {

            _tgMap.SelectionsClear();

            Model.m_Area entity = bllarea.GetModel(areaid);
            if (entity == null)
                return false;
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGMAPXLib.TGOQueryFilterExClass();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            // SDPQueryFilterEx =new TGOQueryFilterExClass();// new TGMAPXLib.TGOQueryFilterExClass();
            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[ID]=" + areaid;
            object mapScale = null;
            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapCurrentScale, ref mapScale);
            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.区域层), SDPQueryFilterEx);
            if (SDPRs == null)
            {
                return false;
            }
            while (SDPRs != null && !SDPRs.EOF)
            {
                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                //long i = _tgMap.ZoomToCenterScale(500, 200, (double)mapScale);
                long i = _tgMap.ZoomToCenterScale(feature.Symbol.x, feature.Symbol.y, (double)mapScale);
                _tgMap.FeatureSelect(GetLayerIndex(EnumLayerName.区域层), SDPRs.CurrentFeatureID);
                _tgMap.DrawMap();
                break;
            }
            SDPRs.Close();
            //_tgMap.DrawMapDynamic(); //重新绘制地图
            //_tgMap.DrawMapFull();
            //_tgMap.MapSave("");
            return true;
        }
      
    

        /// <summary>显示车辆实时位置</summary>
        public void ShowCarRealPostion(int carid, int DW_BaseStationID)
        {
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGOQueryFilterEx();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "";

            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.车辆), SDPQueryFilterEx);
            Model.m_Vehicle entity = bllcar.GetModel(carid);
            while (!SDPRs.EOF)
            {
                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                feature.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();
                if (Convert.ToInt32(SDPRs.get_field("ID").value.ToString()) == carid)
                {
                    PointZB p = GetCarZB(DW_BaseStationID.ToString());
                    feature.Symbol.x = p.x;
                    feature.Symbol.y = p.y;
                    // feature.SymStyle.Angle = 45;
                    if (entity.i_State == (int)Common.Enum.EnumVehicleState.Normal)
                    {
                        feature.SymStyle.index = EnumStyleIndex.CarNormal.GetHashCode();
                    }
                    if (entity.i_State == (int)Common.Enum.EnumVehicleState.Using)
                    {
                        feature.SymStyle.index = EnumStyleIndex.CarUse.GetHashCode();
                    }
                    if (entity.i_State == (int)Common.Enum.EnumVehicleState.Maintaining)
                    {
                        feature.SymStyle.index = EnumStyleIndex.CarMation.GetHashCode();
                    }
                    if (entity.i_State == (int)Common.Enum.EnumVehicleState.Scrap)
                    {
                        feature.SymStyle.index = EnumStyleIndex.CarScrap.GetHashCode();
                    }
                    

                    SDPRs.feature = (TGMAPXLib.ITGOFeature)feature;
                    break;
                }

                SDPRs.MoveNext();
            }
            SDPRs.Close();	//确认更新
            _tgMap.DrawMapDynamic(); //重新绘制地图
        }

        public PointZB GetCarZB(string DW_BaseStationID)
        {
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGOQueryFilterEx();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[ID]=" + DW_BaseStationID;


            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.定位基站), SDPQueryFilterEx);
            //Point p = new Point();
            PointZB p = new PointZB();
            while (!SDPRs.EOF)
            {
                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                p.x = feature.Symbol.x;
                p.y = feature.Symbol.y;
                SDPRs.MoveNext();
            }
            SDPRs.Close();
            return p;
        }
        public PointZB GetPDAZB(string wifiid)
        {
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGOQueryFilterEx();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[ID]=" + wifiid;


            SDPRs = _tgMap.LayerQuery(GetLayerIndex(EnumLayerName.wifi基站), SDPQueryFilterEx);
            //Point p = new Point();
            PointZB p = new PointZB();
            while (!SDPRs.EOF)
            {
                feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                p.x = feature.Symbol.x;
                p.y = feature.Symbol.y;
                SDPRs.MoveNext();
            }
            SDPRs.Close();
            return p;
        }

        public int GetLayerIndex(EnumLayerName layer)
        {
            int iLayer = -1;
            _tgMap.LayerIndexGet(layer.ToString(), ref iLayer);
            return iLayer;
        }
        /// <summary>增加实体</summary>
        /// <returns></returns>
        public bool AddFeature(EnumLayerName layer, object model, bool isSave)
        {
            try
            {
                ////添加点实体
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;

                switch (layer)
                {
                    case EnumLayerName.None:
                        break;
                    //case EnumLayerName.车辆:
                    //    DB_VehicleTransportManage.Model.m_Vehicle mCar = (DB_VehicleTransportManage.Model.m_Vehicle)model;
                    //    QueryFilterEX.sSQLString = "[ID]=" + mCar.ID;
                    //    break;
                    case EnumLayerName.wifi基站:
                        DB_VehicleTransportManage.Model.m_WifiBaseStation m_RFID = (DB_VehicleTransportManage.Model.m_WifiBaseStation)model;
                        QueryFilterEX.sSQLString = "[ID]=" + m_RFID.ID;
                        break;
                    case EnumLayerName.定位基站:
                        DB_VehicleTransportManage.Model.m_Address m_Wifi = (DB_VehicleTransportManage.Model.m_Address)model;
                        QueryFilterEX.sSQLString = "[ID]=" + m_Wifi.ID;
                        break;
                    case EnumLayerName.区域层:
                        DB_VehicleTransportManage.Model.m_Area m_Area = (DB_VehicleTransportManage.Model.m_Area)model;
                        QueryFilterEX.sSQLString = "[ID]=" + m_Area.ID;
                        break;
                    //case EnumLayerName.手机:
                    //    DB_VehicleTransportManage.Model.v_PDA mLED = (DB_VehicleTransportManage.Model.v_PDA)model;
                    //    QueryFilterEX.sSQLString = "[ID]=" + mLED.ID;
                    //    break;
                    default:
                        break;
                }



                int layerID = GetLayerIndex(layer);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);

                if (SDPRecordSet.EOF == true)
                {


                    TGOPoint MapCenter = MapCenterPoint();


                    switch (layer)
                    {
                        case EnumLayerName.None:
                            break;
                        //case EnumLayerName.车辆:
                        //    pFeatureSymbol.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();
                        //    pFeatureSymbol.SymStyle.index = EnumStyleIndex.CarNormal.GetHashCode();
                        //    break;
                        case EnumLayerName.wifi基站:
                            pFeatureSymbol.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.WifiStationNormal.GetHashCode();
                            break;
                        case EnumLayerName.定位基站:
                            pFeatureSymbol.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.DWBaseStationNormal.GetHashCode();
                            break;
                        case EnumLayerName.区域层:
                            pFeatureSymbol.SymStyle.Lib = 1;
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.Area.GetHashCode();
                            pFeatureSymbol.SymStyle.ForeColor.A = 255;
                            pFeatureSymbol.SymStyle.ForeColor.R = 255;
                            pFeatureSymbol.SymStyle.ForeColor.G = 0;
                            pFeatureSymbol.SymStyle.ForeColor.B = 0;
                            break;
                        //case EnumLayerName.手机:
                        //    pFeatureSymbol.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();
                        //    pFeatureSymbol.SymStyle.index = EnumStyleIndex.PdaNormal.GetHashCode();
                        //    break;
                        case EnumLayerName.轨道:
                            pFeatureSymbol.SymStyle.index = 102;
                            break;
                        default:
                            break;
                    }

                    //pFeatureSymbol.SymStyle.Width = 4;
                    //pFeatureSymbol.SymStyle.Height = 4;
                    pFeatureSymbol.Symbol.x = MapCenter.x;
                    pFeatureSymbol.Symbol.y = MapCenter.y;

                    SDPRecordSet.AddNew();

                    switch (layer)
                    {
                        case EnumLayerName.None:
                            break;
                        //case EnumLayerName.车辆:
                        //    DB_VehicleTransportManage.Model.m_Vehicle mCar = (DB_VehicleTransportManage.Model.m_Vehicle)model;
                        //    SDPRecordSet.get_field("ID").value = mCar.ID;
                        //    SDPRecordSet.get_field("vc_name").value = mCar.vc_Name;
                        //    SDPRecordSet.get_field("vc_code").value = mCar.vc_Code;
                        //    break;
                        case EnumLayerName.wifi基站:
                            pFeatureSymbol.SymStyle.Width = 4;
                            pFeatureSymbol.SymStyle.Height = 4;
                            DB_VehicleTransportManage.Model.m_WifiBaseStation m_wifi = (DB_VehicleTransportManage.Model.m_WifiBaseStation)model;
                            SDPRecordSet.get_field("ID").value = m_wifi.ID;
                            SDPRecordSet.get_field("vc_name").value = m_wifi.vc_Name;

                            break;
                        case EnumLayerName.定位基站:
                            pFeatureSymbol.SymStyle.Width = 4;
                            pFeatureSymbol.SymStyle.Height = 4;
                            DB_VehicleTransportManage.Model.m_Address m_address = (DB_VehicleTransportManage.Model.m_Address)model;
                            SDPRecordSet.get_field("ID").value = m_address.ID;
                            SDPRecordSet.get_field("vc_name").value = m_address.vc_Name.ToString();
                            SDPRecordSet.get_field("LocalizerStationID").value = m_address.LocalizerStationID.ToString();
                            break;
                        case EnumLayerName.区域层:
                            pFeatureSymbol.SymStyle.Width = 5;
                            pFeatureSymbol.SymStyle.Height = 5;
                            DB_VehicleTransportManage.Model.m_Area m_Area = (DB_VehicleTransportManage.Model.m_Area)model;
                            SDPRecordSet.get_field("ID").value = m_Area.ID;
                            SDPRecordSet.get_field("vc_name").value = m_Area.vc_Name.ToString();
                            SDPRecordSet.get_field("vc_code").value = m_Area.vc_Code.ToString();
                            
                            break;
                        //case EnumLayerName.手机:
                        //    DB_VehicleTransportManage.Model.v_PDA m_pda = (DB_VehicleTransportManage.Model.v_PDA)model;
                        //    SDPRecordSet.get_field("ID").value = m_pda.ID;
                        //    SDPRecordSet.get_field("vc_macaddress").value = m_pda.vc_MacAddress;
                        //    SDPRecordSet.get_field("deptname").value = m_pda.deptname;
                        //    SDPRecordSet.get_field("vc_username").value = m_pda.usename;
                        //    SDPRecordSet.get_field("vc_code").value = m_pda.vc_code;
                        //    break;
                        default:
                            break;
                    }


                    SDPRecordSet.feature = pFeatureSymbol;
                }
                SDPRecordSet.Close();
                if (isSave)
                {
                    _tgMap.DrawMap();
                    _tgMap.MapSave("");
                    _tgMap.LayerSave(layerID, true);
                    Pub.GisManage.MapFileSaveToDB();  //保存到数据库
                    Pub.BackServer.SendGISChange();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>修改实体</summary>
        /// <returns></returns>
        public bool ModifyFeature(EnumLayerName layer, object model, bool isSave)
        {
            try
            {
               
                ////添加点实体
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;
                switch (layer)
                {
                    case EnumLayerName.None:
                        break;
                    //case EnumLayerName.车辆:
                    //    DB_VehicleTransportManage.Model.m_Vehicle mCar = (DB_VehicleTransportManage.Model.m_Vehicle)model;
                    //    QueryFilterEX.sSQLString = "[ID]=" + mCar.ID;
                    //    break;
                    case EnumLayerName.wifi基站:
                        DB_VehicleTransportManage.Model.m_WifiBaseStation mWifi = (DB_VehicleTransportManage.Model.m_WifiBaseStation)model;
                        QueryFilterEX.sSQLString = "[ID]=" + mWifi.ID;
                        break;
                    case EnumLayerName.定位基站:
                        DB_VehicleTransportManage.Model.m_Address mAdress = (DB_VehicleTransportManage.Model.m_Address)model;
                        QueryFilterEX.sSQLString = "[ID]=" + mAdress.ID;
                        break;
                    case EnumLayerName.区域层:
                        DB_VehicleTransportManage.Model.m_Area mArea = (DB_VehicleTransportManage.Model.m_Area)model;
                        QueryFilterEX.sSQLString = "[ID]=" + mArea.ID;
                        break;
                    //case EnumLayerName.手机:
                    //    DB_VehicleTransportManage.Model.v_PDA mPDA = (DB_VehicleTransportManage.Model.v_PDA)model;
                    //    QueryFilterEX.sSQLString = "[ID]=" + mPDA.ID;
                    //    break;
                    default:
                        break;
                }

                int layerID = GetLayerIndex(layer);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);


                switch (layer)
                {
                    case EnumLayerName.None:
                        break;
                    //case EnumLayerName.车辆:
                    //    DB_VehicleTransportManage.Model.m_Vehicle mCar = (DB_VehicleTransportManage.Model.m_Vehicle)model;
                    //    SDPRecordSet.get_field("ID").value = mCar.ID;
                    //    SDPRecordSet.get_field("vc_name").value = mCar.vc_Name;
                    //    SDPRecordSet.get_field("vc_code").value = mCar.vc_Code;
                    //    break;
                    case EnumLayerName.wifi基站:
                        DB_VehicleTransportManage.Model.m_WifiBaseStation m_WIFI = (DB_VehicleTransportManage.Model.m_WifiBaseStation)model;
                        SDPRecordSet.get_field("ID").value = m_WIFI.ID;
                        SDPRecordSet.get_field("vc_name").value = m_WIFI.vc_Name;
                        break;
                    case EnumLayerName.定位基站:
                        DB_VehicleTransportManage.Model.m_Address m_address = (DB_VehicleTransportManage.Model.m_Address)model;
                        SDPRecordSet.get_field("ID").value = m_address.ID;
                        SDPRecordSet.get_field("vc_name").value = m_address.vc_Name.ToString();
                        SDPRecordSet.get_field("LocalizerStationID").value = m_address.LocalizerStationID;
                        break;
                    case EnumLayerName.区域层:
                        DB_VehicleTransportManage.Model.m_Area m_Area = (DB_VehicleTransportManage.Model.m_Area)model;
                        SDPRecordSet.get_field("ID").value = m_Area.ID;
                        SDPRecordSet.get_field("vc_name").value = m_Area.vc_Name.ToString();
                        SDPRecordSet.get_field("vc_code").value = m_Area.vc_Code.ToString();
                        
                        break;
                    //case EnumLayerName.手机:
                    //    DB_VehicleTransportManage.Model.v_PDA mPDA = (DB_VehicleTransportManage.Model.v_PDA)model;
                    //    SDPRecordSet.get_field("vc_macaddress").value = mPDA.vc_MacAddress;
                    //    SDPRecordSet.get_field("deptname").value = mPDA.deptname;
                    //    SDPRecordSet.get_field("vc_username").value = mPDA.usename;
                    //    SDPRecordSet.get_field("vc_code").value = mPDA.vc_code;
                    //    break;
                    default:
                        break;
                }



                SDPRecordSet.Close();
                if (isSave)
                {
                    _tgMap.DrawMap();
                    _tgMap.MapSave("");
                    _tgMap.LayerSave(layerID, true);
                    Pub.GisManage.MapFileSaveToDB();  //保存到数据库
                    Pub.BackServer.SendGISChange();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>删除实体</summary>
        /// <param name="layer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFeature(EnumLayerName layer, int id)
        {
            TGMAPXLib.TGOQueryFilterEx SDPQueryFilterEx = new TGOQueryFilterEx();
            TGMAPXLib.TGORecordSet SDPRs;
            TGMAPXLib.TGOFeatureSymbol feature;

            // SDPQueryFilterEx =new TGOQueryFilterExClass();// new TGMAPXLib.TGOQueryFilterExClass();
            SDPQueryFilterEx.AllColumns = true;
            SDPQueryFilterEx.QueryMode = TGMAPXLib.emQueryMode.ETGSDP_SpatialSearch_None;
            SDPQueryFilterEx.sSQLString = "[ID]=" + id;

            SDPRs = _tgMap.LayerQuery(GetLayerIndex(layer), SDPQueryFilterEx);
            while (!SDPRs.EOF)
            {
                //  feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;


                SDPRs.Delete();

                SDPRs.MoveNext();
            }
            SDPRs.Close();
            _tgMap.DrawMapDynamic(); //重新绘制地图
            //_tgMap.DrawMapFull();
            _tgMap.DrawMap();
            _tgMap.MapSave("");
            Pub.GisManage.MapFileSaveToDB();  //保存到数据库
            Pub.BackServer.SendGISChange();

            return true;
        }
        ////计算地图坐标
        private TGOPoint MapCenterPoint()
        {
            object LeftX = null;
            object RightX = null;
            object TopY = null;
            object BottonY = null;
            int interval = Pub.ConfigModel.MapY; // 1;//间隔200
            double x, y;

            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundLeft, ref LeftX);

            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundRight, ref RightX);

            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundTop, ref TopY);

            _tgMap.MapGet(TGMAPXLib.emMapFlag.ETGMapBoundBottom, ref BottonY);

            RightX = Convert.ToDouble(RightX) - Pub.ConfigModel.MapY; //1;//向左移500

            double FeatureTopY = 0;

            FeatureTopY = Convert.ToDouble(TopY) - interval;

            y = FeatureTopY - _iXCount * interval;

            x = Convert.ToDouble(RightX) - _iYcount * interval;

            if (y < Convert.ToDouble(BottonY))
            {
                _iYcount++;
                _iXCount = 0;

                y = FeatureTopY - _iXCount * interval;

                x = (Convert.ToDouble(RightX) - _iYcount * interval);
            }

            if (x < Convert.ToDouble(LeftX))
            {
                _iXCount = 0;
                _iYcount = 0;

                y = FeatureTopY - _iXCount * interval;

                x = Convert.ToDouble(RightX) - _iYcount * interval;
            }


            TGOPoint p = new TGOPoint();

            p.x = x;
            p.y = y;

            _iXCount++;

            return p;
        }

        /// <summary>同步GIS和数据库</summary>
        public void UpdateGisAndDB()
        {
            //UpdateGisAndDB(EnumLayerName.车辆, false);
            UpdateGisAndDB(EnumLayerName.wifi基站, false);
            UpdateGisAndDB(EnumLayerName.定位基站, false);
            UpdateGisAndDB(EnumLayerName.区域层, false);
            //UpdateGisAndDB(EnumLayerName.手机, false);


            //List<DB_VehicleTransportManage.Model.m_Vehicle> lstCar = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList("i_flag=0");
            //foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lstCar)
            //{
            //    AddFeature(EnumLayerName.车辆, item, false);
            //    if (item.i_State == 0)
            //    {
            //        UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarNormal, false);
            //    }
            //    else if (item.i_State == 1)
            //    {
            //        UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarUse, false);
            //    }
            //    else if (item.i_State == 2)
            //    {
            //        UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarMation, false);
            //    }
            //    else if (item.i_State == 3)
            //    {
            //        UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarScrap, false);
            //    }
            //}

            List<DB_VehicleTransportManage.Model.m_WifiBaseStation> lstLED = new DB_VehicleTransportManage.BLL.m_WifiBaseStation().GetModelList("i_flag=0");
            foreach (DB_VehicleTransportManage.Model.m_WifiBaseStation item in lstLED)
            {
                AddFeature(EnumLayerName.wifi基站, item, false);
                if (item.i_State.Value == 1)
                    UpdateFeatureState(EnumLayerName.wifi基站, item.ID, EnumStyleIndex.WifiStationNormal, false);
                else
                    UpdateFeatureState(EnumLayerName.wifi基站, item.ID, EnumStyleIndex.WifiStationOffLine, false);
            }

            List<DB_VehicleTransportManage.Model.m_Address> lstBroadCast = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_flag=0");
            foreach (DB_VehicleTransportManage.Model.m_Address item in lstBroadCast)
            {
                AddFeature(EnumLayerName.定位基站, item, false);
                if (new BLL.m_Address().IsOnLine(item.LocalizerStationID.Value))
                    UpdateFeatureState(EnumLayerName.定位基站, item.ID, EnumStyleIndex.DWBaseStationNormal, false);
                else
                    UpdateFeatureState(EnumLayerName.定位基站, item.ID, EnumStyleIndex.DWBaseStationOffLine, false);
            }
            List<DB_VehicleTransportManage.Model.m_Area> lstarea = bllarea.GetModelList("i_flag=0");
            foreach (DB_VehicleTransportManage.Model.m_Area item in lstarea)
            {
                AddFeature(EnumLayerName.区域层, item, false);
             
            }
            UpdataGisAndDBRemark();

            _tgMap.DrawMap();
            _tgMap.MapSave("");
            //_tgMap.DrawMapFull();
            _tgMap.Refresh();
            Pub.GisManage.MapFileSaveToDB();  //保存到数据库
            Pub.BackServer.SendGISChange();


        }
        /// <summary>
        /// 初始化基站备注信息
        /// </summary>
        public void UpdataGisAndDBRemark()
        {
            try
            {
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;
                QueryFilterEX.sSQLString = "";

                int layerID = GetLayerIndex(EnumLayerName.定位基站);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);
                while (!SDPRecordSet.EOF)
                {

                    string localid = SDPRecordSet.get_field("LocalizerStationID").value.ToString();
               
                    List<Model.m_Address> listaddress = blladdress.GetModelList("LocalizerStationID=" + localid + " and i_Flag=0");
                    if (listaddress == null || listaddress.Count == 0)
                    {
                        SDPRecordSet.MoveNext();
                        continue;
                    }
                    List<Model.v_Address> vaddress = bllvaddress.GetModelList("ID=" + listaddress[0].ID);
                    string code = listaddress[0].vc_Name;
                    if (vaddress != null && vaddress.Count > 0)
                    {
                        code = string.IsNullOrEmpty(vaddress[0].vc_Code) ? listaddress[0].vc_Name : vaddress[0].vc_Code;
                    }
                    List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID=" + localid + " and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                    List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID=" + localid + " and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                    if (listnormarlcar.Count > 0 || listusecar.Count > 0)
                    {
                      
                        int normarl = listnormarlcar == null ? 0 : listnormarlcar.Count;
                        int use = listusecar == null ? 0 : listusecar.Count;
                        SDPRecordSet.get_field("vc_remark").value = code + "(空车:" + normarl + " 重车:" + use + ")";
                        pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                        if (listaddress[0].i_State == (int)Common.Enum.EnumDWStationStateType.OffLine)
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.DWBaseStationOffLine2.GetHashCode();
                        }
                        else
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.DWBaseStationNormal2.GetHashCode();
                        }
                        SDPRecordSet.feature = pFeatureSymbol;
                    }
                    else
                    {
                       
                        SDPRecordSet.get_field("vc_remark").value = code;
                        pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                        if (listaddress[0].i_State == (int)Common.Enum.EnumDWStationStateType.OffLine)
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.DWBaseStationOffLine.GetHashCode();
                        }
                        else
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.DWBaseStationNormal.GetHashCode();
                        }
                        SDPRecordSet.feature = pFeatureSymbol;
                    }
                    SDPRecordSet.MoveNext();
                }
                SDPRecordSet.Close();

                layerID = GetLayerIndex(EnumLayerName.wifi基站);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);
                while (!SDPRecordSet.EOF)
                {
                    string wifiid = SDPRecordSet.get_field("ID").value.ToString();
                    List<Model.m_WifiBaseStation> listwifi = bllwifi.GetModelList("ID=" + wifiid);
                    if (listwifi == null || listwifi.Count == 0)
                    {
                        SDPRecordSet.MoveNext();
                        continue;
                    }
                    List<Model.m_User> listuses = blluser.GetModelList("i_state=1 and i_IsPDA=" + (int)Common.Enum.EnumUserType.PDA + " and WifiBaseStationID=" + wifiid + " and i_flag=0");
                    if (listuses.Count > 0)
                    {
                        int count = listuses == null ? 0 : listuses.Count;
                        SDPRecordSet.get_field("vc_remark").value = listwifi[0].vc_Name + "(PDA用户个数:" + count + ")";
                        pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                        if (listwifi[0].i_State == (int)Common.Enum.EnumWifiStationStateType.OffLine)
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.WifiStationOffLine2.GetHashCode();
                        }
                        else
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.WifiStationNormal2.GetHashCode();
                        }
                        SDPRecordSet.feature = pFeatureSymbol;
                    }
                    else
                    {

                        SDPRecordSet.get_field("vc_remark").value = listwifi[0].vc_Name;
                        pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                        if (listwifi[0].i_State == (int)Common.Enum.EnumWifiStationStateType.OffLine)
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.WifiStationOffLine.GetHashCode();
                        }
                        else
                        {
                            pFeatureSymbol.SymStyle.index = EnumStyleIndex.WifiStationNormal.GetHashCode();
                        }
                        SDPRecordSet.feature = pFeatureSymbol;
                    }
                    SDPRecordSet.MoveNext();
                }
                SDPRecordSet.Close();

                layerID = GetLayerIndex(EnumLayerName.区域层);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);
                while (!SDPRecordSet.EOF)
                {

                    string areaid = SDPRecordSet.get_field("ID").value.ToString();

                    Model.m_Area area = bllarea.GetModel(int.Parse(areaid));
                    if (area == null)
                    {
                        SDPRecordSet.MoveNext();
                        continue;
                    }
                    SDPRecordSet.get_field("vc_remark").value = area.vc_Name;
                    List<Model.m_Address> listaddress = blladdress.GetModelList("i_Flag=0 and AreaID=" + areaid);
                    string localids="";
                    for (int i = 0; i < listaddress.Count; i++)
                    {
                        localids = localids + "," + listaddress[i].LocalizerStationID; 
                    }
                    if (string.IsNullOrEmpty(localids))
                    {
                        SDPRecordSet.MoveNext();
                        continue;
                    }
                    localids = localids.Remove(0, 1);
                    List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                    List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                    if (listnormarlcar.Count > 0 || listusecar.Count > 0)
                    {
                        int normarl = listnormarlcar == null ? 0 : listnormarlcar.Count;
                        int use = listusecar == null ? 0 : listusecar.Count;
                        SDPRecordSet.get_field("vc_remark").value = area.vc_Name + "(空车:" + normarl + " 重车:" + use + ")";
                        
                    }
                   
                    SDPRecordSet.MoveNext();
                }
                SDPRecordSet.Close();


                    _tgMap.DrawMap();
                _tgMap.Refresh();
            }
            catch(Exception exc)
            {
                WriteLog.AppendErrorLog("地图错误"+exc.ToString());
            }


        }
       public void ShowRemark(bool show)
        {
            if (show == false)
            {
                int FloatLayerIndex = -1;

                FloatLayerIndex = _tgMap.FloatTableLayerIndexGet("图例");

                _tgMap.FloatLayerRemove(FloatLayerIndex);

                //_tgMap.FloatLayerSave(FloatLayerIndex, "图例");
                _tgMap.DrawMap();

            }
        }
        /// <summary>同步GIS和数据库</summary>
        public void UpdateGisAndDBState()
        {
            List<DB_VehicleTransportManage.Model.m_Address> lstBroadCast = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_flag=0");
            foreach (DB_VehicleTransportManage.Model.m_Address item in lstBroadCast)
            {
                //AddFeature(EnumLayerName.定位基站, item, false);
                if (new BLL.m_Address().IsOnLine(item.LocalizerStationID.Value))
                    UpdateFeatureState(EnumLayerName.定位基站, item.ID, EnumStyleIndex.DWBaseStationNormal, false);
                else
                    UpdateFeatureState(EnumLayerName.定位基站, item.ID, EnumStyleIndex.DWBaseStationOffLine, false);
            }

          

        }
        /// <summary>修改实体状态</summary>
        /// <param name="layer"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateFeatureState(EnumLayerName layer, int id, EnumStyleIndex alarmType, bool isSave)
        {
            try
            {
                ////添加点实体
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;

                QueryFilterEX.sSQLString = "[ID]=" + id;
                int layerID = GetLayerIndex(layer);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);



                if (SDPRecordSet == null || SDPRecordSet.RowCount == 0) return false;
                //修改实体样式
                SDPRecordSet.MoveFirst();
                pFeatureSymbol = (TGOFeatureSymbol)SDPRecordSet.feature;
                pFeatureSymbol.SymStyle.Lib = EnumStyleLib.UserStyle0.GetHashCode();

                //switch (layer)
                //{
                //    case EnumLayerName.None:
                //        break;
                //    case EnumLayerName.车辆:
                //        pFeatureSymbol.SymStyle.index = alarmType.GetHashCode();
                //        break;
                //    case EnumLayerName.wifi基站:
                //        pFeatureSymbol.SymStyle.index = alarmType.GetHashCode();
                //        break;
                //    case EnumLayerName.LED:
                //        pFeatureSymbol.SymStyle.index = alarmType.GetHashCode();
                //        break;
                //    case EnumLayerName.喇叭:
                //        pFeatureSymbol.SymStyle.index = alarmType.GetHashCode();
                //        break;
                //    case EnumLayerName.轨道:
                //        break;
                //    default:
                //        break;
                //}
                //pFeatureSymbol.SymStyle.Width = 6;
                //pFeatureSymbol.SymStyle.Height = 6;
                pFeatureSymbol.SymStyle.index = alarmType.GetHashCode();
                SDPRecordSet.feature = pFeatureSymbol;

                SDPRecordSet.Close();
                if (isSave)
                {
                    _tgMap.LayerSave(layerID, true);
                    _tgMap.DrawMap();
                    _tgMap.MapSave("");
                    //_tgMap.DrawMapFull();
                    _tgMap.Refresh();
                    Pub.GisManage.MapFileSaveToDB();  //保存到数据库
                    Pub.BackServer.SendGISChange();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>同步GIS和数据库，如果数据库里不存在，删除地图上的实体</summary>
        private bool UpdateGisAndDB(EnumLayerName layer, bool isSave)
        {
            try
            {
                ////添加点实体
                TGMAPXLib.TGOQueryFilterEx QueryFilterEX = new TGMAPXLib.TGOQueryFilterEx();
                TGMAPXLib.TGORecordSet SDPRecordSet = new TGMAPXLib.TGORecordSet();
                TGMAPXLib.TGOFeatureSymbol pFeatureSymbol = new TGMAPXLib.TGOFeatureSymbol();

                QueryFilterEX.AllColumns = true;
                QueryFilterEX.HasFeatureField = true;
                QueryFilterEX.sSQLString = "";

                int layerID = GetLayerIndex(layer);
                SDPRecordSet = _tgMap.LayerQuery(layerID, QueryFilterEX);

                
                while (!SDPRecordSet.EOF)
                {
                    //  feature = (TGMAPXLib.TGOFeatureSymbol)SDPRs.feature;
                    switch (layer)
                    {
                        case EnumLayerName.None:
                            break;
                        //case EnumLayerName.车辆:
                        //    if (SDPRecordSet.get_field("ID").value.ToString() == "")
                        //    {
                        //        SDPRecordSet.Delete();
                        //    }
                        //    else
                        //    {
                        //        Model.m_Vehicle entity=new BLL.m_Vehicle().GetModel(Convert.ToInt32(SDPRecordSet.get_field("ID").value));
                        //        if (entity == null || entity.i_Flag == 1)
                        //        {
                        //            SDPRecordSet.Delete();
                        //        }
                        //    }

                        //    break;
                        //case EnumLayerName.手机:
                        //    if (SDPRecordSet.get_field("ID").value.ToString() == "")
                        //    {
                        //        SDPRecordSet.Delete();
                        //    }
                        //    else 
                        //    {
                        //        Model.m_PDA entity = new BLL.m_PDA().GetModel(Convert.ToInt32(SDPRecordSet.get_field("ID").value));
                        //        if (entity == null || entity.i_Flag == 1)
                        //        {
                        //            SDPRecordSet.Delete();
                        //        }
                        //    }
                        //    break;
                        case EnumLayerName.wifi基站:
                            if (SDPRecordSet.get_field("ID").value.ToString() == "")
                            {
                                SDPRecordSet.Delete();
                            }
                            else
                            {
                                Model.m_WifiBaseStation entity = new BLL.m_WifiBaseStation().GetModel(Convert.ToInt32(SDPRecordSet.get_field("ID").value));
                                if (entity == null || entity.i_Flag == 1)
                                {
                                    SDPRecordSet.Delete();
                                }
                            }
                            break;
                        case EnumLayerName.定位基站:
                            if (SDPRecordSet.get_field("ID").value.ToString() == "")
                            {
                                SDPRecordSet.Delete();
                            }
                            else
                            {
                                Model.m_Address entity = new BLL.m_Address().GetModel(Convert.ToInt32(SDPRecordSet.get_field("ID").value));
                                if (entity == null || entity.i_Flag == 1)
                                {
                                    SDPRecordSet.Delete();
                                }
                            }
                            break;

                        case EnumLayerName.区域层:
                            if (SDPRecordSet.get_field("ID").value.ToString() == "")
                            {
                                SDPRecordSet.Delete();
                            }
                            else
                            {
                                Model.m_Area entity = bllarea.GetModel(Convert.ToInt32(SDPRecordSet.get_field("ID").value));
                                if (entity == null || entity.i_Flag == 1)
                                {
                                    SDPRecordSet.Delete();
                                }
                            }
                            break;
                       
                        default:
                            break;
                    }
                    //  SDPRecordSet.Delete();

                    SDPRecordSet.MoveNext();
                }


                SDPRecordSet.Close();

                if (isSave)
                {
                    _tgMap.DrawMap();
                    _tgMap.MapSave("");
                    _tgMap.LayerSave(layerID, true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
     public class PointZB
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class jzIDandZB
    {
        public string  jzID { get; set; }
        public string  lab { get; set; }
        public PointZB jzZB = new PointZB();
    }
    /// <summary>图层名称</summary>
    public enum EnumLayerName
    {
        None,
        区域层,
        /// <summary>
        /// 车辆
        /// </summary>
        车辆,
        /// <summary>
        /// wifi基站
        /// </summary>
        wifi基站,
        /// <summary>
        /// 定位基站 
        /// </summary>
        定位基站,
        /// <summary>
        /// 
        /// </summary>
        手机,
        /// <summary>
        /// 轨道
        /// </summary>
        轨道,
        /// <summary>
        /// 轨迹
        /// </summary>
        轨迹,

        网络层_NET,

        移动实体

    }
    /// <summary>样式库</summary>
    public enum EnumStyleLib
    {
        /// <summary>自定义0</summary>
        UserStyle0 = 11
    }

    /// <summary>样式索引,与地图样式文件对应</summary>
    public enum EnumStyleIndex
    {
           /// <summary>PDA正常</summary>
        PdaNormal = 102,
        /// <summary>
        /// pda不在线
        /// </summary>
        PDAOffLine=103,

        /// <summary>车正常</summary>
        CarNormal = 104,
        /// <summary>车在用</summary>
        CarUse= 105,
        /// <summary>车在修</summary>
        CarMation = 106,
        /// <summary>车报废</summary>
        CarScrap = 107,
        /// <summary>基站正常</summary>
        DWBaseStationNormal = 110,
        /// <summary>
        /// 基站不在线
        /// </summary>
        DWBaseStationOffLine=111,
        /// <summary>Wifi基站不在线</summary>
        WifiStationOffLine = 109,
        /// <summary>
        /// WIFI基站正常
        /// </summary>
        WifiStationNormal=108,

        DWBaseStationNormal2 = 112,
        DWBaseStationOffLine2 = 113,
        WifiStationOffLine2 = 114,
        WifiStationNormal2 = 115,
        Area=1020703

    }
}
