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
namespace VehicleTransportClient.UI
{
    public partial class FrmGISCar : Common.frmBase
    {
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        BLL.m_VehicleType blltype = new BLL.m_VehicleType();
        bool _isEmpty = false;
        bool _isUp = false;
        public FrmGISCar(bool isEmpty,bool isUp)
        {
            InitializeComponent();
            _isEmpty = isEmpty;
            _isUp = isUp;
         
        }
        private void InitGrid()
        {
            DataTable dt = bllcar.GetCarTypeinfo(_isEmpty, _isUp);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string name = "";
                Model.m_VehicleType typentity= blltype.GetModel(int.Parse(dt.Rows[i][0].ToString()));
                if (typentity!=null && typentity.vc_Name!=null)
                    name=typentity.vc_Name;
                dgvList.Rows.Add(dgvList.Rows.Count + 1,name, dt.Rows[i][1].ToString());
            }
         
        }

        private void FrmGISCar_Load(object sender, EventArgs e)
        {
            InitGrid();
        }
    }
}
