package com.bestway.kj915.activity.home.backvehicle;

import java.util.ArrayList;
import java.util.List;

import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.IntentFilter.MalformedMimeTypeException;
import android.nfc.NfcAdapter;
import android.nfc.tech.NfcF;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.nfc.NfcMessageParser;
import com.bestway.kj915.utils.LogUtils;

public class BackVehicleActivityNFCActivity extends BasicTitleActivity {

	private NfcAdapter mAdapter;
	private PendingIntent mPendingIntent;
	private IntentFilter[] mFilters;
	private String[][] mTechLists;
	private String result;
	private ArrayList<Integer> data;
	private TextView tv_number;
	private MyAdapter adapter;
	private ListView lv;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_back_nfc_scaner);
		
		GlobleFields.BACK=this;

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

		data = new ArrayList<Integer>();

	}

	private void initView() {

		tv_number = (TextView) findViewById(R.id.tv);
		adapter = new MyAdapter();
		lv = (ListView) findViewById(R.id.lv);
		lv.setAdapter(adapter);

	}

	public void restart(View view) {
		finish();
		startActivity(getIntent());
	}

	public void stop(View view) {
		
		Intent intent=new Intent(
				"com.bestway.kj915.activity.home.backvehicle.BackVehicleActivity");
		Bundle extras=new Bundle();
		extras.putIntegerArrayList("data", data);
		
		intent.putExtras(extras);
		
		startActivity(intent);
		
	}

	class MyAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return data.size();
		}

		@Override
		public Object getItem(int position) {
			return null;
		}

		@Override
		public long getItemId(int position) {
			return 0;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent) {

			View view = View.inflate(BackVehicleActivityNFCActivity.this,
					R.layout.item_nfc, null);

			TextView card_number = (TextView) view
					.findViewById(R.id.card_number);

			card_number.setText("NO: " + data.get(position));// "已经扫卡  "+data.get(position)+" 辆"

			return view;
		}

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
			Toast.makeText(BackVehicleActivityNFCActivity.this, "卡的内容格式错误", 0)
					.show();
			return;
		}

		data.add(newNumber);

		tv_number.setText("已经扫卡   " + data.size() + "  辆");

		adapter.notifyDataSetChanged();

	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);

	}

	@Override
	public void onPause() {
		super.onPause();

		if (mAdapter != null)

			mAdapter.disableForegroundDispatch(this);

	}

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);

		title_text_view.setText("还车");

	}

}
