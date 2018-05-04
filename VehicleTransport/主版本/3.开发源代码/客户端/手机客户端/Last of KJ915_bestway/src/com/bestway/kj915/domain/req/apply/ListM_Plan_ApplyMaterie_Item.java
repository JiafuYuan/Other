package com.bestway.kj915.domain.req.apply;

public class ListM_Plan_ApplyMaterie_Item {
	
	public int ID;
	public int ApplyID;
	public int MaterieTypeID;
	public int n_Count;
	public int n_CheckCount;
	public int i_Flag;

	public String vc_Memo;// ”√Õæ√Ë ˆ

	public ListM_Plan_ApplyMaterie_Item(int iD, int applyID, int materieTypeID,
			int n_Count, int n_CheckCount, int i_Flag, String vc_Memo) {
		super();
		ID = iD;
		ApplyID = applyID;
		MaterieTypeID = materieTypeID;
		this.n_Count = n_Count;
		this.n_CheckCount = n_CheckCount;
		this.i_Flag = i_Flag;
		this.vc_Memo = vc_Memo;
	}

	

}