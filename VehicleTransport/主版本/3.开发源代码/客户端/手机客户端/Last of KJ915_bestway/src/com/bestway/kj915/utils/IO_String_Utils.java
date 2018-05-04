package com.bestway.kj915.utils;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;

public class IO_String_Utils {

	/**
	 * 输入流转换为字符串
	 * 
	 * @param is
	 * @return
	 * @throws IOException
	 */
	public static String inputStream2String(InputStream is) {

		try {
			ByteArrayOutputStream baos = new ByteArrayOutputStream();
			int i = -1;
			while ((i = is.read()) != -1) {
				baos.write(i);
			}
			return baos.toString();
		} catch (Exception e) {
			System.out.println(e);
		}
		return null;
	}

}
