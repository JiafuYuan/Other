package com.bestway.kj915.domain.req.supply;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class SupplyContainer {
	@XStreamImplicit(itemFieldName = "m_Plan_GiveVehicle")
	public List<m_Plan_GiveVehicle> list;

}
