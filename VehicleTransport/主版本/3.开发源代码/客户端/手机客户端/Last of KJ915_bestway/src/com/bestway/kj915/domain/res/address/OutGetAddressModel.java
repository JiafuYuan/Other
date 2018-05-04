package com.bestway.kj915.domain.res.address;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.res.BasicResInner;
/**
 * 获取地点的响应
 * @author gaga
 *
 */
public class OutGetAddressModel extends BasicResInner {

	public Listm_Address Listm_Address;
	public String LastUpdateTime;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetAddressModel", OutGetAddressModel.class);
		map.put("m_Address", m_Address.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listm_Address.class);
		return map;
	}

}
