package com.bestway.kj915.activity;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Bundle;

import com.bestway.kj915.application.SysApplication;
import com.bestway.kj915.utils.LogUtils;

public class BasicActivity extends Activity {

	public String broadReiceiver = "close all Activitys";// 关闭所有需要打开的activity
	private BroadcastReceiver receiver;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		SysApplication.getInstance().addActivity(this);
		
		receiver = new BroadcastReceiver() {

			@Override
			public void onReceive(Context context, Intent intent) {
				LogUtils.careLog("收到关闭activity的广播");
				finish();

			}
		};

		closeMyself();

	}

	/**
	 * 在接受到退出登录后就关闭的界面
	 */
	public void closeMyself() {
		registerReceiver(receiver, new IntentFilter(broadReiceiver));
	}

	@Override
	public void onBackPressed() {
		
		super.onBackPressed();
		finish();
		
	}
	

	@Override
	protected void onDestroy() {
		
		super.onDestroy();

		unregisterReceiver(receiver);

	}
}
