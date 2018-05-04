package com.bestway.kj915.domain.req.load;

import java.io.Serializable;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqLoad extends BasicReqInner implements Serializable {

	public int UserID;
	public int DepartmentID;
	public int AddressID;

	public int PlanID=0;

	public String DateTime;
	
	public  LoadContainer ListM_Plan_Load;

	@Override
	public String getCmdType() {
		return NetCallback.Flow_Load;
	}

	@Override
	public String getInnerRootMode() {
		return "InLoadModel";
	}

	public ReqLoad() {
		super();
	}

	public ReqLoad(int userID, int departmentID, int addressID, int planID,
			String dateTime, LoadContainer listM_Plan_Load) {
		super();
		UserID = userID;
		DepartmentID = departmentID;
		AddressID = addressID;
		PlanID = planID;
		DateTime = dateTime;
		ListM_Plan_Load = listM_Plan_Load;
	}

	
}
