package com.bestway.kj915.domain.req.load;

public class m_Plan_Load {
	public int ID;//¸ø0¾ÍÐÐ
	public int PlanID=0;

	public int VehicleID;
	public int MaterieTypeID;

	public int n_Count;

	public String vc_Memo;

	public int i_Flag;
	
	

	public m_Plan_Load() {
		super();
	}



	public m_Plan_Load(int iD, int planID, int vehicleID, int materieTypeID,
			int n_Count, String vc_Memo, int i_Flag) {
		super();
		ID = iD;
		PlanID = planID;
		VehicleID = vehicleID;
		MaterieTypeID = materieTypeID;
		this.n_Count = n_Count;
		this.vc_Memo = vc_Memo;
		this.i_Flag = i_Flag;
	}
	
	
}
