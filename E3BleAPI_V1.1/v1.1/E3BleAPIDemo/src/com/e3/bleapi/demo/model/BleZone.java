package com.e3.bleapi.demo.model;

import java.util.ArrayList;
import java.util.List;

public class BleZone {
	protected int id;
	protected String desc;
	protected List<BleZone> subZones = new ArrayList<BleZone>();
	protected List<BleDevice> devices = new ArrayList<BleDevice>();
	protected BleZone parent = null;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	
	public String getDesc() {
		return desc;
	}
	public void setDesc(String desc) {
		this.desc = desc;
	}
	
	public List<BleZone> getSubZones() {
		return subZones;
	}
	public void setSubZones(List<BleZone> subZones) {
		this.subZones = subZones;
		for(BleZone z: subZones){
			z.setParentZone(this);
		}
	}

	public List<BleDevice> getDevices() {
		return devices;
	}
	public void setDevices(List<BleDevice> devices) {
		this.devices = devices;
	}

	public BleZone getParent() {
		return parent;
	}
	public void setParent(BleZone parent) {
		this.parent = parent;
	}
	
	public void setParentZone(BleZone parentZone) {
		this.parent = parentZone;
	}
	
	public void addBleDevice(BleDevice device){
		if(devices == null)
			devices = new ArrayList<BleDevice>();
		devices.add(device);
	}
	
	public void removeBleDevice(BleDevice device){
		if(devices != null){
			devices.remove(device);
		}
	}
	
	public void addSubZone(BleZone zone){
		if(subZones == null){
			subZones = new ArrayList<BleZone>();
		}
		subZones.add(zone);
		zone.setParentZone(this);
	}
	
	public BleDevice getDevice(String macAddr){
		for(BleDevice d:devices){
			if(d.getMacAddr().equals(macAddr)){
				return d;
			}
		}
		
		return null;
	}
	
	public BleDevice getDevice(int saddr){
		for(BleDevice d:devices){
			if(d.getAddr() == saddr)
				return d;
		}
		
		return null;
	}
	
	public BleZone getSubZoneById(int zoneid){
		for(BleZone z: subZones){
			if(z.getId() == zoneid)
				return z;
		}
		
		return null;
	}
}
