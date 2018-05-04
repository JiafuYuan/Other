package com.bestway.kj915.activity;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.application.SysApplication;
import com.bestway.kj915.utils.IpUtils;
import com.bestway.kj915.utils.SharePreferenceUtils_config;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class SetIpActivity extends Activity {

	private EditText et_ip;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		SysApplication.getInstance().addActivity(this);

		setContentView(R.layout.activity_set_ip);

		et_ip = (EditText) findViewById(R.id.et_ip);

		GlobleFields.sp = getSharedPreferences("config", Context.MODE_PRIVATE);

		String savedIP = GlobleFields.sp.getString("IP", null);
		
		System.out.println("savedIPsavedIPsavedIP..."+savedIP);
		
		if (!TextUtils.isEmpty(savedIP))
			et_ip.setText(savedIP);
	}

	public void next(View view) {

		String setIP = et_ip.getText().toString();

		if (TextUtils.isEmpty(setIP)) {
			Toast.makeText(this, "ip地址不能为空", 0).show();
			return;
		}
		
		if (!IpUtils.isValidIPAddress(setIP)) {
			Toast.makeText(this, "ip地址不合法", 0).show();
			return;
		}

		SharePreferenceUtils_config.edit_String(this, "IP", setIP);

		GlobleFields.IP = setIP;

		startActivity(new Intent("com.bestway.kj915.activity.SplashActivity"));

		finish();
	}
}
