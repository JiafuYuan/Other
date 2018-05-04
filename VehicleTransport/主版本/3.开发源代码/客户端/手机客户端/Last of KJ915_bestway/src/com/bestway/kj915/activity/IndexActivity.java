package com.bestway.kj915.activity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnCancelListener;
import android.content.DialogInterface.OnClickListener;
import android.content.DialogInterface.OnDismissListener;
import android.content.DialogInterface.OnKeyListener;
import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.TextView;

import com.bestway.kj915.R;
import com.bestway.kj915.afinalnet.CommonXmlParser;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.ReqFlowPath;
import com.bestway.kj915.domain.res.OutFlowPathModel;
import com.bestway.kj915.utils.LogUtils;

public class IndexActivity extends BasicActivity {

	private List<Integer> imgs;
	private OutFlowPathModel model;
	private List<String> titles;
	private List<String> actions;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_index);

		// 节点控制
		flowPathControl();

	}

	/**
	 * 流程节点控制
	 */
	private void flowPathControl() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqFlowPath(), new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.GetFlowPath;
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

				model = (OutFlowPathModel) CommonXmlParser.parserXml(inner,
						new OutFlowPathModel());
				// 初始化数据
				initData();

				// 给布局界面增加一些点击事件
				initView();

			}

		});

	}

	private void initView() {
		IndexAdapter adapter = new IndexAdapter();
		GridView gv_main = (GridView) findViewById(R.id.gv_main);
		gv_main.setAdapter(adapter);

		// 增加点击事件
		gv_main.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {

				LogUtils.careLog(position);
				startActivity(new Intent(actions.get(position)));

			}
		});

		RadioGroup group = (RadioGroup) findViewById(R.id.rg);

		group.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(RadioGroup group, int checkedId) {

				switch (checkedId) {

				case R.id.rb_1:// 我的物料
					startActivity(new Intent(//
							"com.bestway.kj915.activity.home.MyGoodsActivity"));// com.bestway.kj915.activity.home.loadvehilce.VehicleLoadHelpActivity
					break;
				case R.id.rb_2:// 车辆分布
					startActivity(new Intent(
							"com.bestway.kj915.activity.home.VehicleDistributionActivity"));
					break;
				case R.id.rb_3:// 设置
					startActivity(new Intent(
							"com.bestway.kj915.activity.home.SettingActivity"));
					break;
				}

				RadioButton button = (RadioButton) group
						.findViewById(checkedId);

				button.setChecked(false);
			}

		});
	}

	/**
	 * 初始化主界面的数据
	 */
	private void initData() {
		int[] all_imgs = new int[] { R.drawable.index_sq,
				R.drawable.index_wdhw, R.drawable.index_zxh,
				R.drawable.index_clfb, R.drawable.index_clxx,
				R.drawable.index_sz };

		String[] all_titles = new String[] { "申请", "供车", "装车", "交接车", "卸车",
				"还车" };

		String[] all_actions = new String[] {
				"com.bestway.kj915.activity.home.ApplyActivity",
				"com.bestway.kj915.activity.home.supply.SupplyVehicleActivity",// com.bestway.kj915.activity.home.MyGoodsActivity
				"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadHelpActivity",// com.bestway.kj915.activity.home.HandleGoodsActivity
				"com.bestway.kj915.activity.home.handover.HandoverNFCActivity",// com.bestway.kj915.activity.home.handover.HandoverAcitvity
				"com.bestway.kj915.activity.home.unloadvehicle.UnLoadVehicleNFCActivity",
				"com.bestway.kj915.activity.home.backvehicle.BackVehicleActivityNFCActivity" };// com.bestway.kj915.activity.home.SettingActivity

		imgs = new ArrayList<Integer>();

		titles = new ArrayList<String>();

		actions = new ArrayList<String>();

		for (int img : all_imgs) {
			imgs.add(img);
		}
		for (String img : all_titles) {
			titles.add(img);
		}
		for (String action : all_actions) {
			actions.add(action);
		}

		if (!model.Apply) {
			imgs.remove(Integer.valueOf(all_imgs[0]));
			titles.remove(all_titles[0]);
			actions.remove(all_actions[0]);
		}

		if (!model.Give) {
			imgs.remove(Integer.valueOf(all_imgs[1]));
			titles.remove(all_titles[1]);
			actions.remove(all_actions[1]);
		}

		if (!model.Load) {
			imgs.remove(Integer.valueOf(all_imgs[2]));
			titles.remove(all_titles[2]);
			actions.remove(all_actions[2]);
		}
		if (!model.Handover) {
			imgs.remove(Integer.valueOf(all_imgs[3]));
			titles.remove(all_titles[3]);
			actions.remove(all_actions[3]);
		}

		if (!model.UnLoad) {
			imgs.remove(Integer.valueOf(all_imgs[4]));
			titles.remove(all_titles[4]);
			actions.remove(all_actions[4]);
		}

		/*
		 * if (!model.Back) { imgs.remove(Integer.valueOf(all_imgs[5]));
		 * titles.remove(all_titles[5]); actions.remove(all_actions[5]); }
		 */

	}

	class IndexAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return imgs.size();
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

			View view = View.inflate(IndexActivity.this, R.layout.index_item,
					null);
			ImageView imageView = (ImageView) view
					.findViewById(R.id.iv_main_icon);

			imageView.setImageResource(imgs.get(position));

			TextView textView = (TextView) view.findViewById(R.id.tv_main_name);

			textView.setText(titles.get(position));

			return view;

		}

	}

	@Override
	public void onBackPressed() {

		AlertDialog dialog = new AlertDialog.Builder(this).setTitle("确认退出应用")
				.setMessage("确定吗？")
				.setPositiveButton("是", new OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {
						dialog.dismiss();
						finish();
					}
				}).setNegativeButton("否", new OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {
						dialog.dismiss();
					}
				}).show();

	}

}
