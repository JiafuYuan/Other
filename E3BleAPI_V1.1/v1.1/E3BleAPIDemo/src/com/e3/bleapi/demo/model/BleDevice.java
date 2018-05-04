package com.e3.bleapi.demo.model;

public class BleDevice {
	public static final int DEVICE_TYPE_LIGHT_CW 	= 1;//色温灯
	public static final int DEVICE_TYPE_LIGHT_RGB 	= 2;//RGB灯
	public static final int DEVICE_TYPE_LIGHT_RGBW	= 3;//RGBW灯
	
	protected String 	macAddr;
	protected int 		addr;
	protected String 	desc;
	protected int 		rssi;
	protected int 		type;		//device type
	
	
	protected int 		dim;		//亮度
	protected int 		onoff;		//开关状态 0：关   1：开
	
	public BleDevice(String macaddr,int saddr,String des,int mrssi,int t){
		this.macAddr = macaddr;
		this.addr = saddr;
		this.desc = des.trim();
		this.rssi = mrssi;
		this.type = t;
		this.onoff = 1;
	}
	
	public BleDevice(){
		
	}

	/**
	 * @return the macAddr
	 */
	public String getMacAddr() {
		return macAddr;
	}

	/**
	 * @param macAddr the macAddr to set
	 */
	public void setMacAddr(String macAddr) {
		this.macAddr = macAddr;
	}

	/**
	 * @return the addr
	 */
	public int getAddr() {
		return addr;
	}

	/**
	 * @param addr the addr to set
	 */
	public void setAddr(int addr) {
		this.addr = addr;
	}

	/**
	 * @return the desc
	 */
	public String getDesc() {
		return desc;
	}

	/**
	 * @param desc the desc to set
	 */
	public void setDesc(String desc) {
		this.desc = desc.trim();
	}

	/**
	 * @return the rssi
	 */
	public int getRssi() {
		return rssi;
	}

	/**
	 * @param rssi the rssi to set
	 */
	public void setRssi(int rssi) {
		this.rssi = rssi;
	}

	/**
	 * @return the dim
	 */
	public int getDim() {
		return dim;
	}

	/**
	 * @param dim the dim to set
	 */
	public void setDim(int dim) {
		this.dim = dim;
	}

	/**
	 * @return the onoff
	 */
	public int getOnoff() {
		return onoff;
	}

	/**
	 * @param onoff the onoff to set
	 */
	public void setOnoff(int onoff) {
		this.onoff = onoff;
	}

	/**
	 * @return the type
	 */
	public int getType() {
		return type;
	}

	/**
	 * @param type the type to set
	 */
	public void setType(int type) {
		this.type = type;
	}
	
	
}
