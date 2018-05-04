using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common.Enum;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using System.Net;
using Common.MessageBoxEx;
namespace VehicleTransportClient
{
    public partial class FormWifiBaseStationEdit : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_WifiBaseStation _model = new DB_VehicleTransportManage.Model.m_WifiBaseStation();
        private BLL.m_WifiBaseStation bll = new BLL.m_WifiBaseStation();
        public FormWifiBaseStationEdit(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_WifiBaseStation model)
        {
            InitializeComponent();
            _type = type;
            LoadRY();
            switch (type)
            {
                case OperateTypeEnum.Add:
                    this.FormTitle = "增加";
                    btnOK.Text = "添加";
                    break;
                case OperateTypeEnum.Edit:
                    this.FormTitle = "修改";
                    this._model = model;
                    btnOK.Text = "修改";
                    txtName.Text = model.vc_Name;
                    txtIP.Value = model.vc_IPAddress;
                    txtMac.Text = model.vc_MacAddress;
                    txtMemo.Text = model.vc_Memo;
                    if (model.LocalizerStationID!=null)
                    cmbBS.SelectedValue = model.LocalizerStationID;
                    break;
                default:
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strReg = "[0-9a-fA-FA-F]{2}[0-9a-fA-FA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}";
            Regex r = new Regex(strReg); //定义一个Regex对象实例
            if (_type == OperateTypeEnum.Add)
            {
                Model.m_WifiBaseStation wifientity = new Model.m_WifiBaseStation();
                IPAddress tmpip;
               
                if (txtIP.Value==null||IPAddress.TryParse(txtIP.Value, out tmpip) == false)
                {
                    MessageBoxEx.Show("请输入有效的IP地址");
                    return;
                }
               
                MatchCollection mc = r.Matches(txtMac.Text.Trim());
                if (mc.Count > 0)
                    wifientity.vc_MacAddress = mc[0].Value.ToUpper();
                else
                {
                    MessageBoxEx.Show("请输入有效的Mac地址，例如：8C7B9D435089");
                    return;
                }
               
                if (cmbBS.SelectedValue!=null)
                wifientity.LocalizerStationID = (int)cmbBS.SelectedValue;
                wifientity.vc_IPAddress = txtIP.Value;
                
                wifientity.vc_Name = txtName.Text;
                wifientity.vc_Memo = txtMemo.Text;
                //2014-12-15 新增wifi基站,默认在线
                wifientity.i_State = 1;
                if (wifientity.vc_Name.Length == 0)
                {
                    txtName.Focus();
                    MessageBoxEx.Show("请输入基站名称！");
                    return;
                }
                if (wifientity.vc_Name.IndexOf("'") >= 0)
                {
                    txtName.Focus();
                    MessageBoxEx.Show("基站名称中不可以有特殊字符！");
                    return;
                }
                if (wifientity.vc_Memo.IndexOf("'") >= 0)
                {
                    txtMemo.Focus();
                    MessageBoxEx.Show("备注中不可以有特殊字符！");
                    return;
                }
                if (bll.GetModelList(" i_flag=0 and vc_Name='" + wifientity.vc_Name + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("WIFI基站名称 【" + wifientity.vc_Name + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (bll.GetModelList(" i_flag=0 and vc_MacAddress='" + wifientity.vc_MacAddress + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("MAC地址 【" + wifientity.vc_MacAddress + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if (bll.GetModelList(" i_flag=0 and vc_IPAddress='" + wifientity.vc_IPAddress + "'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("IP地址 【" + wifientity.vc_IPAddress + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                wifientity.ID=bll.Add(wifientity);
                if (wifientity.ID > 0)
                {
                    Pub.GisManage.AddFeature(EnumLayerName.wifi基站, wifientity, true);
                    Pub.GisManage.UpdataGisAndDBRemark();
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "WIFI基站", wifientity.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                Model.m_WifiBaseStation wifientity = new Model.m_WifiBaseStation();
                
                IPAddress tmpip;
                if (txtIP.Value==null||IPAddress.TryParse(txtIP.Value, out tmpip) == false)
                {
                    MessageBoxEx.Show("请输入有效的IP地址");
                    return;
                }
                MatchCollection mc = r.Matches(txtMac.Text.Trim());
                if (mc.Count > 0 && txtMac.Text.Trim().Length == 12)
                    wifientity.vc_MacAddress = mc[0].Value.ToUpper();
                else
                {
                    MessageBoxEx.Show("请输入指定格式的MAC地址，例如：8C7B9D435089");
                    return;
                }
               
               
                if(cmbBS.SelectedValue!=null)
                wifientity.LocalizerStationID = (int)cmbBS.SelectedValue;
                wifientity.vc_IPAddress = txtIP.Value;
                wifientity.vc_MacAddress = txtMac.Text.ToUpper();
                wifientity.vc_Name = txtName.Text;
                wifientity.vc_Memo = txtMemo.Text;
                wifientity.ID = _model.ID;
                if (wifientity.vc_Name.Length == 0)
                {
                    txtName.Focus();
                    MessageBoxEx.Show("请输入基站名称！");
                    return;
                }
                if (wifientity.vc_Name.IndexOf("'") >= 0)
                {
                    txtName.Focus();
                    MessageBoxEx.Show("基站名称中不可以有特殊字符！");
                    return;
                }
                if (wifientity.vc_Memo.IndexOf("'") >= 0)
                {
                    txtMemo.Focus();
                    MessageBoxEx.Show("备注中不可以有特殊字符！");
                    return;
                }
                List<DB_VehicleTransportManage.Model.m_WifiBaseStation> lstUser = bll.GetModelList(" i_flag=0 and  vc_Name ='" + wifientity.vc_Name +
                                                                          "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != wifientity.ID)
                    {
                        MessageBoxEx.Show("WIFI基站名称【" + wifientity.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                 lstUser = bll.GetModelList(" i_flag=0 and  vc_MacAddress ='" + wifientity.vc_MacAddress +
                                                                           "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != wifientity.ID)
                    {
                        MessageBoxEx.Show("MAC地址【" + wifientity.vc_MacAddress + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                lstUser = bll.GetModelList(" i_flag=0 and  vc_IPAddress ='" + wifientity.vc_IPAddress +
                                                                           "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != wifientity.ID)
                    {
                        MessageBoxEx.Show("IP地址【" + wifientity.vc_IPAddress + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
               
               
                if (bll.Update(wifientity))
                {
                    Pub.GisManage.ModifyFeature(EnumLayerName.wifi基站, wifientity, true);
                    Pub.GisManage.UpdataGisAndDBRemark();
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "WIFI编辑成功", wifientity.vc_Name);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
        private void LoadRY()
        {
            BLL.m_Address localbll = new BLL.m_Address();
           
            List<Model.m_Address> localentity = localbll.GetModelList("i_Flag=0");
            Model.m_Address modeltemp = new Model.m_Address();
            modeltemp.ID = 0;
            modeltemp.vc_Name = "==请选择定位基站==";
            localentity.Insert(0, modeltemp);
            cmbBS.ValueMember = "LocalizerStationID";
            cmbBS.DisplayMember = "vc_name";
            cmbBS.DataSource = localentity;
            
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
