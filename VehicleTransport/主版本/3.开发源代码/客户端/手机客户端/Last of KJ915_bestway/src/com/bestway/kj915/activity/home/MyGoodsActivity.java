package com.bestway.kj915.activity.home;

import java.io.IOException;
import java.io.InputStream;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ExpandableListView;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.ReqPlanDetail;

public class MyGoodsActivity extends BasicTitleActivity {

	@Override
	public void doVarious() {
		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("我的物料");
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_mygoods);
		
		initData();
		
		initView();

	}

	private void initData() {
		
		FinalNClient client = FinalNClient.getInstance();
		
		ReqPlanDetail detail = new ReqPlanDetail(null, 0, 16666,
				GlobleFields.UserID);
		
		detail.IsApplyDepartment = true;

		client.sendMessage(detail, new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.Data_GetPlanDetail;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public void onResult(String inner, boolean Result) {
				
				
				System.out.println(inner);
			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

			}

		});
	}

	private void initView() {

		ExpandableListView ex_lv = (ExpandableListView) findViewById(R.id.ex_lv);

		ex_lv.setAdapter(new MyGoodAdapter());

	}

	class MyGoodAdapter extends BaseExpandableListAdapter {

		@Override
		public Object getChild(int groupPosition, int childPosition) {
			return null;
		}

		@Override
		public long getChildId(int groupPosition, int childPosition) {
			return 0;
		}

		@Override
		public View getChildView(int groupPosition, int childPosition,
				boolean isLastChild, View convertView, ViewGroup parent) {
			return View.inflate(MyGoodsActivity.this, R.layout.item_mygoods_item, null);
		}

		@Override
		public int getChildrenCount(int groupPosition) {
			return 6;
		}

		@Override
		public Object getGroup(int groupPosition) {
			return null;
		}

		@Override
		public int getGroupCount() {
			return 10;
		}

		@Override
		public long getGroupId(int groupPosition) {
			return 0;
		}

		@Override
		public View getGroupView(int groupPosition, boolean isExpanded,
				View convertView, ViewGroup parent) {

			return View.inflate(MyGoodsActivity.this, R.layout.item_mygoods,
					null);
		}

		@Override
		public boolean hasStableIds() {
			return false;
		}

		@Override
		public boolean isChildSelectable(int groupPosition, int childPosition) {

			return false;
		}

	}
}
