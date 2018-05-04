package com.bestway.kj915.utils;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.PackageManager.NameNotFoundException;
import android.graphics.Bitmap;
import android.net.Uri;

public class IntentUtils {

	/**
	 * 传入包名即可以获得封装好的卸载程序的意图
	 * 
	 * @param packageName
	 *            包名
	 * @return
	 */
	public static Intent uninstall(String packageName) {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.VIEW");
		intent.addCategory("android.intent.category.DEFAULT");
		intent.setData(Uri.parse("package:" + packageName));
		return intent;
	}

	/**
	 * 传入短信内容既可以获取发送短信的意图
	 * 
	 * @param content
	 *            短息内容
	 * @return
	 */
	public static Intent sendSms(String content) {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.SEND");
		intent.addCategory("android.intent.category.DEFAULT");
		intent.setType("text/plain");
		intent.putExtra(Intent.EXTRA_TEXT, content);
		return intent;
	}

	/**
	 * 在已知要被打开的程序的包名，以及程序包名中第一个Activity下面的的过滤器中的action
	 * android:name="android.intent.action.MAIN"时候打开应用
	 * 
	 * @param packageName
	 *            应用的包名
	 * @param activityName
	 *            应用的要被打开的Activity的属性name
	 * @return
	 */
	public static Intent openActivity(String packageName, String activityName) {
		Intent intent = new Intent();
		intent.setClassName(packageName, activityName);
		return intent;
	}

	/**
	 * 通过给点包名打开软件
	 * 
	 * @param context
	 * @param packageName
	 * @return
	 */
	public static Intent openActivityWithPackageName(Context context,
			String packageName) {
		PackageManager pm = context.getPackageManager();
		Intent intent = null;
		try {
			PackageInfo info = pm.getPackageInfo(packageName,
					PackageManager.GET_ACTIVITIES);
			ActivityInfo[] activityInfos = info.activities;
			// 获取包名下面的activity的意图action名字
			if (activityInfos != null && activityInfos.length != 0) {
				String activityName = activityInfos[0].name;
				intent = IntentUtils.openActivity(packageName, activityName);
			}

		} catch (NameNotFoundException e) {
			e.printStackTrace();
			return null;
		}
		return intent;
	}

	/**
	 * 根据给点的电话号码，转到拨号界面
	 * 
	 * @param number
	 * @return
	 */
	public static Intent call(String number) {
		Intent intent = new Intent();
		intent.setAction(Intent.ACTION_DIAL);
		intent.setData(Uri.parse("tel:" + number));
		return intent;
	}

	/**
	 * 根据给点的电话号码，直接拨打电话
	 * 
	 * @param number
	 * @return
	 */
	public static Intent callImmediate(String number) {
		Intent intent = new Intent();
		intent.setAction(Intent.ACTION_CALL);
		intent.setData(Uri.parse("tel:" + number));
		return intent;
	}

	/**
	 * 创建快捷键的意图，注意要想快捷键创建完成必须注意一下两点 配置文件中需要权限： <uses-permission
	 * android:name="com.android.launcher.permission.INSTALL_SHORTCUT"/>
	 * 需要sendBroadcast(Intent intent)通知桌面添加快捷方式
	 * 
	 * @param appName
	 * @param bitmapIcon
	 * @param dowhatIntent
	 *            想要快捷键做什么
	 * @return
	 */
	public static Intent createShortcut(String appName, Bitmap bitmapIcon,
			Intent dowhatIntent) {
		System.out.println("安装快捷方式");
		Intent intent = new Intent(
				"com.android.launcher.action.INSTALL_SHORTCUT");
		// 设置快捷键的名称
		intent.putExtra(Intent.EXTRA_SHORTCUT_NAME, appName);
		// 设置快捷键的图标
		intent.putExtra(Intent.EXTRA_SHORTCUT_ICON, bitmapIcon);
		// 设置快捷键的意图(打开快捷键到哪个页面)
		intent.putExtra(Intent.EXTRA_SHORTCUT_INTENT, dowhatIntent);
		return intent;
	}

	/**
	 * 开启一个新的任务，当前的任务任然保持运行，有别于
	 * 
	 * @param actionName
	 * @return
	 */
	public static Intent startNewTask(String actionName) {
		Intent intent = new Intent(actionName);
		intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		return intent;
	}

	/**
	 * 返回打开桌面的意图
	 * 
	 * @return
	 */
	public static Intent goLancher() {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.MAIN");
		intent.addCategory("android.intent.category.HOME");
		return intent;
	}

	/**
	 * 一般通过startAcitivityforResult获取返回的结果，当我们选定联系人 就会返回到当前页面，通过Uri uri =
	 * data.getData()获取查询的uri Cursor cursor = resolver.query(uri, new
	 * String[]{"has_phone_number", "_id"}, null, null, null);
	 * 获取查询的结果，如果hasPhoneNumber == 0就是有记录但无号码，否则我们可以获取_id,
	 * contentResolver.query(Phone.CONTENT_URI, new String[]{"data1"},
	 * "contact_id = " + _id, null, null);获取联系人的号码。
	 * 
	 * @return
	 */
	public static Intent goCantactPage() {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.PICK");
		intent.setData(Uri.parse("content://com.android.contacts/contacts"));
		return intent;
	}

}
