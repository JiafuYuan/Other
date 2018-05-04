using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;
using VehicleTransportClient.Tools;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;

namespace VehicleTransportClient
{
    public partial class FormLoadCarDetail : Common.frmBase
    {
        public Model.m_Plan_CheckVehicle _model = new Model.m_Plan_CheckVehicle();
        private BLL.m_Plan_CheckVehicle bllPlanCheckVehicle = new BLL.m_Plan_CheckVehicle();
        BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        BLL.m_MaterielType bllMaterielType = new BLL.m_MaterielType();
        int _PlanID = 0;

        public FormLoadCarDetail(int PlanID)
        {
            InitializeComponent();
            _PlanID = PlanID;
            LoadData();
        }

        public void LoadData()
        {

            List<Model.m_Plan_CheckVehicle> list =
               bllPlanCheckVehicle.GetModelList("i_Flag=0 and PlanID=" + _PlanID);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_Plan_CheckVehicle item in list)
            {
                dgvList.Rows.Add(item.VehicleTypeID != null ? bllVehicleType.GetVehicleTypeName((int)item.VehicleTypeID) : "", item.i_Count.ToString(),
                    item.MaterieTypeID != null ? bllMaterielType.GetMaterielTypeName((int)item.MaterieTypeID) : "", item.n_Count.ToString());
            }
          
        }
    }
}
