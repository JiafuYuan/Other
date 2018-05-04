package com.bestway.kj915.activity.home.apply;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageButton;
import android.widget.ImageView;

import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;

public class ApplyActivity extends BasicTitleActivity implements
		OnClickListener {

	public View common_title;// 共同的标题
	public ImageView title_image_back;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_apply);

		ImageButton ib1 = (ImageButton) findViewById(R.id.ib1);
		ImageButton ib2 = (ImageButton) findViewById(R.id.ib2);

		ib1.setOnClickListener(this);
		ib2.setOnClickListener(this);

	}

	@Override
	public void onClick(View v) {
		Intent intent = null;
		switch (v.getId()) {

		case R.id.ib1:
			intent = new Intent(
					"com.bestway.kj915.activity.home.apply.Apply_GoodsActivity");
			break;
		case R.id.ib2:
			intent = new Intent(
					"com.bestway.kj915.activity.home.apply.Apply_VehiclesActivity");
			break;

		}

		startActivity(intent);
	}

	@Override
	public void doVarious() {

	}

}
