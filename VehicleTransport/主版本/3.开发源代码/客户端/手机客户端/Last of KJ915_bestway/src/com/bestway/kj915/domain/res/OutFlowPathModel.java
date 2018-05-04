package com.bestway.kj915.domain.res;

import java.util.HashMap;

/**
 * 流程节点控制
 * 
 * @author gaga
 * 
 */
public class OutFlowPathModel extends BasicResInner {

	public boolean Apply;
	public boolean Check;// 不需要用到
	public boolean Give;
	public boolean Load;
	public boolean Handover;
	public boolean UnLoad;
	public boolean Back;

	@Override
	public HashMap<String, Class> getMyDefineClass() {
		HashMap<String, Class> map = getNewEmpty();
		map.put("OutFlowPathModel", OutFlowPathModel.class);
		return map;
	}

	@Override
	public HashMap<String, Class> getList() {
		return null;
	}

	@Override
	public String toString() {
		return "OutFlowPathModel [Apply=" + Apply + ", Check=" + Check
				+ ", Give=" + Give + ", Load=" + Load + ", Handover="
				+ Handover + ", UnLoad=" + UnLoad + ", Back=" + Back + "]";
	}

}
