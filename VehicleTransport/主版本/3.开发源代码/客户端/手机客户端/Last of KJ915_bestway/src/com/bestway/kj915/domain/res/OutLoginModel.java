package com.bestway.kj915.domain.res;

import java.io.Serializable;
import java.util.HashMap;

/**
 * 获取登录结果的bean
 * 
 * @author gaga
 * 
 */
public class OutLoginModel extends BasicResInner implements Serializable {
	public String UserID;

	public String getUserID() {
		return UserID;
	}

	public void setUserID(String userID) {
		UserID = userID;
	}

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutLoginModel", OutLoginModel.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		return null;
	}

}
