package com.e3.bleapi.demo;

import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;
import android.content.Context;
import android.util.Log;

import com.e3.ble.E3BluetoothLeAPI;
import com.e3.ble.model.DeviceInfo;

public class MyAPI extends E3BluetoothLeAPI{
	private static final String TAG = MyAPI.class.getName();
	
	private MyUICallback callback ;

	public MyAPI(Context mContext) {
		super(mContext);
		// TODO Auto-generated constructor stub
	}
	
	public void setCallback(MyUICallback callback) {
		this.callback = callback;
	}

	@Override
	public void onNewBleDeviceFound(BluetoothDevice device, int rssi,
			DeviceInfo dInfo) {
		callback.onUINewBleDeviceFound(device, rssi, dInfo);
	}

	@Override
	public void onScanStarted() {
		
	}

	@Override
	public void onScanStopped() {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onConnected(BluetoothDevice device) {
		callback.onUIConnected(device.getAddress());
	}

	@Override
	public void onConnectionFailed(BluetoothDevice device, String macAddr,
			int errorCode) {
		// TODO Auto-generated method stub
		callback.onUIConnectedFailed(macAddr, errorCode);
	}

	@Override
	public void onDisconnected(BluetoothDevice device, String macAddr,
			int errorCode) {
		// TODO Auto-generated method stub
		callback.onUIConnectionLost();
		
	}

	@Override
	public void onAvailableServices(BluetoothGatt gatt, int status) {
		// TODO Auto-generated method stub
		loginWithMeshnameAndPassword(gatt.getDevice().getName(), "345678");
	}


	@Override
	public void onLoginState(String macAddr, boolean state) {
		// TODO Auto-generated method stub
		if(state){
			Log.e(TAG, "ble login success");
		}
	}

	@Override
	public void onAddToMeshState(String macAddr, boolean state) {
		// TODO Auto-generated method stub
		if(state){
			callback.onUIAddToMeshSucceeded(macAddr, 0);
		}
	}

	@Override
	public void onAlarmMessage(int target, byte[] msg) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onBleDeviceStatusChanged(byte addr, boolean isOnline,
			byte level, byte temColor, byte[] value) {
		// TODO Auto-generated method stub
		Log.e(TAG, "onBleDeviceStatusChanged: " + addr + " , " + isOnline + " , " + level);
		if(callback != null){
			callback.onUIDeviceStatusChanged(addr, isOnline, level, temColor);
		}
	}

	@Override
	public void onDeviceGroupMessage(int target, byte[] msg) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onDeviceTimeRecived(int target, int year, int month,
			int dayOfMonth, int hour, int minute, int second) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onBleDeviceAddrMessage(int target, int newAddr, byte[] value) {
		// TODO Auto-generated method stub
		
	}

}
