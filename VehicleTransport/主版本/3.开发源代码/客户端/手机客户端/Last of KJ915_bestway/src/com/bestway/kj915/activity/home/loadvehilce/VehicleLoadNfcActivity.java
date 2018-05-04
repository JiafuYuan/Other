package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.List;

import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.IntentFilter.MalformedMimeTypeException;
import android.nfc.NfcAdapter;
import android.nfc.tech.NfcF;
import android.os.Bundle;
import android.os.Vibrator;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.nfc.NfcMessageParser;

public class VehicleLoadNfcActivity extends BasicTitleActivity {
	private ArrayList<String> dataList;
	private NfcAdapter mAdapter;
	private PendingIntent mPendingIntent;
	private IntentFilter[] mFilters;
	private String[][] mTechLists;
	private String result;
	private MyDropdownBox materilType;
	private ListView lv_vehicle_number;
	private VehicleAdapter adapter;

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("扫描车辆");

	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_load_vehicle_scaner);

		initData();

		initView();

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
	}

	private void initView() {

		lv_vehicle_number = (ListView) findViewById(R.id.lv_vehicle_number);

		adapter = new VehicleAdapter();

		lv_vehicle_number.setAdapter(adapter);

	}

	private void initData() {

		dataList = new ArrayList<String>();

		for (int i = 0; i < 3; i++) {
			dataList.add("12120" + i);
		}

		materilType = (MyDropdownBox) findViewById(R.id.drop_box_materilType);
		materilType.setData(GlobleFields.getList_MaterielType(this));

		MyDropdownBox unit = (MyDropdownBox) findViewById(R.id.drop_box_unit);
		unit.setData(GlobleFields.getList_MaterielUnit(this));

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

		NfcMessageParser nfcMessageParser = new NfcMessageParser(intent);
		List<String> tagMessage = nfcMessageParser.getTagMessage();
		String text = tagMessage.get(0);
		int start = text.lastIndexOf("TEL;CEL") + 9;
		int end = text.lastIndexOf("END:VCARD");
		result = tagMessage.get(0).substring(start, end);

		/**
		 * 添加刷新
		 */
		if (dataList.contains(result.trim())) {
			Toast.makeText(VehicleLoadNfcActivity.this, "当前车辆重复扫描", 1).show();
			return;
		}
		dataList.add(0, result.trim());

		/**
		 * 震动
		 */
		long[] pattern = { 100, 100, 200, 200 };
		// repeat是重复的次数，-1代表不重复，1代表重复1此
		Vibrator vibrator = (Vibrator) getSystemService(VIBRATOR_SERVICE);
		vibrator.vibrate(pattern, -1);

		Toast.makeText(VehicleLoadNfcActivity.this, "成功添加一条", 1).show();

		adapter.notifyDataSetChanged();
	}

	@Override
	public void onPause() {
		super.onPause();
		if (mAdapter != null)
			mAdapter.disableForegroundDispatch(this);
	}

	/**
	 * 装车完成
	 * 
	 * @param v
	 */
	public void loadComplete(View v) {

		MyDropdownBox drop_box_materilType = (MyDropdownBox) findViewById(R.id.drop_box_materilType);
		EditText number = (EditText) findViewById(R.id.number_value);

		String materilType = drop_box_materilType.getCurrentText();
		String textCount = number.getText().toString();

		if (TextUtils.isEmpty(materilType)) {
			Toast.makeText(this, "物料类型不能为空", 0).show();
			return;
		}

		if (TextUtils.isEmpty(textCount)) {
			Toast.makeText(this, "数量必填", 0).show();
			return;
		}

		// 处理数字格式不准确
		int n_Count;
		try {

			n_Count = Integer.valueOf(textCount);
		} catch (Exception e) {
			Toast.makeText(this, "物料数量格式填写错误", 0).show();
			return;
		}

		System.out.println("...." + GlobleFields.reqLoad);

		for (String str : dataList) {

			int vehicleID = Integer.valueOf(str);

			int materieTypeID = GlobleFields.getHashMap_MaterielType(this)
					.get(materilType).getID();

			m_Plan_Load load = new m_Plan_Load(0, GlobleFields.CurrentPlan.ID,
					vehicleID, materieTypeID, n_Count, "", 0);

			// 添加一条数据到装车列表
			GlobleFields.reqLoad.ListM_Plan_Load.list.add(load);

		}

		finish();

		startActivity(new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadSubmitActivity"));

	}

	/**
	 * 继续装车
	 */
	public void toContinue(View v) {

		MyDropdownBox drop_box_materilType = (MyDropdownBox) findViewById(R.id.drop_box_materilType);
		EditText number = (EditText) findViewById(R.id.number_value);

		String materilType = drop_box_materilType.getCurrentText();
		String textCount = number.getText().toString();

		if (TextUtils.isEmpty(materilType)) {
			Toast.makeText(this, "物料类型不能为空", 0).show();
			return;
		}

		if (TextUtils.isEmpty(textCount)) {
			Toast.makeText(this, "数量必填", 0).show();
			return;
		}

		// 处理数字格式不准确
		int n_Count;
		try {

			n_Count = Integer.valueOf(textCount);
		} catch (Exception e) {
			Toast.makeText(this, "物料数量格式填写错误", 0).show();
			return;
		}

		System.out.println("...." + GlobleFields.reqLoad);

		for (String str : dataList) {

			int vehicleID = Integer.valueOf(str);

			int materieTypeID = GlobleFields.map_MaterielType.get(materilType)
					.getID();

			m_Plan_Load load = new m_Plan_Load(0, GlobleFields.CurrentPlan.ID,
					vehicleID, materieTypeID, n_Count, "", 0);

			// 添加一条数据到装车列表
			GlobleFields.reqLoad.ListM_Plan_Load.list.add(load);

		}

		finish();
		startActivity(new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadNfcActivity"));

	}

	public class VehicleAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return dataList.size();
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
			View view = View.inflate(VehicleLoadNfcActivity.this,
					R.layout.item_load_nfc, null);
			TextView number = (TextView) view.findViewById(R.id.number);
			TextView value = (TextView) view.findViewById(R.id.value);

			number.setText("车辆编号" + (position + 1));
			value.setText(dataList.get(position));

			return view;
		}

	}
}
