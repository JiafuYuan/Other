package com.bestway.kj915.domain.res.materielType;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.res.BasicResInner;

/**
 * 基础数据的 物料类型的bean对象
 * 
 * @author gaga
 * 
 */
public class OutGetMaterielTypeModel extends BasicResInner {

	public ListM_MaterielTypes ListM_MaterielType;

	public String LastUpdateTime;
	
	public ListM_MaterielTypes getListM_MaterielType() {
		return ListM_MaterielType;
	}

	
	public void setListM_MaterielType(ListM_MaterielTypes listM_MaterielType) {
		ListM_MaterielType = listM_MaterielType;
	}

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetMaterielTypeModel", OutGetMaterielTypeModel.class);
		map.put("m_MaterielType", m_MaterielType.class);
		return map;
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}


	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}


	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", ListM_MaterielTypes.class);
		return map;
	}

}
