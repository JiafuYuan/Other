package com.bestway.kj915.activity.home;

import java.util.ArrayList;
import java.util.List;

import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.CommonXmlParser;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.ReqVehicleDistribute;
import com.bestway.kj915.domain.res.distribute.OutGetVehicleDistributedModel;
import com.bestway.kj915.domain.res.distribute.v_AreaVehicle;

public class VehicleDistributionActivity extends BasicTitleActivity {

	private GridView gridview;
	private List<v_AreaVehicle> areaVehicles = new ArrayList<v_AreaVehicle>();
	private DistributeAdapter adapter;

	@Override
	public void doVarious() {
		title_text_view.setText("车辆分布");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_vehicle_distribute);

		gridview = (GridView) findViewById(R.id.gridview);

		adapter = new DistributeAdapter();

		gridview.setAdapter(adapter);
		
		initData();
		initView();

	}

	private void initData() {
		

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqVehicleDistribute("李胜渠"), new NetCallback() {

			@Override
			public void onResult(String inner, boolean Result) {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public String getCmdType() {
				return NetCallback.Data_GetVehicleDistributed;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {
				System.out.println(entireXml);
				OutGetVehicleDistributedModel model = (OutGetVehicleDistributedModel) CommonXmlParser
						.parserXml(inner, new OutGetVehicleDistributedModel());

				areaVehicles = model.Listv_AreaVehicle.list;
				if (areaVehicles == null || areaVehicles.size() < 1) {
					Toast.makeText(VehicleDistributionActivity.this, "没有获取到数据",
							0).show();
				}

				adapter.notifyDataSetChanged();
			}
		});
	}

	private void initView() {

		
	}

	class DistributeAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return areaVehicles.size();
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

			View view = null;

			if (convertView == null) {
				view = View.inflate(VehicleDistributionActivity.this,
						R.layout.item_car_fenbu, null);
			} else {
				view = convertView;
			}

			TextView weizhi = (TextView) view
					.findViewById(R.id.gridview_text);
			weizhi.setText(areaVehicles.get(position).AreaName);
			
			TextView zhong = (TextView) view
					.findViewById(R.id.gridview_number_zhong);
			TextView kong = (TextView) view
					.findViewById(R.id.gridview_number_kong);

			zhong.setText("重车" + areaVehicles.get(position).WeightVehicle + "辆");
			
			kong.setText("空车" + areaVehicles.get(position).EmptyVehicle + "辆");

			return view;

		}
	}
}
