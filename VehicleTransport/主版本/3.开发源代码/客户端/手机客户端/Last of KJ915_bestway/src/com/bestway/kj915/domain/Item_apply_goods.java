package com.bestway.kj915.domain;

//�����������
public class Item_apply_goods {
	private String catagory;// ��������
	private String unit;// ���ϵĵ�λ
	private int number=0;// ����

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
