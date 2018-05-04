package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqMaterielType extends BasicReqInner {

	public String LastUpdateTime;
	
	@Override
	public String getCmdType() {
		return NetCallback.Data_GetMaterielType;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetMaterielTypeModel";
	}

	public ReqMaterielType(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	
}
