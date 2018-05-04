package com.bestway.kj915.activity.home.backvehicle;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.req.backvehicle.ReqBack;
import com.bestway.kj915.domain.req.backvehicle.m_Plan_BackVehicle;

public class BackVehicleActivity extends BasicTitleActivity {

	private ArrayList<Integer> data;
	private HashMap<String, m_VehicleType> map_VehicleType;

	@Override
	public void doVarious() {
		
		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("还车");
		
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_back);

		initData();

		initView();

	}

	private void initView() {
		ListView lv = (ListView) findViewById(R.id.lv);

		BackAdapter adapter = new BackAdapter();

		lv.setAdapter(adapter);

		TextView tv_total = (TextView) findViewById(R.id.tv_total);

		tv_total.setText("本次还车  " + data.size() + " 辆");
	}

	private void initData() {
		
		map_VehicleType = GlobleFields
				.getHashMap_VehicleType(BackVehicleActivity.this);

		Bundle bundle = getIntent().getExtras();

		data = bundle.getIntegerArrayList("data");
		
	}

	/**
	 * 继续扫卡
	 * 
	 * @param view
	 */
	public void restart(View view) {

		finish();

	}

	/**
	 * 提交
	 * 
	 * @param view
	 */
	public void submit(View view) {

		ReqBack back = new ReqBack();

		ArrayList<m_Plan_BackVehicle> backVehicles = new ArrayList<m_Plan_BackVehicle>();

		for (int num : data) {
			m_Plan_BackVehicle backVehicle = new m_Plan_BackVehicle();
			backVehicle.VehicleID = GlobleFields.getHashMap_Card(
					BackVehicleActivity.this).get(num);

			backVehicles.add(backVehicle);
		}

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(back, new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.Flow_Back;
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
			public void onResult(String entireXml, String inner, boolean Result) {

				System.out.println("entireXmlentireXmlentireXml" + entireXml);

			}

		});

		GlobleFields.BACK.finish();

		finish();
	}

	class BackAdapter extends BaseAdapter {

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

			View view = View.inflate(BackVehicleActivity.this,
					R.layout.item_back, null);

			// 车辆编号
			TextView number = (TextView) view.findViewById(R.id.number);
			number.setText("车辆：" + data.get(position));

			// 车辆类型
			TextView type = (TextView) view.findViewById(R.id.type);

			HashMap<Integer, Integer> map = GlobleFields
					.getHashMap_Card(BackVehicleActivity.this);

			int vehicleId = map.get(data.get(position));

			List<m_VehicleType> VehicleTypes = CommonDbUtiles
					.querryByConditions(BackVehicleActivity.this,
							m_VehicleType.class, "ID=?",
							new String[] { vehicleId + "" }, null);

			type.setText("类型： " + VehicleTypes.get(0).vc_Name);

			return view;
		}
	}
}
