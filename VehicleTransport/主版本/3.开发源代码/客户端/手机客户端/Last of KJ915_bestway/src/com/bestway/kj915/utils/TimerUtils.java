package com.bestway.kj915.utils;

import java.io.DataOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class TimerUtils {
	/**
	 * ��ȡ��ǰ��ʱ�䣬��ʽ����2014-09-18T15:41:31
	 * 
	 * 
	 * @return
	 */
	public static String getTime() {

		SimpleDateFormat dateFormat = new SimpleDateFormat(
				"yyyy-MM-dd#HH:mm:ss");

		return dateFormat.format(new Date()).replace("#", "T");

	}

	public static void testDate() {
		try {
			Process process = Runtime.getRuntime().exec("su");
			String datetime = "20131023.132800"; // ���Ե����õ�ʱ�䡾ʱ���ʽ
													// yyyyMMdd.HHmmss��
			DataOutputStream os = new DataOutputStream(
					process.getOutputStream());
			os.writeBytes("setprop persist.sys.timezone GMT\n");
			os.writeBytes("/system/bin/date -s " + datetime + "\n");
			os.writeBytes("clock -w\n");
			os.writeBytes("exit\n");
			os.flush();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
