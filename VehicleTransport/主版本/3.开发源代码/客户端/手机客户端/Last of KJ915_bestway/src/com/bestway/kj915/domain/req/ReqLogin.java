package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqLogin extends BasicReqInner {

	public String UserName;
	public String UserType = "PDA";
	public String PassWord;
	public boolean IsPasswordLogin=true;
	public int CardHID;//13

	public ReqLogin(String userName, String passWord) {
		super();
		UserName = userName;
		PassWord = passWord;
	}

	@Override
	public String getCmdType() {
		return NetCallback.Login;
	}

	@Override
	public String getInnerRootMode() {
		return "InLoginModel";
	}


}
