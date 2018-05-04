package com.bestway.kj915.domain.res.plan;

import java.util.HashMap;

import com.bestway.kj915.domain.m_Plan;
import com.bestway.kj915.domain.res.BasicResInner;

public class OutGetPlanDetailModel extends BasicResInner {

	public Listm_Plan Listm_Plan;
	public Listm_Apply Listm_Apply;
	public Listm_Plan_ApplyMaterie Listm_Plan_ApplyMaterie;
	public Listm_Plan_ApplyVehicle Listm_Plan_ApplyVehicle;

	public Listm_Plan_CheckVehicle Listm_Plan_CheckVehicle;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetPlanDetailModel", OutGetPlanDetailModel.class);
		map.put("m_Plan", m_Plan.class);
		map.put("m_Apply", m_Apply.class);
		map.put("m_Plan_ApplyMaterie", m_Plan_ApplyMaterie.class);
		map.put("m_Plan_ApplyVehicle", m_Plan_ApplyVehicle.class);
		map.put("m_Plan_CheckVehicle", m_Plan_CheckVehicle.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", Listm_Plan.class);
		map.put("list1", Listm_Apply.class);
		map.put("list2", Listm_Plan_ApplyMaterie.class);
		map.put("list3", Listm_Plan_ApplyVehicle.class);
		map.put("list4", Listm_Plan_CheckVehicle.class);
		return map;
	}

}
