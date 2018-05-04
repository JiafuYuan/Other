package com.bestway.kj915.utils;

public class IpUtils {
	/**
	 *判断字符串是否是合法的ip
	 * @param str
	 * @return
	 */
	public static boolean isValidIPAddress(String str) {
		String temp = "";
		int tag = 0;
		if (str.charAt(0) == '.' || str.charAt(str.length() - 1) == '.')
			return false;
		for (int i = 0; i < str.length(); i++) {

			if (str.charAt(i) == '.') {
				tag++;
				if (Integer.parseInt(temp) > 255)
					return false;
				temp = "";
				continue;
			}
			if (str.charAt(i) < '0' || str.charAt(i) > '9')
				return false;
			temp += String.valueOf(str.charAt(i));
		}
		if (tag != 3)
			return false;
		return true;
	}
}
