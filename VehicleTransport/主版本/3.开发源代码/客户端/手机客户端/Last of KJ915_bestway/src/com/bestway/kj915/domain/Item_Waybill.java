package com.bestway.kj915.domain;

/**
 * �������˵���
 * 
 * @author gaga
 * 
 */
public class Item_Waybill {
	private String catagory;// ��������
	private int number;// ��������

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
