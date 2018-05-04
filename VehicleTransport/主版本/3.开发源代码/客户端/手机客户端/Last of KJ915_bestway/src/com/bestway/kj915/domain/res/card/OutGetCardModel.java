package com.bestway.kj915.domain.res.card;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_Card;
import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetCardModel extends BasicResInner {

	public Listm_Card Listm_Card;
	public String LastUpdateTime;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetCardModel", OutGetCardModel.class);
		map.put("m_Card", m_Card.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listm_Card.class);
		return map;
	}

}