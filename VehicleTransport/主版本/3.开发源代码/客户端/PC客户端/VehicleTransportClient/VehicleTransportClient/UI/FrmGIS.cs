using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Common.MessageBoxEx;
using VehicleTransportClient.Com;
using BLL=DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using VehicleTransportClient;
namespace VehicleTransportClient.UI
{
    
    public partial class FrmGIS : Form
    {
        //GISManage _map;
        //int LoadCount = 0;
        private string _tableNameCar = "FrmGisCar";
        private string _tableNameEquipment = "FrmGisEquipment";
        private FormMain _mainform;
        public static bool _isfullScreen = false;
        private BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        private BLL.m_Address bllbs = new BLL.m_Address();
        private BLL.v_Address bllvbs = new BLL.v_Address();
        private BLL.m_WifiBaseStation bllwifi = new BLL.m_WifiBaseStation();
        private BLL.m_PDA bllpda = new BLL.m_PDA();
        private BLL.m_User blluser = new BLL.m_User();
        private BLL.m_Area bllarea = new BLL.m_Area();
        private BLL.data_VehicleAlarm bllalarm = new BLL.data_VehicleAlarm();
        private Dictionary<string, int> dictionary = new Dictionary<string, int>(); 
        public FrmGIS(Form main)
        {
            InitializeComponent();
            this.Resize += new EventHandler(FrmGIS_Resize);
            this.Load += new EventHandler(FrmGIS_Load);
            _mainform = (FormMain)main;
            if (Pub.ListFunRight.Contains("GisMapEdit")==false)
            {
                tsImportMap.Visible = false;
                btnOut.Visible = false;
                btnSave.Visible = false;
                btnMove.Visible = false;
            }
            //dgvCar.MouseClick += new MouseEventHandler(dgvCar_MouseClick);
            //dgvCar.CellClick += new DataGridViewCellEventHandler(dgvCar_CellClick);
            //dgvEquipmentAlarm.MouseClick += new MouseEventHandler(dgvEquipmentAlarm_MouseClick);
            //Pub.StyleManager.SetGridStyle(_tableNameCar, this.dgvCar);
            //Pub.StyleManager.SetGridStyle(_tableNameEquipment, this.dgvEquipmentAlarm);
           
        }

    


        private bool isaa = false;
        void Current_CameraServerStateChanged(bool isConnected, bool isLogin)
        {
            if (isConnected==false)
            {
                isaa = false;
            }
            if (isLogin && isaa==false)  //重连后打开视频
            {
                isaa = true;


            }

        }

       

        void FrmGIS_Load(object sender, EventArgs e)
        {
            Pub.GisManage.InitMap(panelGis);
            Pub.GisManage.OnStationClick += new GISManage.StationClickedEventHandler(GisManage_OnStationClick);
            Pub.GisManage.UpdataGisAndDBRemark();
            GetCarState();
            LoadGrid();
            InitCbo();
            timer1.Enabled = true;


        }

        void GisManage_OnStationClick(object sender, GISManage.StationEventArgs e)
        {
            if (e.LayerName == EnumLayerName.定位基站)
            {
                Model.m_Address entity = bllbs.GetModel(e.ID);
                if (entity == null)
                    return;
                List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID=" + entity.LocalizerStationID + " and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID=" + entity.LocalizerStationID + " and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                if (listnormarlcar.Count == 0 && listusecar.Count == 0 )
                {
                    MessageBoxEx.Show("没有相关信息");
                    return;
                }
                else
                {
                    FrmGISDetail frmdetail = new FrmGISDetail(e.ID);
                    frmdetail.ShowDialog();
                }
            }
            else if (e.LayerName == EnumLayerName.wifi基站)
            {
                List<Model.m_User> listuser = blluser.GetModelList("i_state=1 and i_IsPDA=" + (int)Common.Enum.EnumUserType.PDA + " and WifiBaseStationID=" + e.ID + " and i_flag=0");
                if (listuser == null || listuser.Count == 0)
                {
                    MessageBoxEx.Show("没有相关信息");
                    return;
                }
                else
                {
                    FrmGISPda frmpda = new FrmGISPda(e.ID);
                    frmpda.ShowDialog();
                }
            }
            else if (e.LayerName == EnumLayerName.区域层)
            {
                List<Model.m_Address> listaddress = bllbs.GetModelList("i_Flag=0 and AreaID=" + e.ID);
                string localids = "";
                for (int i = 0; i < listaddress.Count; i++)
                {
                    localids = localids + "," + listaddress[i].LocalizerStationID;
                }
                if (string.IsNullOrEmpty(localids))
                {
                    MessageBoxEx.Show("没有相关信息");
                    return;
                }
                localids = localids.Remove(0, 1);
                List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                if (listnormarlcar.Count == 0 && listusecar.Count == 0)
                {
                    MessageBoxEx.Show("没有相关信息");
                    return;
                }
                else
                {
                    FrmGISArea frmaread = new FrmGISArea(localids);
                    frmaread.ShowDialog();
                }
            }
            else
            {
                MessageBoxEx.Show("没有相关信息");
                return;
            }
          
        }
        private void GetCarState()
        {
            labup1.Text = bllcar.GetUpCarempty().ToString();
            labup2.Text = bllcar.GetUpCarHeight().ToString();
            labdown1.Text = bllcar.GetDownCarempty().ToString();
            labdown2.Text = bllcar.GetDownCarHeight().ToString();
            //List<Model.m_Vehicle> listcar = bllcar.GetModelList("i_Flag=0 and i_State=" + (int)Common.Enum.EnumVehicleState.Normal);
            //if (listcar == null)
            //{
            //    labcar.Text = "空车：0";
            //}
            //else
            //    labcar.Text = "空车:" + listcar.Count.ToString();
            //listcar = bllcar.GetModelList("i_Flag=0 and i_State=" + (int)Common.Enum.EnumVehicleState.Using);
            //if (listcar == null)
            //{
            //    labcar2.Text = "重车：0";
            //}
            //else
                //labcar2.Text = "重车:" + listcar.Count.ToString();
        }
        private void InitGIS()
        {

        }

        void GisManage_PointClicked(object sender, GroupEventArgs e)
        {
            throw new NotImplementedException();
        }

        void GisManage_Moved(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            LoadGrid();
            InitCbo();
            Pub.GisManage.ReloadMap();
        }
      



    
        void dgvCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    DB_ScramVoiceAlarm.Model.m_Car item = (DB_ScramVoiceAlarm.Model.m_Car)dgvCar.Rows[e.RowIndex].Tag;
            //    DB_ScramVoiceAlarm.Model.m_Car CurItem = new DB_ScramVoiceAlarm.BLL.m_Car().GetModel("i_flag=0 and ID='"+item.ID+"'");
            //    //打开视频
            //    OpenVideo(CurItem);
            //    FrmCarInfo fi = new FrmCarInfo();
            //    if (fi.LoadData(item.ID) > 0)
            //    {
            //        fi.ShowDialog();
            //    }
            //    else
            //    {
            //        MessageBoxEx.Show("当前车辆没有挂车厢！", "提示");
            //    }
            //    dgvCar.ClearSelection();
            //}
        }

        void dgvEquipmentAlarm_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameEquipment, Pub.StyleManager);
            //    gFrom.ShowDialog();

            //    Pub.StyleManager.SetGridStyle(_tableNameEquipment, this.dgvEquipmentAlarm);
            //}
        }
 
        void dgvCar_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button== System.Windows.Forms.MouseButtons.Right)
            //{
            //    Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameCar, Pub.StyleManager);
            //    gFrom.ShowDialog();

            //    Pub.StyleManager.SetGridStyle(_tableNameCar, this.dgvCar);
            //}
        }

        void cboValue_SelectedValueChanged(object sender, EventArgs e)
        {
         
          
           
        }

        /// <summary>
        /// 初始化标识卡
        /// </summary>
        private void InitCbo()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                             {
                                 InitCbo();
                             }));
            }
            else
            {
                List<Model.m_Vehicle> lstcar = bllcar.GetModelList("i_flag=0");

                lstcar.Insert(0, new Model.m_Vehicle()
                {
                    ID = -1,
                    vc_Code=""
                });
                cmbCar.DataSource = lstcar;
                cmbCar.DisplayMember = "vc_Code";
                cmbCar.ValueMember = "ID";
                cmbCar.SelectedIndex = 0;

                List<Model.m_Address> lstaddress = bllbs.GetModelList("i_flag=0");
                lstaddress.Insert(0, new Model.m_Address()
                {
                   LocalizerStationID=-1,
                   vc_Name=""
                });
                cmbBS.DataSource = lstaddress;
                cmbBS.DisplayMember = "vc_Name";
                cmbBS.ValueMember = "LocalizerStationID";
                cmbBS.SelectedIndex = 0;

            }
            
        }

   
    
        /// <summary>
        /// 其他告警事件
        /// </summary>
        /// <param name="model"></param>
        public void OnDeviceAlarm()
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            //   {
            //       LoadEquipmentAlarm();
            //   }));
            //}
            //else
            //{
            //    LoadEquipmentAlarm();
            //}
        }

      

        void FrmGIS_Resize(object sender, EventArgs e)
        {
            //if (Pub.GisManage != null)
            //{
            //    Pub.GisManage.DrawFull();
            //}
        }

       


        /// <summary>加载车的状态</summary>
        public void LoadCarState()
        {
            //try
            //{
            //    if (this.InvokeRequired)
            //    {
            //        this.Invoke(new EventHandler(delegate(object o, EventArgs ee) { LoadCarState(); }));
            //    }
            //    else
            //    {
            //        dgvCar.Rows.Clear();
            //        List<DB_ScramVoiceAlarm.Model.m_Car> lst = new DB_ScramVoiceAlarm.BLL.m_Car().GetModelList("i_Flag=0");

            //        foreach (DB_ScramVoiceAlarm.Model.m_Car item in lst)
            //        {
            //            int i = dgvCar.Rows.Add(item.vc_name, item.vc_remark);
            //            //if (i == 0) OpenVideo(item); //默认打开第一个视频
            //            dgvCar.Rows[i].Tag = item;
            //            List<DB_ScramVoiceAlarm.Model.Data_CarCurAlarminfo> lstAlarm = new DB_ScramVoiceAlarm.BLL.Data_CarCurAlarminfo().GetModelList("i_Carid=" + item.ID);
            //            if (lstAlarm != null && lstAlarm.Count > 0)
            //            {
            //                dgvCar.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //                dgvCar.Rows[i].Cells[1].Value = "告警";
            //                Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarAlarm, false);
            //            }
            //            else
            //            {
            //                Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, item.ID, EnumStyleIndex.CarNormal, false);
            //                dgvCar.Rows[i].Cells[1].Value = "正常";
            //            }
            //        }
            //        dgvCar.ClearSelection();
            //        Pub.GisManage.MapSave();
            //    }
            //}
            //catch(Exception e)
            //{
            //    WriteLog.AppendErrorLog("加载车告警错误" + e.StackTrace.ToString());
            //}
        }

        /// <summary>定位车的坐标</summary>
        public void LoadCarPostion()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object o, EventArgs ee) { LoadCarPostion(); }));
            }
            else
            {
                List<Model.m_Vehicle> lst = bllcar.GetModelList("1=1");
                foreach (Model.m_Vehicle item in lst)
                {
                    Pub.GisManage.ShowCarRealPostion(item.ID,item.i_LocalizerStationID);
                }
                Pub.GisManage.MapSave();
            }
        }


        /// <summary>
        /// 退出全屏
        /// </summary>
        public void ExitFullScreen()
        {
            btnExitFullScreen_Click(null, null);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            //Pub.GisManage.PointSelect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            
          
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            Pub.GisManage.ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            Pub.GisManage.ZoomOut();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            Pub.GisManage.DrawFull();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            Pub.GisManage.FeatureMove();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Pub.GisManage.Move();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Pub.GisManage.MapSave();
            Pub.GisManage.MapFileSaveToDB();
            if (Pub.BackServer.SendGISChange() == false)
            {
                MessageBoxEx.Show("未能成功通知其他客户端");
            }
            else
            {
                MessageBoxEx.Show("保存成功");
            }

        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            Pub.GisManage.GISOut();
        }
        /// <summary>
        /// 显示隐藏标识卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHideCard_Click(object sender, EventArgs e)
        {
            
        }
      
        /// <summary>
        /// 全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (_mainform != null && _isfullScreen == false)
            {
                _isfullScreen = true;
                btnFullScreen.Visible = false;
                btnExitFullScreen.Visible = true;
                _mainform.ShowGis(this);


            }
        }

        private void btnExitFullScreen_Click(object sender, EventArgs e)
        {
            if (_mainform != null && _isfullScreen == true)
            {
                _isfullScreen = false;

                btnExitFullScreen.Visible = false;

                btnFullScreen.Visible = true;
                _mainform.CloseGis(this);
            }
        }

        private void tsImportMap_Click(object sender, EventArgs e)
        {
            Pub.GisManage.ImportMap();
        }
        
        public void LoadGridAlarm()
        {
            dgvbs.Rows.Clear();
            dgarea.Rows.Clear();
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object o, EventArgs ee) { LoadGrid(); }));
            }
            else
            {
                List<Model.m_Vehicle> lstcar = bllcar.GetModelList("i_flag=0 and i_state in (0,1)");
                if (dgvList.Rows.Count != lstcar.Count)
                {
                    dgvList.Rows.Clear();
                }
                foreach (Model.m_Vehicle item in lstcar)
                {
                    string bsname = "";
                    List<Model.m_Address> lstbs = bllbs.GetModelList("LocalizerStationID=" + item.i_LocalizerStationID);
                    if (lstbs != null && lstbs.Count > 0)
                    {
                        lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.m_Address>();
                        bsname = lstbs[0].vc_Name;
                    }
                    string statename = "空车";
                    if (item.i_State == (int)Common.Enum.EnumVehicleState.Using)
                    {
                        statename = "重车";
                    }
                    int i = 0;
                    if (dictionary.ContainsKey(item.vc_Code))
                    {
                        if (dgvList.Rows[dictionary[item.vc_Code]].Cells[0].ToString() !=
                            item.vc_Code)
                        {
                            dgvList.Rows[dictionary[item.vc_Code]].Cells[0].Value = item.vc_Code;
                        }
                        if (dgvList.Rows[dictionary[item.vc_Code]].Cells[1].ToString() !=
                                 statename)
                        {
                            dgvList.Rows[dictionary[item.vc_Code]].Cells[1].Value = statename;
                        }

                        if (dgvList.Rows[dictionary[item.vc_Code]].Cells[2].ToString() !=
                               bsname)
                        {
                            dgvList.Rows[dictionary[item.vc_Code]].Cells[2].Value = bsname;
                        }
                        // dictionary.Remove(item.vc_Code);
                    }
                    else
                    {
                        i = dgvList.Rows.Add(item.vc_Code, statename, bsname);
                        dictionary.Add(item.vc_Code, i);
                    }

                    List<Model.data_VehicleAlarm> listalarm = bllalarm.GetModelList("VehicleID=" + item.ID + " and dt_End is null  and i_flag=0");
                    if (listalarm != null && listalarm.Count > 0)
                    {
                        dgvList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        dgvList.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                    dgvList.Update();
                    dgvList.Rows[i].Tag = item;
                }
                List<Model.m_Vehicle> lstcar1 = lstcar.Where(p => p.i_State == 0).ToList<Model.m_Vehicle>();
                List<Model.m_Vehicle> lstcar2 = lstcar.Where(p => p.i_State == 1).ToList<Model.m_Vehicle>();
                labempty.Text = "空车:" + lstcar1.Count.ToString();
                labheight.Text = "重车:" + lstcar2.Count.ToString();
                DataTable dt = bllcar.GetLocalinfo();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bsname = "";
                    string code = "";
                    List<Model.v_Address> lstbs = bllvbs.GetModelList("LocalizerStationID=" + dt.Rows[i][0].ToString());
                    if (lstbs != null && lstbs.Count > 0)
                    {
                        lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.v_Address>();
                        bsname = lstbs[0].vc_Name;
                        code = lstbs[0].vc_Code;
                    }
                    int j = dgvbs.Rows.Add(code, bsname, dt.Rows[i][1].ToString());
                    dgvbs.Rows[j].Tag = lstbs[0].ID;
                }
                List<Model.m_Area> listarea = bllarea.GetModelList("i_Flag=0");
                foreach (Model.m_Area entity in listarea)
                {
                    List<Model.m_Address> listaddress = bllbs.GetModelList("i_Flag=0 and AreaID=" + entity.ID);
                    string localids = "";
                    for (int i = 0; i < listaddress.Count; i++)
                    {
                        localids = localids + "," + listaddress[i].LocalizerStationID;
                    }
                    if (string.IsNullOrEmpty(localids))
                    {
                        int i = dgarea.Rows.Add(entity.vc_Name, 0, 0);
                        dgarea.Rows[i].Tag = entity;
                        continue;
                    }
                    localids = localids.Remove(0, 1);
                    List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                    List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                    int empty = listnormarlcar == null ? 0 : listnormarlcar.Count;
                    int height = listusecar == null ? 0 : listusecar.Count;
                    int j = dgarea.Rows.Add(entity.vc_Name, empty, height);
                    dgarea.Rows[j].Tag = entity;
                }
            }
            dgvList.ClearSelection();
        }
        public void LoadGrid()
        {
            
            dgvList.Rows.Clear();
            dgvbs.Rows.Clear();
            dgarea.Rows.Clear();
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object o, EventArgs ee) { LoadGrid(); }));
            }
            else
            {
                List<Model.m_Vehicle> lstcar = bllcar.GetModelList("i_flag=0 and i_state in (0,1)");
                foreach (Model.m_Vehicle item in lstcar)
                {
                    string bsname = "";
                    List<Model.m_Address> lstbs = bllbs.GetModelList("LocalizerStationID=" + item.i_LocalizerStationID);
                    if (lstbs != null && lstbs.Count > 0)
                    {
                        lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.m_Address>();
                        bsname = lstbs[0].vc_Name;
                    }
                    string statename = "空车";
                    if (item.i_State == (int)Common.Enum.EnumVehicleState.Using)
                    {
                        statename = "重车";
                    }
                    int i = dgvList.Rows.Add(item.vc_Code,statename,bsname);
                    List<Model.data_VehicleAlarm> listalarm = bllalarm.GetModelList("VehicleID=" + item.ID + " and dt_End is null  and i_flag=0");
                    if (listalarm!=null && listalarm.Count>0)
                    {
                        dgvList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        dgvList.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                    }
                
                    dgvList.Rows[i].Tag = item;
                }
                List<Model.m_Vehicle> lstcar1 = lstcar.Where(p => p.i_State == 0).ToList<Model.m_Vehicle>();
                List<Model.m_Vehicle> lstcar2 = lstcar.Where(p => p.i_State == 1).ToList<Model.m_Vehicle>();
                labempty.Text = "空车:" + lstcar1.Count.ToString();
                labheight.Text = "重车:" + lstcar2.Count.ToString();
                DataTable dt = bllcar.GetLocalinfo();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string bsname = "";
                    string code = "";
                    List<Model.v_Address> lstbs = bllvbs.GetModelList("LocalizerStationID=" +dt.Rows[i][0].ToString());
                    if (lstbs != null && lstbs.Count > 0)
                    {
                        lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.v_Address>();
                        bsname = lstbs[0].vc_Name;
                        code = lstbs[0].vc_Code;
                    }
                    int j=dgvbs.Rows.Add(code,bsname, dt.Rows[i][1].ToString());
                    dgvbs.Rows[j].Tag = lstbs[0].ID;
                }
                List<Model.m_Area> listarea = bllarea.GetModelList("i_Flag=0");
                foreach (Model.m_Area entity in listarea)
                {
                    List<Model.m_Address> listaddress = bllbs.GetModelList("i_Flag=0 and AreaID=" + entity.ID);
                    string localids = "";
                    for (int i = 0; i < listaddress.Count; i++)
                    {
                        localids = localids + "," + listaddress[i].LocalizerStationID;
                    }
                    if (string.IsNullOrEmpty(localids))
                    {
                       int i=dgarea.Rows.Add(entity.vc_Name,0,0);
                       dgarea.Rows[i].Tag = entity;
                       continue;
                    }
                    localids = localids.Remove(0, 1);
                    List<Model.m_Vehicle> listnormarlcar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Normal + " and i_Flag=0");
                    List<Model.m_Vehicle> listusecar = bllcar.GetModelList("i_LocalizerStationID in (" + localids + ") and i_State=" + (int)Common.Enum.EnumVehicleState.Using + " and i_Flag=0");
                    int empty = listnormarlcar == null ? 0 : listnormarlcar.Count;
                    int height = listusecar == null ? 0 : listusecar.Count;
                    int j=dgarea.Rows.Add(entity.vc_Name, empty, height);
                    dgarea.Rows[j].Tag = entity;
                }
            }
            dgvList.ClearSelection();
        }

        private void cmbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
            Model.m_Vehicle car = (Model.m_Vehicle)cmbCar.SelectedItem;
            List<Model.m_Vehicle> lstcar = bllcar.GetModelList("i_flag=0 and ID=" + car.ID);
            if (car.ID == -1)
            {
                lstcar = bllcar.GetModelList("i_flag=0 and i_state in (0,1)");
            }
            
            foreach (Model.m_Vehicle item in lstcar)
            {
                string bsname = "";
                List<Model.m_Address> lstbs = bllbs.GetModelList("LocalizerStationID=" + item.i_LocalizerStationID);
                if (lstbs != null && lstbs.Count > 0)
                {
                    lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.m_Address>();
                    bsname = lstbs[0].vc_Name;
                }
                string statename = "空车";
                if (item.i_State == (int)Common.Enum.EnumVehicleState.Using)
                {
                    statename = "重车";
                }
                int i = dgvList.Rows.Add(item.vc_Code, statename, bsname);
                dgvList.Rows[i].Tag = item;
                List<Model.data_VehicleAlarm> listalarm = bllalarm.GetModelList("VehicleID=" + item.ID + " and dt_End is null and i_flag=0");
                if (listalarm != null && listalarm.Count > 0)
                {
                    dgvList.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    dgvList.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
            }
            dgvList.ClearSelection();
        }

        private void cmbBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvbs.Rows.Clear();
            DataTable dt = bllcar.GetLocalinfo();
            DataView dv = dt.DefaultView;
            Model.m_Address addressentity = (Model.m_Address)cmbBS.SelectedItem;
            if (addressentity.LocalizerStationID != -1)
            {
                dv.RowFilter = "LocalizerStationID=" + addressentity.LocalizerStationID;
            }
            for (int i = 0; i < dv.Count; i++)
            {
                string bsname = "";
                string code = "";
                List<Model.v_Address> lstbs = bllvbs.GetModelList("LocalizerStationID=" + dv.ToTable().Rows[i][0].ToString());
                if (lstbs != null && lstbs.Count > 0)
                {
                  
                    lstbs = (from entity in lstbs orderby entity.ID descending select entity).ToList<Model.v_Address>();
                    bsname = lstbs[0].vc_Name;
                    code = lstbs[0].vc_Code;
                }
                int j = dgvbs.Rows.Add(code,bsname, dv.ToTable().Rows[i][1].ToString());

                dgvbs.Rows[j].Tag = lstbs[0].ID;
            }
        }
        /// <summary>
        /// 设备状态发生变化处理
        /// </summary>
        /// <param name="equiptype"></param>
        /// <param name="id"></param>
        public void ChangeEquipState(Common.Enum.EnumEquipmentType equiptype, int id)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o, EventArgs ee) { ChangeEquipState(equiptype, id); }));
                }
                else
                {
                    if (equiptype == Common.Enum.EnumEquipmentType.Wifi_BaseStation)
                    {
                        Model.m_WifiBaseStation wifientity = bllwifi.GetModel(id);
                        if (wifientity.i_State == (int)Common.Enum.EnumWifiStationStateType.OffLine)
                        {
                            Pub.GisManage.UpdateFeatureState(EnumLayerName.wifi基站, id, EnumStyleIndex.WifiStationOffLine, false);
                        }
                        else
                        {
                            Pub.GisManage.UpdateFeatureState(EnumLayerName.wifi基站, id, EnumStyleIndex.WifiStationNormal, false);
                        }
                    }
                    else if (equiptype == Common.Enum.EnumEquipmentType.DW_BaseStation)
                    {
                        Model.m_Address addressentity = bllbs.GetModel(id);
                        if (addressentity.i_State == 1)
                        {
                            Pub.GisManage.UpdateFeatureState(EnumLayerName.定位基站, id, EnumStyleIndex.DWBaseStationNormal, false);
                        }
                        else
                        {
                            Pub.GisManage.UpdateFeatureState(EnumLayerName.定位基站, id, EnumStyleIndex.DWBaseStationOffLine, false);
                        }
                    }
                    //else if (equiptype == Common.Enum.EnumEquipmentType.PDA)
                    //{
                    //    Model.m_PDA entity = bllpda.GetModel(id);
                    //    if (entity.i_State == (int)Common.Enum.EnumPDAState.OffLine)
                    //    {
                    //        Pub.GisManage.UpdateFeatureState(EnumLayerName.手机, id, EnumStyleIndex.PDAOffLine, false);
                    //    }
                    //    else
                    //    {
                    //        Pub.GisManage.UpdateFeatureState(EnumLayerName.手机, id, EnumStyleIndex.PdaNormal, false);
                    //    }
                    //}
                    //else if (equiptype == Common.Enum.EnumEquipmentType.Vehicle)
                    //{
                    //    Model.m_Vehicle entity = bllcar.GetModel(id);
                    //    if (entity.i_State == (int)Common.Enum.EnumVehicleState.Normal)
                    //    {
                    //        Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, id, EnumStyleIndex.CarNormal, false);
                    //    }
                    //    else if (entity.i_State == (int)Common.Enum.EnumVehicleState.Using)
                    //    {
                    //        Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, id, EnumStyleIndex.CarUse, false);
                    //    }
                    //    GetCarState();
                    //}
                }
            }
            catch
            { 
            }
        }
        public void LocalCarPosition(int carid, int localid)
        {
          

                
        }
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _selectIndex = e.RowIndex;
           
            if (_selectIndex > -1)
            {
                Model.m_Vehicle entity = (Model.m_Vehicle)dgvList.Rows[_selectIndex].Tag;
                bool isexist = Pub.GisManage.SelectCarFeature(entity.ID);
                if (isexist == false)
                {
                    MessageBoxEx.Show("该车辆目前无法定位");
                }

            }
            

        }

        private void dgvbs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _selectIndex = e.RowIndex;
            if (_selectIndex > -1)
            {
                int id = (int)dgvbs.Rows[_selectIndex].Tag;
                bool isexist = Pub.GisManage.SelectDWFeature(id);
                if (isexist == false)
                {
                    MessageBoxEx.Show("该基站目前无法定位");
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Pub.IsDBOnline == true)
            {
                GetCarState();
            }
        }



        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            //
        }

        private void labup1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (labup1.Text == "0")
            {
                MessageBoxEx.Show("没有记录");
                return;
            }
            FrmGISCar frmcar = new FrmGISCar(true,true);
            frmcar.ShowDialog();
        }

        private void labup2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (labup2.Text == "0")
            {
                MessageBoxEx.Show("没有记录");
                return;
            }
            FrmGISCar frmcar = new FrmGISCar(false, true);
            frmcar.ShowDialog();
        }

        private void labdown1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (labdown1.Text == "0")
            {
                MessageBoxEx.Show("没有记录");
                return;
            }
            FrmGISCar frmcar = new FrmGISCar(true, false);
            frmcar.ShowDialog();
        }

        private void labdown2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (labdown2.Text == "0")
            {
                MessageBoxEx.Show("没有记录");
                return;
            }
            FrmGISCar frmcar = new FrmGISCar(false, false);
            frmcar.ShowDialog();
        }

        private void dgarea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int _selectIndex = e.RowIndex;

            if (_selectIndex > -1)
            {
                Model.m_Area entity = (Model.m_Area)dgarea.Rows[_selectIndex].Tag;
                bool isexist = Pub.GisManage.SelectAreaFeature(entity.ID);
                if (isexist == false)
                {
                    MessageBoxEx.Show("该区域目前无法定位");
                }

            }
            
            
        }

      

      

    



       



    }
}