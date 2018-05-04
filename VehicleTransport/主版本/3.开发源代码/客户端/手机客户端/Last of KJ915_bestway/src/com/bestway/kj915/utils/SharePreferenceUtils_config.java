package com.bestway.kj915.utils;

import android.content.Context;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;

public class SharePreferenceUtils_config {

	public static String fileName = "config";

	public static void edit_String(Context context, String name, String value) {
		SharedPreferences sp = context.getSharedPreferences(fileName,
				Context.MODE_PRIVATE);
		Editor editor = sp.edit();
		editor.putString(name, value);
		editor.commit();
		System.out.println("工具更新config成功");
		sp = null;
	}

	public static void edit_Boolean(Context context, String name, boolean value) {
		SharedPreferences sp = context.getSharedPreferences(fileName,
				Context.MODE_PRIVATE);
		Editor editor = sp.edit();
		editor.putBoolean(name, value);
		editor.commit();
		System.out.println("工具更新config成功");
		sp = null;
	}

	public static void edit_Int(Context context, String name, int value) {
		SharedPreferences sp = context.getSharedPreferences(fileName,
				Context.MODE_PRIVATE);
		Editor editor = sp.edit();
		editor.putInt(name, value);
		editor.commit();
		System.out.println("工具更新config成功");
		sp = null;
	}
}
