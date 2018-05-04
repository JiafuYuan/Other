package com.bestway.kj915.afinalnet;

import android.content.ContentResolver;
import android.content.Context;
import android.database.Cursor;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;

/**
 * 版权：南京北路自动化系统有限公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-9-1 下午3:47:26
 */
public class NetUtil {
	/**
	 * 判断网络，检查网络是否可用
	 * 
	 * @param context
	 * @return
	 */
	public static boolean checkNet(Context context) {
		// ① 判断：使用WIFI上网
		// ② 判断：使用Mobile中APN
		// 如果没有网络，提示用户设置
		// ③当用户使用使用Mobile中APN上网，区分出NET还是WAP
		// 读取APN设置信息，如果代理内容非空WAP

		boolean wifiConnectivity = isWIFIConn(context);
		boolean apnConnectivity = isApnConn(context);

		if (!wifiConnectivity && !apnConnectivity) {
			return false;
		}

		if (apnConnectivity) {
			// 区分出NET还是WAP
			// 读取APN设置信息，如果代理内容非空WAP
			readApn(context);// 读联系人
		}

		return true;
	}

	private static void readApn(Context context) {
		// google 4.0以后的真机和模拟器不允许用户操作APN
		Uri PREFERRED_APN_URI = Uri
				.parse("content://telephony/carriers/preferapn");// 4.0模拟器屏蔽掉该权限

		ContentResolver resolver = context.getContentResolver();
		// uri:获取的是被选中的通信通道
		Cursor cursor = resolver.query(PREFERRED_APN_URI, null, null, null,
				null);
		if (cursor != null && cursor.moveToFirst()) {
			GlobleParams.PROXY_IP = cursor.getString(cursor
					.getColumnIndex("proxy"));
			GlobleParams.PROXY_PORT = cursor.getInt(cursor
					.getColumnIndex("port"));
			cursor.close();
		}
	}

	/**
	 * 判断：使用Mobile中APN
	 * 
	 * @param context
	 * @return
	 */
	private static boolean isApnConn(Context context) {
		ConnectivityManager manager = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		// 获取制定类型的网络通信通道状态
		NetworkInfo networkInfo = manager
				.getNetworkInfo(ConnectivityManager.TYPE_MOBILE);
		if (networkInfo != null) {
			return networkInfo.isConnected();
		}
		return false;
	}

	/**
	 * 判断：使用WIFI上网
	 * 
	 * @param context
	 * 
	 * @return
	 */
	private static boolean isWIFIConn(Context context) {
		ConnectivityManager manager = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		// 获取制定类型的网络通信通道状态
		NetworkInfo networkInfo = manager
				.getNetworkInfo(ConnectivityManager.TYPE_WIFI);
		if (networkInfo != null) {
			return networkInfo.isConnected();
		}
		return false;
	}
}
