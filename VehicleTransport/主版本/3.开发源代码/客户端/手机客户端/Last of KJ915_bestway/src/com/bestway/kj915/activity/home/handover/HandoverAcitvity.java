package com.bestway.kj915.activity.home.handover;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.activity.home.unloadvehicle.UnLoadVehicleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.custom.MyDropdownBox.ContentChangeListener;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.req.handover.ReqHandover;
import com.bestway.kj915.domain.req.handover.m_Plan_Handover;
import com.bestway.kj915.domain.req.unload.ReqUnLoad;
import com.bestway.kj915.domain.req.unload.UnloadContainer;
import com.bestway.kj915.domain.req.unload.m_Plan_UnLoad;
import com.bestway.kj915.utils.TimerUtils;

public class HandoverAcitvity extends BasicTitleActivity {

	private Integer number;
	private ArrayList<String> list_MaterielType;
	private HashMap<String, String> map_MaterielUnit;
	private HashMap<String, m_MaterielType> map_MaterielType;
	private MyDropdownBox catagory;
	private TextView count;
	private MyDropdownBox destination;

	@Override
	public void doVarious() {
		title_text_view.setVisibility(View.VISIBLE);

		title_text_view.setText("交接车");
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_unload);

		initData();
		initView();
	}

	private void initData() {
		number = (Integer) getIntent().getExtras().get("number");

		list_MaterielType = GlobleFields.getList_MaterielType(this);

		map_MaterielType = GlobleFields.getHashMap_MaterielType(this);

		map_MaterielUnit = GlobleFields.getHashMap_MaterielUnit(this);

	}

	private void initView() {
		// 车辆编号
		TextView tv_number = (TextView) findViewById(R.id.tv_number);
		tv_number.setText("NO: " + number);

		// 物量单位
		final TextView unit = (TextView) findViewById(R.id.unit);

		// 物料类型
		catagory = (MyDropdownBox) findViewById(R.id.catagory);
		catagory.setData(list_MaterielType);
		catagory.setOnContentChangeListener(new ContentChangeListener() {

			@Override
			public void sameContent(String content) {

			}

			@Override
			public void onContentChange(String content) {
				// 设置物量单位
				unit.setText(map_MaterielUnit.get(content));
			}
		});

		// 数量
		count = (TextView) findViewById(R.id.count);

		// 地点
		destination = (MyDropdownBox) findViewById(R.id.destination);
		destination.setData(GlobleFields.getList_Address(this));

	}

	public void submit(View view) {
		if (TextUtils.isEmpty(destination.getCurrentText().toString())) {
			Toast.makeText(this, "地点属于必选项", 0).show();
			return;
		}

		if (TextUtils.isEmpty(catagory.getCurrentText())) {
			Toast.makeText(this, "物料类型属于必选项", 0).show();
			return;
		}

		if (TextUtils.isEmpty(count.getText().toString())) {
			Toast.makeText(this, "数量不可以为空", 0).show();
			return;
		}
		View v = View.inflate(this, R.layout.toast1, null);
		TextView tv_num = (TextView) v.findViewById(R.id.tv_num);
		TextView tv_wuliao = (TextView) v.findViewById(R.id.tv_wuliao);
		tv_num.setText("车辆编号:　" + number);
		tv_wuliao.setText(catagory.getCurrentText() + "    "
				+ count.getText().toString() + " "
				+ map_MaterielUnit.get(catagory.getCurrentText()));

		new AlertDialog.Builder(this).setTitle("是否确定提交")
				.setIcon(android.R.drawable.ic_dialog_info).setView(v)
				.setPositiveButton("确定", new OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {

						ReqHandover handover = new ReqHandover();
						handover.AddressID = GlobleFields.getHashMap_Address(
								HandoverAcitvity.this).get(
								destination.getCurrentText()).ID;
						handover.UserID = GlobleFields.UserID;
						handover.DateTime = TimerUtils.getTime();
						final FinalNClient client = FinalNClient.getInstance();

						List<m_Plan_Handover> list = new ArrayList<m_Plan_Handover>();
						m_Plan_Handover handover2 = new m_Plan_Handover();
						handover2.AddressID = GlobleFields.getHashMap_Address(
								HandoverAcitvity.this).get(
								destination.getCurrentText()).ID;
						handover2.VehicleID = GlobleFields.getHashMap_Card(
								HandoverAcitvity.this).get(number);

						client.sendMessage(handover, new NetCallback() {

							@Override
							public String getCmdType() {

								return NetCallback.Flow_Handover;

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
							public void onResult(String entireXml,
									String inner, boolean Result) {

								System.out.println(entireXml);

							}

						});

					}
				}).setNegativeButton("取消", null).show();
	}
}
