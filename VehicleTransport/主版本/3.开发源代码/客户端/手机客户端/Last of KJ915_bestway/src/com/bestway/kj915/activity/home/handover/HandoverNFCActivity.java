package com.bestway.kj915.activity.home.handover;

import java.util.List;

import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.IntentFilter.MalformedMimeTypeException;
import android.nfc.NfcAdapter;
import android.nfc.tech.NfcF;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.nfc.NfcMessageParser;
import com.bestway.kj915.utils.LogUtils;

public class HandoverNFCActivity extends BasicTitleActivity {

	private NfcAdapter mAdapter;
	private PendingIntent mPendingIntent;
	private IntentFilter[] mFilters;
	private String[][] mTechLists;
	private String result;
	private TextView tv_number;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_unload_nfc_scaner);

		mAdapter = NfcAdapter.getDefaultAdapter(this);

		mPendingIntent = PendingIntent.getActivity(this, 0, new Intent(this,
				getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);

		IntentFilter ndef = new IntentFilter(NfcAdapter.ACTION_NDEF_DISCOVERED);
		try {
			ndef.addDataType("*/*");
		} catch (MalformedMimeTypeException e) {
			throw new RuntimeException("fail", e);
		}
		mFilters = new IntentFilter[] { ndef };

		mTechLists = new String[][] { new String[] { NfcF.class.getName() } };

		initData();

		initView();

	}

	private void initData() {

	}

	private void initView() {
		tv_number = (TextView) findViewById(R.id.tv_number);

	}

	@Override
	public void onResume() {

		super.onResume();

		if (mAdapter != null)

			mAdapter.enableForegroundDispatch(this, mPendingIntent, mFilters,
					mTechLists);
	}

	@Override
	public void onNewIntent(Intent intent) {
		super.onNewIntent(intent);

		Integer newNumber = 0;

		NfcMessageParser nfcMessageParser = new NfcMessageParser(intent);
		List<String> tagMessage = nfcMessageParser.getTagMessage();

		String text = tagMessage.get(0);
		int start = text.lastIndexOf("TEL;CEL") + 9;
		int end = text.lastIndexOf("END:VCARD");
		result = tagMessage.get(0).substring(start, end);

		LogUtils.careLog("获取的数字是=" + result);

		try {
			newNumber = Integer.parseInt(result.trim());
		} catch (Exception e) {
			Toast.makeText(HandoverNFCActivity.this, "卡的内容格式错误", 0).show();
			return;
		}

		tv_number.setText("NO: " + result);

		Intent intent2 = new Intent(
				"com.bestway.kj915.activity.home.handover.HandoverAcitvity");
		intent2.putExtra("number", newNumber);

		startActivity(intent2);

	}

	@Override
	public void onPause() {
		super.onPause();

		if (mAdapter != null)

			mAdapter.disableForegroundDispatch(this);
		finish();
	}

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);

		title_text_view.setText("交接车");

	}

}
