package com.e3.bleapi.demo;

import android.bluetooth.BluetoothDevice;

import com.e3.ble.model.DeviceInfo;

public interface MyUICallback {
	void onUIConnected(String macAddress);
	void onUIConnectedFailed(String macAddress, int code);
	void onUIAddToMeshSucceeded(String macAddress, int code);
	void onUIAddToMeshFailed(String macAddress, int code);
	void onUIConnectionLost();
	void onUINewBleDeviceFound(final BluetoothDevice device, final int rssi, final DeviceInfo dInfo);
	void onUIDeviceStatusChanged(byte addr, boolean isOnline, byte level, byte temColor);
}
