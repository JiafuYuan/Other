package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.List;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.domain.req.load.LoadContainer;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.utils.TimerUtils;

public class QueryWaybillActivity extends BasicTitleActivity {

	private TextView tv_waybill;

	@Override
	public void doVarious() {
		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("装车");

		// 把刷新按钮替换为帮助
		title_image_flush.setVisibility(View.VISIBLE);

		title_image_flush.setImageResource(R.drawable.id_title_help);

		title_image_flush.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {

				GlobleFields.isLoadFromIndex = false;

				QueryWaybillActivity.this
						.startActivity(new Intent(
								"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadHelpActivity"));
				finish();
			}
		});
	}

	
	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_load_vehicles_query_waybill);

		// 运单号
		tv_waybill = (TextView) findViewById(R.id.waybill);
		
	}

	/**
	 * 进入查询运单页面
	 * 
	 * @param v
	 */
	public void querry(View v) {
		startActivityForResult(
				new Intent(
						"com.bestway.kj915.activity.home.loadvehilce.QuerryWaybillUiActivity"),
				0);
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);

		if (data != null && resultCode == 1)
			// 设置运单号

			tv_waybill.setText(data.getStringExtra("waybill_id"));

	}

	/**
	 * 进入扫描车界面
	 * 
	 * @param v
	 */
	public void next(View v) {

		String planID=tv_waybill.getText().toString();
		
		if (!TextUtils.isEmpty(planID)) {
			
			
			ReqLoad load = new ReqLoad();

			LoadContainer container = new LoadContainer();

			List<m_Plan_Load> list = new ArrayList<m_Plan_Load>();

			container.list = list;

			load.ListM_Plan_Load = container;

			// *************
			load.AddressID = 0;

			load.DepartmentID = 0;

			load.DateTime = TimerUtils.getTime();
			// *************

			load.UserID = GlobleFields.UserID;

			load.PlanID = GlobleFields.CurrentPlan.ID;
			// load.PlanID = 111;

			GlobleFields.reqLoad = load;

			finish();
			Intent intent = new Intent(
					"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadNfcActivity");
			startActivity(intent);
			
		} else {
			Toast.makeText(this, "运单号不可以为空", 1).show();
		}
		
	}

}
