package com.bestway.kj915.domain.res.distribute;

import java.util.HashMap;

import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetVehicleDistributedModel extends BasicResInner {

	public Listv_AreaVehicle Listv_AreaVehicle;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetVehicleDistributedModel", OutGetVehicleDistributedModel.class);
		map.put("v_AreaVehicle", v_AreaVehicle.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listv_AreaVehicle.class);
		return map;
	}

}
