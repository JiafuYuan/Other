package com.bestway.kj915.activity.home.set;

import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.ReqChangePassowrd;

public class ChangePasswordActivity extends BasicTitleActivity {

	private EditText yuanshi_mm;
	private EditText new_mm;
	private EditText queren_mm;

	@Override
	public void doVarious() {
		title_text_view.setText("修改密码");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_changepassword);

		intView();
	}

	private void intView() {
		yuanshi_mm = (EditText) findViewById(R.id.yuanshi_mm);
		new_mm = (EditText) findViewById(R.id.new_mm);
		queren_mm = (EditText) findViewById(R.id.queren_mm);

	}

	public void change(View view) {

		if (TextUtils.isEmpty(new_mm.getText().toString())
				|| TextUtils.isEmpty(queren_mm.getText().toString())) {
			Toast.makeText(this, "密码或者确认密码不能为空", 0).show();
			return;

		}
		if (!new_mm.getText().toString().equals(queren_mm.getText().toString())) {
			Toast.makeText(this, "确认密码和新密码不匹配", 0).show();
			return;

		}
		
		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqChangePassowrd(new_mm.getText().toString(), GlobleFields.UserID),
				new NetCallback() {

					@Override
					public String getCmdType() {
						return NetCallback.ChangePassword;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public void onResult(String inner, boolean Result) {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						System.out.println(entireXml);

					}

				});
	}
}
