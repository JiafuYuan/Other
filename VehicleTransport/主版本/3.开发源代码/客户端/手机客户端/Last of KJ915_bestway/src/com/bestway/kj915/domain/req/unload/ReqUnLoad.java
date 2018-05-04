package com.bestway.kj915.domain.req.unload;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqUnLoad extends BasicReqInner {

	public int UserID;

	public int DepartmentID;

	public int AddressID;
	public int PlanID;

	public String DateTime;

	public UnloadContainer ListM_Plan_UnLoad;

	@Override
	public String getCmdType() {
		return NetCallback.Flow_UnLoad;
	}

	@Override
	public String getInnerRootMode() {
		return "InUnLoadModel";
	}

}
