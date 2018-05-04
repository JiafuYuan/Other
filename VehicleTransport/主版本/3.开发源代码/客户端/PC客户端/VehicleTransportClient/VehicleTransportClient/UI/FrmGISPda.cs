using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;
namespace VehicleTransportClient.UI
{
    public partial class FrmGISPda : Common.frmBase
    {
        BLL.m_PDA bllpda = new BLL.m_PDA();
        BLL.m_User blluser = new BLL.m_User();
        BLL.m_Person bllperson = new BLL.m_Person();
        int _wifiid = 0;
        public FrmGISPda(int wifiid)
        {
            InitializeComponent();
            _wifiid = wifiid;
        }
        private void InitGrid()
        {
            List<Model.m_User> listuser = blluser.GetModelList("i_state=1 and i_IsPDA=" + (int)Common.Enum.EnumUserType.PDA + " and WifiBaseStationID=" + _wifiid + " and i_flag=0");
            if (listuser != null)
            {
                for (int i = 0; i < listuser.Count; i++)
                {
                    string name = "";
                    Model.m_Person person = bllperson.GetModel(listuser[i].PersonID.Value);
                    if (person != null)
                        name = person.vc_Name;
                    string code = "";
                    if (listuser[i].PdaID != null)
                    {
                        Model.m_PDA pda = bllpda.GetModel(listuser[i].PdaID.Value);
                        if (pda != null)
                            code = pda.vc_Code;
                    }
                    dgvList.Rows.Add(dgvList.Rows.Count + 1, code, name);
                }
            }
        }

        private void FrmGISPda_Load(object sender, EventArgs e)
        {
            InitGrid();
        }
    }
}
