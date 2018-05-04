package com.bestway.kj915.domain.req.backvehicle;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqBack extends BasicReqInner {
	public BackContainer ListM_Plan_BackVehicle;
	public int PlanID = 0;
	@Override
	public String getCmdType() {
		return NetCallback.Flow_Back;
	}
	@Override
	public String getInnerRootMode() {
		return "InBackModel";
	}
}
