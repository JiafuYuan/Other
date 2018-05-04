package com.bestway.kj915.activity.home.set;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.ReqLoginOut;

public class SettingActivity extends BasicActivity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_setting);
		LinearLayout ll_user = (LinearLayout) findViewById(R.id.ll_user);
	}

	public void unlogin(View view) {

		FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqLoginOut(GlobleFields.UserID),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						if(Result){
							stopService(GlobleFields.serverIntent);

							sendBroadcast(new Intent(broadReiceiver));
							GlobleFields.isFromSetting = true;
							startActivity(new Intent("com.bestway.kj915.activity.LoginActivity"));
						}else{
							Toast.makeText(SettingActivity.this, "µÇ³öÊ§°Ü", 0).show();
						}
					}

					@Override
					public void onResult(String inner, boolean Result) {

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {
						return NetCallback.LoginOut;
					}

					@Override
					public void doPrevious() {

					}
				});

		
	}

	@Override
	public void onBackPressed() {
		super.onBackPressed();

	}

	public void changePassword(View view) {
		
		startActivity(new Intent(
				"com.bestway.kj915.activity.home.set.ChangePasswordActivity"));
	
	}
}
