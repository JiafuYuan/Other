package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqAddress extends BasicReqInner {
	public String LastUpdateTime;

	@Override
	public String getCmdType() {
		return NetCallback.Data_GetAddress;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetAddressModel";
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	public ReqAddress(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
