package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
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
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.custom.MyDropdownBox.ContentChangeListener;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;

public class LoadChooseActivity extends BasicTitleActivity {

	private ArrayList<Integer> data;
	private HashMap<String, m_VehicleType> map_VehicleType;
	private MyDropdownBox catagory;
	private EditText number;
	private HashMap<String, String> map_MaterielUnit;
	private HashMap<Integer, Integer> map_Card;

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("装车填写物料");

	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		GlobleFields.LOAD = this;

		setContentView(R.layout.activity_load_vehicle_choose);

		initData();

		initView();

	}

	private void initView() {
		ListView lv = (ListView) findViewById(R.id.lv);

		BackAdapter adapter = new BackAdapter();

		lv.setAdapter(adapter);

		final TextView unit = (TextView) findViewById(R.id.unit);

		catagory = (MyDropdownBox) findViewById(R.id.catagory);
		catagory.setData(GlobleFields.getList_MaterielType(this));

		catagory.setOnContentChangeListener(new ContentChangeListener() {

			@Override
			public void sameContent(String content) {

			}

			@Override
			public void onContentChange(String content) {
				unit.setText(map_MaterielUnit.get(content.trim()));
			}
		});

		number = (EditText) findViewById(R.id.number);

	}

	private void initData() {

		map_VehicleType = GlobleFields
				.getHashMap_VehicleType(LoadChooseActivity.this);

		Bundle bundle = getIntent().getExtras();

		data = bundle.getIntegerArrayList("data");

		map_MaterielUnit = GlobleFields.getHashMap_MaterielUnit(this);

		map_Card = GlobleFields.getHashMap_Card(this);
	}

	/**
	 * 继续扫卡
	 * 
	 * @param view
	 */
	public void restart(View view) {
		if (TextUtils.isEmpty(catagory.getCurrentText())) {
			Toast.makeText(this, "物料类型不能为空", 0).show();
			return;
		}
		if (TextUtils.isEmpty(number.getText().toString())) {
			Toast.makeText(this, "数量不能为空", 0).show();
			return;
		}

		saveCurrentData();

		startActivity(new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.LoadNFCActivity"));

		finish();

	}

	/**
	 * 进入提交页面
	 * 
	 * @param view
	 */
	public void submit(View view) {

		if (TextUtils.isEmpty(catagory.getCurrentText())) {
			Toast.makeText(this, "物料类型不能为空", 0).show();
			return;
		}
		if (TextUtils.isEmpty(number.getText().toString())) {
			Toast.makeText(this, "数量不能为空", 0).show();
			return;
		}

		saveCurrentData();

		startActivity(new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.LoadSubmitActivity"));
		finish();

	}

	/**
	 * 储存信息
	 */
	public void saveCurrentData() {
		for (Integer num : data) {

			int vehicleID = map_Card.get(num);

			int materieTypeID = GlobleFields.getHashMap_MaterielType(this)
					.get(catagory.getCurrentText()).getID();

			m_Plan_Load plan_Load = new m_Plan_Load(0,
					GlobleFields.CurrentPlan.ID, vehicleID, materieTypeID,
					Integer.valueOf(number.getText().toString()), "", 0);

			// 添加一条数据到装车列表
			GlobleFields.reqLoad.ListM_Plan_Load.list.add(plan_Load);

		}
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

			View view = View.inflate(LoadChooseActivity.this,
					R.layout.item_back, null);

			// 车辆编号
			TextView number = (TextView) view.findViewById(R.id.number);
			number.setText("NO：" + data.get(position));

			// 车辆类型
			TextView type = (TextView) view.findViewById(R.id.type);

			HashMap<Integer, Integer> map = GlobleFields
					.getHashMap_Card(LoadChooseActivity.this);

			int vehicleId = map.get(data.get(position));

			List<m_VehicleType> VehicleTypes = CommonDbUtiles
					.querryByConditions(LoadChooseActivity.this,
							m_VehicleType.class, "ID=?",
							new String[] { vehicleId + "" }, null);

			type.setText("TYPE： " + VehicleTypes.get(0).vc_Name);

			return view;
		}
	}
}
