package com.bestway.kj915.domain.res.person;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_Person;
import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetPersonModel extends BasicResInner {

	public Listm_Person Listm_Person;
	public String LastUpdateTime;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetPersonModel", OutGetPersonModel.class);
		map.put("m_Person", m_Person.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listm_Person.class);
		return map;
	}

}
