package com.bestway.kj915.domain;

/**
 * 供车的运单项
 * 
 * @author gaga
 * 
 */
public class Item_Waybill {
	private String catagory;// 车的种类
	private int number;// 车的数量

	public String getCatagory() {
		return catagory;
	}

	public void setCatagory(String catagory) {
		this.catagory = catagory;
	}

	public int getNumber() {
		return number;
	}

	public void setNumber(int number) {
		this.number = number;
	}

	public Item_Waybill(String catagory, int number) {
		super();
		this.catagory = catagory;
		this.number = number;
	}

}
