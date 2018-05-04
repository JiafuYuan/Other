package com.bestway.kj915.domain.res.vehicleType;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetVehicleTypeModel extends BasicResInner {
	public Listm_VehicleType Listm_VehicleType;
	public String LastUpdateTime;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetVehicleTypeModel", OutGetVehicleTypeModel.class);
		map.put("m_VehicleType", m_VehicleType.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listm_VehicleType.class);
		return map;
	}
}
