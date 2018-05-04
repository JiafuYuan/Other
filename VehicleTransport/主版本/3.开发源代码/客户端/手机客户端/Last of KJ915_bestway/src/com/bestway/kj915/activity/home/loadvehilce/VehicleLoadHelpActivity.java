package com.bestway.kj915.activity.home.loadvehilce;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.CheckBox;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.utils.SharePreferenceUtils_config;

/**
 * װ��
 * 
 * @author gaga
 * 
 */
public class VehicleLoadHelpActivity extends BasicTitleActivity {

	@Override
	public void doVarious() {

	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		SharedPreferences sp = getSharedPreferences("config",
				Context.MODE_PRIVATE);
		// ȷ���Ƿ���ʾ����ҳ��
		boolean showGuide = sp.getBoolean("show_help_Guide", true);

		if (showGuide || !GlobleFields.isLoadFromIndex) {
			System.out.println("showGuide");

			setContentView(R.layout.activity_load_vehicle_help);

			// ��������԰�����ť����ҵ�ǰ����
			if (!GlobleFields.isLoadFromIndex && !showGuide) {

				((CheckBox) findViewById(R.id.checkbox)).setChecked(true);
				// ��ԭ
				GlobleFields.isLoadFromIndex = true;
			}

		} else {

			startActivity(new Intent(
					"com.bestway.kj915.activity.home.loadvehilce.QueryWaybillShowResultActivity"));
			finish();
		}

	}

	public void nomore(View view) {

		SharePreferenceUtils_config.edit_Boolean(this, "show_help_Guide",
				!((CheckBox) view).isChecked());
	}

	public void next(View view) {
		startActivity(new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.QueryWaybillActivity"));
		finish();
	}

}
