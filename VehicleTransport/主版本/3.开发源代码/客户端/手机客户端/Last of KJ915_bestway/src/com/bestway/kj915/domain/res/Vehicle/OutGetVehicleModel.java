package com.bestway.kj915.domain.res.Vehicle;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_Vehicle;
import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetVehicleModel extends BasicResInner {
	public ListVehicle ListVehicle;

	public String LastUpdateTime;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetVehicleModel", OutGetVehicleModel.class);
		map.put("m_Vehicle", m_Vehicle.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", ListVehicle.class);
		return map;
	}

}
