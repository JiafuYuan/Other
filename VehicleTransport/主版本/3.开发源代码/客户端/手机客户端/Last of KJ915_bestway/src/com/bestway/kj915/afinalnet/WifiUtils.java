package com.bestway.kj915.afinalnet;


import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.util.Enumeration;

import android.content.Context;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.util.Log;

public class WifiUtils {

	public static int getIP(Context context) {
		// 获取wifi服务
		WifiManager wifiManager = (WifiManager) context
				.getSystemService(Context.WIFI_SERVICE);
		// 判断wifi是否开启
		if (!wifiManager.isWifiEnabled()) {
			wifiManager.setWifiEnabled(true);
		}
		WifiInfo wifiInfo = wifiManager.getConnectionInfo();
		int ipAddress = wifiInfo.getIpAddress();
		return ipAddress;
	}

	public static String getLocalIpAddress(){
		try {
			for (Enumeration en = NetworkInterface
			.getNetworkInterfaces(); en.hasMoreElements();)
			{
				NetworkInterface intf = (NetworkInterface) en.nextElement();
				for (Enumeration enumIpAddr = intf
				.getInetAddresses(); enumIpAddr.hasMoreElements();)
				{
					InetAddress inetAddress = (InetAddress) enumIpAddr.nextElement();
					if (!inetAddress.isLoopbackAddress()
					&& !inetAddress.isLinkLocalAddress())
					{
						return inetAddress.getHostAddress().toString();
					}
				}
			}

		} catch (SocketException ex)
		{
			Log.e("WifiPreference IpAddress", ex.toString());
		}
		return null;

	}

	public static String intToIp(int i) {
		return (i & 0xFF) + "." + ((i >> 8) & 0xFF) + "." + ((i >> 16) & 0xFF)
				+ "." + (i >> 24 & 0xFF);
	}
}
