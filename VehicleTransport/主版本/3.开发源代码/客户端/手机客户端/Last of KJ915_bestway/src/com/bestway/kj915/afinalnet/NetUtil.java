package com.bestway.kj915.afinalnet;

import android.content.ContentResolver;
import android.content.Context;
import android.database.Cursor;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ���޹�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-9-1 ����3:47:26
 */
public class NetUtil {
	/**
	 * �ж����磬��������Ƿ����
	 * 
	 * @param context
	 * @return
	 */
	public static boolean checkNet(Context context) {
		// �� �жϣ�ʹ��WIFI����
		// �� �жϣ�ʹ��Mobile��APN
		// ���û�����磬��ʾ�û�����
		// �۵��û�ʹ��ʹ��Mobile��APN���������ֳ�NET����WAP
		// ��ȡAPN������Ϣ������������ݷǿ�WAP

		boolean wifiConnectivity = isWIFIConn(context);
		boolean apnConnectivity = isApnConn(context);

		if (!wifiConnectivity && !apnConnectivity) {
			return false;
		}

		if (apnConnectivity) {
			// ���ֳ�NET����WAP
			// ��ȡAPN������Ϣ������������ݷǿ�WAP
			readApn(context);// ����ϵ��
		}

		return true;
	}

	private static void readApn(Context context) {
		// google 4.0�Ժ�������ģ�����������û�����APN
		Uri PREFERRED_APN_URI = Uri
				.parse("content://telephony/carriers/preferapn");// 4.0ģ�������ε���Ȩ��

		ContentResolver resolver = context.getContentResolver();
		// uri:��ȡ���Ǳ�ѡ�е�ͨ��ͨ��
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
	 * �жϣ�ʹ��Mobile��APN
	 * 
	 * @param context
	 * @return
	 */
	private static boolean isApnConn(Context context) {
		ConnectivityManager manager = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		// ��ȡ�ƶ����͵�����ͨ��ͨ��״̬
		NetworkInfo networkInfo = manager
				.getNetworkInfo(ConnectivityManager.TYPE_MOBILE);
		if (networkInfo != null) {
			return networkInfo.isConnected();
		}
		return false;
	}

	/**
	 * �жϣ�ʹ��WIFI����
	 * 
	 * @param context
	 * 
	 * @return
	 */
	private static boolean isWIFIConn(Context context) {
		ConnectivityManager manager = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		// ��ȡ�ƶ����͵�����ͨ��ͨ��״̬
		NetworkInfo networkInfo = manager
				.getNetworkInfo(ConnectivityManager.TYPE_WIFI);
		if (networkInfo != null) {
			return networkInfo.isConnected();
		}
		return false;
	}
}
