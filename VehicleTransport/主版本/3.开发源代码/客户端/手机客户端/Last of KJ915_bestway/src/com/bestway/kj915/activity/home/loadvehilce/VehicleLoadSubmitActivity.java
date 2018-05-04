package com.bestway.kj915.activity.home.loadvehilce;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ�������ι�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-10-10 ����2:58:16
 */
import java.util.List;

import org.w3c.dom.Text;

import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.TextureView;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.utils.TimerUtils;

public class VehicleLoadSubmitActivity extends BasicTitleActivity {

	private ReqLoad reqLoad;
	private List<m_Plan_Load> data;
	private MyDropdownBox drop_box_address;

	@Override
	public void doVarious() {

		title_text_view.setVisibility(View.VISIBLE);

		title_text_view.setText("�ύװ��");

	}

	@Override
	public void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_load_vehicle_submit);

		initData();
		initView();

	}

	/**
	 * ��ʼ������
	 */
	private void initData() {

		reqLoad = GlobleFields.reqLoad;

		data = reqLoad.ListM_Plan_Load.list;

	}

	/**
	 * ��ʼ������
	 */
	private void initView() {

		ListView lv = (ListView) findViewById(R.id.lv);

		MyAdapter adapter = new MyAdapter();

		lv.setAdapter(adapter);

		drop_box_address = (MyDropdownBox) findViewById(R.id.drop_box_address);

		drop_box_address.setData(GlobleFields.getList_Address(this));

	}

	// �ύ����
	public void submit(View view) {
		String address = drop_box_address.getCurrentText().trim();

		if (TextUtils.isEmpty(address)) {

			Toast.makeText(this, "���Ų���Ϊ��", 0).show();

			return;

		}

		reqLoad.DateTime = TimerUtils.getTime();

		reqLoad.AddressID = GlobleFields.getHashMap_Address(this).get(address).ID;

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
			 * ����ʧ��ʱ�����ݴ��汾�أ�������ʱ���ٴη���
			 */
			@Override
			public void onResult(String result) {

				if (result == FinalNClient.CONNET_FAILED
						|| result == FinalNClient.CONNET_INTERUPT
						|| result == FinalNClient.INIT_EXCEPTION) {

					Toast.makeText(VehicleLoadSubmitActivity.this,
							"�����쳣�����ݵȴ���̨����", 0).show();
				}

			}

			/**
			 * ������Ӧ�ɹ�ʱ��ص�
			 */
			@Override
			public void onResult(String inner, boolean Result) {

				if (Result == true) {

					Toast.makeText(VehicleLoadSubmitActivity.this, "װ���ɹ�", 0)
							.show();

				} else {
					Toast.makeText(VehicleLoadSubmitActivity.this,
							"װ��ʧ�ܣ���������дװ��", 0).show();
				}

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

			}

		});

		finish();

	}

	public class MyAdapter extends BaseAdapter {

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

			View view;

			if (convertView != null) {

				view = convertView;

			} else {

				view = View.inflate(VehicleLoadSubmitActivity.this,
						R.layout.item_load_vehicle, null);
			}

			TextView tv_VehicleID = (TextView) view
					.findViewById(R.id.tv_VehicleID);
			TextView tv_MaterieTypeID = (TextView) view
					.findViewById(R.id.tv_MaterieTypeID);
			TextView tv_n_Count = (TextView) view.findViewById(R.id.tv_n_Count);

			m_Plan_Load plan_Load = data.get(position);

			/**
			 * ����id�����ݿ��в�ѯ������ʾ
			 */
			List<m_MaterielType> materielTypes = CommonDbUtiles
					.querryByConditions(VehicleLoadSubmitActivity.this,
							m_MaterielType.class, "ID=?",
							new String[] { plan_Load.MaterieTypeID + "" }, null);

			tv_MaterieTypeID.setText(materielTypes.get(0).vc_Name);

			tv_VehicleID.setText(plan_Load.VehicleID + "");

			tv_n_Count.setText(plan_Load.n_Count + "");

			return view;
		}

	}

}
