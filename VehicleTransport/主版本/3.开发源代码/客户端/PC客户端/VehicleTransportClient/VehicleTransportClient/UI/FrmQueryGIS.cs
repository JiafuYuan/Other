using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using System.Collections;
namespace VehicleTransportClient.UI
{
    public partial class FrmQueryGIS : Common.frmBase
    {
        int _planid = 0;
        public FrmQueryGIS(int planid)
        {
            InitializeComponent();
            _planid = planid;
        }
        public GISManage _map;
        private BLL.m_VehiclePlanDetail bllplandetail = new BLL.m_VehiclePlanDetail();
        private BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        private BLL.v_Address blladdress = new BLL.v_Address();
        private void FrmQueryGIS_Load(object sender, EventArgs e)
        {
            try
            {
                _map = new GISManage();
                _map.InitMap(panelGis);
                _map.UpdataGisAndDBRemark();
                _map.ShowRemark(false);
                List<int> liststation = new List<int>();

                Dictionary<int, string> listCar = new Dictionary<int, string>();
                List<Model.m_VehiclePlanDetail> listplan = bllplandetail.GetModelList("planid=" + _planid);
                for (int i = 0; i < listplan.Count; i++)
                {
                    Model.m_Vehicle entity = bllcar.GetModel(listplan[i].VehicleID.Value);
                    string addressname = "";
                    string code = "";
                    if (entity != null)
                    {
                        List<Model.v_Address> listaddress = blladdress.GetModelList("i_flag=0 and LocalizerStationID=" + entity.i_LocalizerStationID);
                        if (listaddress != null && listaddress.Count > 0)
                        {
                            addressname = listaddress[0].vc_Name;
                            code = listaddress[0].vc_Code;
                        }
                    }
                    if (liststation.Contains(entity.i_LocalizerStationID) == false)
                    {
                        liststation.Add(entity.i_LocalizerStationID);
                        if (!string.IsNullOrEmpty(addressname))
                        {
                            listCar.Add(entity.i_LocalizerStationID, code + "(车辆:" + entity.vc_Code + ")");
                        }
                        else
                        {
                            listCar.Add(entity.i_LocalizerStationID, "车辆:" + entity.vc_Code);
                        }
                    }
                    else
                    {
                        listCar[entity.i_LocalizerStationID] = listCar[entity.i_LocalizerStationID].Remove(listCar[entity.i_LocalizerStationID].Length - 1) + "," + entity.vc_Code + ")";
                    }
                }
                if (listCar.ContainsKey(0) && listCar.Count == 1)
                {
                    this.DialogResult = DialogResult.Ignore;
                }
                else if (listCar.Count == 0)
                {
                    this.DialogResult = DialogResult.Ignore;
                }

                else
                {
                    _map.ShowPlanCar(listCar);
                  
                    
                }

            }
            catch(Exception exc)
            {
                string aa = exc.ToString();
            }

        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            _map.ZoomOut();

        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            _map.ZoomIn();
        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            _map.Move();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            _map.DrawFull();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _map.ReloadMap();
        }
    }
}
