package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqChangePassowrd extends BasicReqInner{

	public String Password;
	public int UserID;
	
	@Override
	public String getCmdType() {
		return NetCallback.ChangePassword;
	}

	@Override
	public String getInnerRootMode() {
		return "InChangePasswordModel";
	}

	public ReqChangePassowrd(String password, int userID) {
		super();
		Password = password;
		UserID = userID;
	}
	

}
