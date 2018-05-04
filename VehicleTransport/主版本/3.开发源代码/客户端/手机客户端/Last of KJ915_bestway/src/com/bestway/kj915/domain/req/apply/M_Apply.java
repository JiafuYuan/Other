package com.bestway.kj915.domain.req.apply;
public class M_Apply {
	
		public int ID=0;
		public int ApplyPersonID;
		public int i_State;
		public int ArriveDestinationAddressID;

		/**
		 * 标识当前的申请是物料申请还是车辆申请
		 */
		public int i_IsUseMaterieApply;

		public int ApplyDepartmentID;
		public String dt_ApplyDateTime;
		public String dt_ArriveDestinationDateTime;
		public String vc_PlanUse="缺省";

		
		public M_Apply() {
			super();
		}


		public  M_Apply(int iD, int applyPersonID, int i_State,
				int arriveDestinationAddressID, int i_IsUseMaterieApply,
				int applyDepartmentID, String dt_ApplyDateTime,
				String dt_ArriveDestinationDateTime, String vc_PlanUse) {
			super();
			ID = iD;
			ApplyPersonID = applyPersonID;
			this.i_State = i_State;
			ArriveDestinationAddressID = arriveDestinationAddressID;
			this.i_IsUseMaterieApply = i_IsUseMaterieApply;
			ApplyDepartmentID = applyDepartmentID;
			this.dt_ApplyDateTime = dt_ApplyDateTime;
			this.dt_ArriveDestinationDateTime = dt_ArriveDestinationDateTime;
			this.vc_PlanUse = vc_PlanUse;
		}

	}