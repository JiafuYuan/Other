package com.bestway.kj915.domain.req.handover;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqHandover extends BasicReqInner {

	public int UserID;

	public int DepartmentID;

	public int AddressID;

	public int PlanID;

	public String DateTime;

	public HandoverContainer ListM_Plan_HandoverMaterie;

	@Override
	public String getCmdType() {
		return NetCallback.Flow_Handover;
	}

	@Override
	public String getInnerRootMode() {
		return "InHandoverModel";
	}

}
