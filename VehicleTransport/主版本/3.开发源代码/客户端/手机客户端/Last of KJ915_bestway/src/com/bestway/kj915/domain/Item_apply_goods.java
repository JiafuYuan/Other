package com.bestway.kj915.domain;

//申请的物料项
public class Item_apply_goods {
	private String catagory;// 物料类型
	private String unit;// 物料的单位
	private int number=0;// 数量

	public String getCatagory() {
		return catagory;
	}

	public void setCatagory(String catagory) {
		this.catagory = catagory;
	}


	public String getUnit() {
		return unit;
	}

	public void setUnit(String unit) {
		this.unit = unit;
	}

	public int getNumber() {
		return number;
	}

	public void setNumber(int number) {
		this.number = number;
	}

	public Item_apply_goods(String catagory, String unit,
			int number) {
		super();
		this.catagory = catagory;
		this.unit = unit;
		this.number = number;
	}

}
