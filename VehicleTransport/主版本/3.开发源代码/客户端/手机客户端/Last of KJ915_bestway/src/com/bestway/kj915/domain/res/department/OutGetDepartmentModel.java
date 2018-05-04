package com.bestway.kj915.domain.res.department;

import java.util.HashMap;

import com.bestway.kj915.domain.reflect.m_Department;
import com.bestway.kj915.domain.res.BasicResInner;
/**
 * 基础数据的 部门信息表
 * @author gaga
 *
 */
public class OutGetDepartmentModel extends BasicResInner {
	public ListM_Departments ListMessage;
	public String LastUpdateTime;
	

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutGetDepartmentModel", OutGetDepartmentModel.class);
		map.put("m_Department", m_Department.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("list", ListM_Departments.class);
		return map;
	}

	public ListM_Departments getListM_Department() {
		return ListMessage;
	}

	public void setListM_Department(ListM_Departments listM_Department) {
		ListMessage = listM_Department;
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	
}
