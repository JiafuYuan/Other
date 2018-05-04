package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqLoginOut extends BasicReqInner {
	public int UserID;

	public ReqLoginOut(int userID) {
		super();
		UserID = userID;
	}

	@Override
	public String getCmdType() {
		return NetCallback.LoginOut;
	}

	@Override
	public String getInnerRootMode() {
		return "InLoginOutModel";
	}

}
