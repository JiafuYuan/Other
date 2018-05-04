package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqCard extends BasicReqInner {
	public String LastUpdateTime;

	@Override
	public String getCmdType() {
		return NetCallback.Data_GetCard;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetCardModel";
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	public ReqCard(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
