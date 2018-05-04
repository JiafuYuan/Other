using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using DB_VehicleTransportManage;
using DB_VehicleTransportManage.Model;
using VehicleTransportClient.Com;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using BLL=DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{
    public partial class FormVehicleMainTainStop : Common.frmBase
    {
        private DB_VehicleTransportManage.Model.m_VehicleMaintain _model = new DB_VehicleTransportManage.Model.m_VehicleMaintain();
        BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        BLL.m_VehicleMaintain bllVehicleMaintain = new BLL.m_VehicleMaintain();
        BLL.m_User bllUser = new BLL.m_User();
        BLL.data_VehicleAlarm bllDataVehicleAlarm=new BLL.data_VehicleAlarm();

        public FormVehicleMainTainStop(DB_VehicleTransportManage.Model.m_VehicleMaintain model)
        {
            InitializeComponent();

            this.FormTitle = "结束维护";
            this._model = model;
            btnOK.Text = "保存";
            ShowModel();
            dtInputStop.MaxDate = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
            }
            catch (Exception ex)
            {
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (bllVehicleMaintain.Update(_model))
            {
                MessageBoxEx.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                OperationLog.InsertSqlLog(EnumActionType.Update, "车辆维护", bllVehicle.GetVehicleName((int)_model.VehicleID)[1]);

                //更新告警表
                bllVehicle.UpdateVehicleState((int)_model.VehicleID, 0);
                List<DB_VehicleTransportManage.Model.data_VehicleAlarm> listmodel =
                    bllDataVehicleAlarm.GetModelList(String.Format("i_AlarmType=1 and VehicleID={0} and dt_End is null", _model.VehicleID));
                foreach (DB_VehicleTransportManage.Model.data_VehicleAlarm dataVehicleAlarm in listmodel)
                {
                    dataVehicleAlarm.dt_End = DateTime.Parse(_model.dt_EndDateTime);
                    bllDataVehicleAlarm.Update(dataVehicleAlarm);
                }
                //更新车辆表
                DB_VehicleTransportManage.Model.m_Vehicle _vehicleModel =bllVehicle.GetModel((int)_model.VehicleID);
                if (_vehicleModel != null)
                {
                    Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, _vehicleModel.ID, EnumStyleIndex.CarNormal, true);
                    _vehicleModel.dt_LastMaintainDateTIme = DateTime.Parse(_model.dt_EndDateTime);
                    bllVehicle.Update(_vehicleModel);
                }
                Pub.BackServer.OverAlarm();
                Pub.GisManage.UpdataGisAndDBRemark();
                Pub.GISForm.LoadGrid();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {
            if (dtInputStop.Value.Year == 1)
            {
                throw new Exception("请选择结束维护时间！");
            }
            _model.dt_EndDateTime = dtInputStop.Value.ToString("yyyy-MM-dd HH:mm:ss");

            if (_model.dt_EndDateTime != null && _model.dt_EndDateTime.Length != 0 && _model.dt_BeginDateTime > dtInputStop.Value.AddDays(1))
            {
                throw new Exception("结束维护时间应在开始维护时间之后！");
            }


            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }
            _model.RecordPersonID = bllUser.GetPersonID(Pub.UserId);


        }

        private void ShowModel()
        {
            txtMemo.Text = _model.vc_Memo;
        }






    }


}
