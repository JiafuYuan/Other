package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import android.os.Bundle;
import android.provider.ContactsContract.CommonDataKinds;
import android.text.Editable;
import android.text.TextWatcher;
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
import com.bestway.kj915.afinalnet.CommonXmlParser;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.custom.MyDropdownBox.ContentChangeListener;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.utils.TimerUtils;

public class LoadSubmitActivity extends BasicTitleActivity {

	private ReqLoad reqLoad;
	private List<m_Plan_Load> data;
	private ArrayList<String> list_MaterielType;
	private HashMap<String, m_MaterielType> map_MaterielType;
	private HashMap<Integer, Integer> map_Card;

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);

		title_text_view.setText("提交装车");
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_load_vehicle_complete);

		initData();
		initView();
	}

	private void initData() {
		reqLoad = GlobleFields.reqLoad;

		data = reqLoad.ListM_Plan_Load.list;

		list_MaterielType = GlobleFields.getList_MaterielType(this);

		map_MaterielType = GlobleFields.getHashMap_MaterielType(this);

		map_Card = GlobleFields.getHashMap_Card(this);

	}

	private void initView() {
		ListView lv = (ListView) findViewById(R.id.lv);

		lv.setAdapter(new SubmitAdapter());
	}

	public void restart(View view) {

		this.finish();

		GlobleFields.LOAD.finish();

	}

	public void submit(View view) {

		reqLoad.DateTime = TimerUtils.getTime();

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(reqLoad, new NetCallback() {

			@Override
			public String getCmdType() {

				return NetCallback.Flow_Load;

			}

			@Override
			public void doPrevious() {

			}

			/**
			 * 网络失败时候数据储存本地，有网络时候再次发送
			 */
			@Override
			public void onResult(String result) {

				if (result == FinalNClient.CONNET_FAILED
						|| result == FinalNClient.CONNET_INTERUPT
						|| result == FinalNClient.INIT_EXCEPTION) {

					Toast.makeText(LoadSubmitActivity.this, "网络异常，数据等待后台发送", 0)
							.show();
				}

			}

			/**
			 * 请求响应成功时候回调
			 */
			@Override
			public void onResult(String inner, boolean Result) {

				if (Result == true) {

					Toast.makeText(LoadSubmitActivity.this, "装车成功", 0).show();

				} else {
					Toast.makeText(LoadSubmitActivity.this, "装车失败，请重新填写装车", 0)
							.show();
				}

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

			}

		});

		this.finish();

		GlobleFields.LOAD.finish();

	}

	class SubmitAdapter extends BaseAdapter {

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
		public View getView(final int position, View convertView,
				ViewGroup parent) {

			View view = View.inflate(LoadSubmitActivity.this,
					R.layout.item_load_complete, null);
			// 车辆编号
			TextView bianhao = (TextView) view.findViewById(R.id.bianhao);
			int bian = data.get(position).VehicleID;
			for (Integer integer : map_Card.keySet()) {

				if (map_Card.get(integer) == bian) {
					bianhao.setText("车辆编号:"+integer + "");
					break;
				}
			}


			// 物料类型
			MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			catagory.setData(list_MaterielType);

			List<m_MaterielType> MaterielTypes = CommonDbUtiles
					.querryByConditions(LoadSubmitActivity.this,
							m_MaterielType.class, "ID=?",
							new String[] { data.get(position).MaterieTypeID + "" }, null);

			catagory.setContent(MaterielTypes.get(0).vc_Name);

			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void sameContent(String content) {

				}

				@Override
				public void onContentChange(String content) {

					data.get(position).MaterieTypeID = map_MaterielType
							.get(content).ID;
				}
			});

			EditText number = (EditText) view.findViewById(R.id.number);
			number.setText(data.get(position).n_Count+"");

			number.addTextChangedListener(new TextWatcher() {

				@Override
				public void onTextChanged(CharSequence s, int start,
						int before, int count) {

				}
  
				@Override
				public void beforeTextChanged(CharSequence s, int start,
						int count, int after) {

				}

				@Override
				public void afterTextChanged(Editable s) {
					data.get(position).n_Count = Integer.valueOf(s.toString());
				}
			});

			return view;
		}
	}

}
