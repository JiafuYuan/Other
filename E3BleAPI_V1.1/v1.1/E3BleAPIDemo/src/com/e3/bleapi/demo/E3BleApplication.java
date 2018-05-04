package com.e3.bleapi.demo;

import java.util.ArrayList;

import com.e3.bleapi.demo.model.BleDevice;
import com.e3.bleapi.demo.model.BleZone;

import android.app.Application;
import android.bluetooth.BluetoothDevice;

public class E3BleApplication extends Application{
	public static final int GROUP_ONE_ID = 0x8001;
	public static final int GROUP_TWO_ID = 0x8002;
	public static final int GROUP_All_ID = 0xFFFF;
	
	public static BleZone rootZone;
	
	public static ArrayList<BleDevice> SCANLIST = new ArrayList<BleDevice>();
	public MyAPI myApi;
	
	@Override
	public void onCreate() {
		super.onCreate();
		myApi = new MyAPI(getApplicationContext());
	}
	
	
	static {
		rootZone = new BleZone();
		rootZone.setId(GROUP_All_ID);
		rootZone.setDesc("All");
		
		BleZone group1 = new BleZone();
		group1.setDesc("GroupOne");
		group1.setId(GROUP_ONE_ID);
		rootZone.addSubZone(group1);
		
		BleZone group2 = new BleZone();
		group2.setDesc("GroupTwo");
		group2.setId(GROUP_TWO_ID);
		rootZone.addSubZone(group2);
	}
	
	public static void updateBleDevice(byte addr,int onoff){
		for(BleDevice d:rootZone.getDevices()){
			if((d.getAddr() & 0xFF) == addr){
				d.setOnoff(onoff);
			}
		}
		
		if(rootZone.getSubZones().size() > 0){
			for(BleZone z:rootZone.getSubZones()){
				for(BleDevice d:z.getDevices()){
					if((d.getAddr() & 0xFF) == addr){
						d.setOnoff(onoff);
					}
				}
			}
		}
	}
	
}
