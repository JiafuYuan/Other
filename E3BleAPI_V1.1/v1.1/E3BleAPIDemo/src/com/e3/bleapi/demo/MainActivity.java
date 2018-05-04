package com.e3.bleapi.demo;

import java.util.Calendar;
import java.util.regex.Pattern;

import com.e3.ble.model.DeviceInfo;
import com.e3.bleapi.demo.frag.AllFragment;
import com.e3.bleapi.demo.frag.E3Fragment;
import com.e3.bleapi.demo.frag.GroupOneFragment;
import com.e3.bleapi.demo.frag.GroupTwoFragment;
import com.e3.bleapi.demo.model.BleDevice;
import com.e3.bleapi.demo.model.BleZone;

import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.Intent;
import android.os.Bundle;
import android.text.InputFilter;
import android.text.Spanned;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.CompoundButton;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity implements MyUICallback{
	public static final String TAG = MainActivity.class.getName();
	public static final int REQUEST_ADD_DEVICE_CODE = 10;

	private RadioGroup radioGroup;
	private RadioButton allGroup, oneGroup, twoGroup;
	private Switch groupSwitch;
	private SeekBar groupDim;
	private TextView groupControl;

	private E3Fragment currentFragment;
	
	private E3BleApplication application;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		enableBT();
		
		application = (E3BleApplication)getApplication();
		application.myApi.setCallback(this);

		initView();
		// initDatas();
		switchToFragment(new AllFragment());
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int id = item.getItemId();
		if (id == R.id.action_add_device) {
			Intent i = new Intent(MainActivity.this, AddDeviceActivity.class);
			startActivityForResult(i, REQUEST_ADD_DEVICE_CODE);

		}else if (id == R.id.action_add_profile) {
			application.myApi.sendAddProfileCmd(getControlTarget(), 1);
		} else if (id == R.id.action_apply_profile) {
			application.myApi.sendApplyProfileCmd(getControlTarget(), 1);
		} else if (id == R.id.action_del_profile) {
			application.myApi.sendRemoveProfileByIdCmd(getControlTarget(), 1);
		} else if (id == R.id.action_set_time) {
			Calendar c = Calendar.getInstance();

			Log.e("系统时间",
					c.get(Calendar.YEAR) + "-" + (c.get(Calendar.MONTH) + 1)
							+ "-" + c.get(Calendar.DAY_OF_MONTH) + " "
							+ c.get(Calendar.HOUR_OF_DAY) + ":"
							+ c.get(Calendar.MINUTE) + ":"
							+ c.get(Calendar.SECOND));

			application.myApi.sendSetTimeCmd(getControlTarget(), c.get(Calendar.YEAR),
					c.get(Calendar.MONTH) + 1, c.get(Calendar.DAY_OF_MONTH),
					c.get(Calendar.HOUR_OF_DAY), c.get(Calendar.MINUTE),
					c.get(Calendar.SECOND));
		} else if (id == R.id.action_get_time) {
			application.myApi.sendGetTimeCmd(getControlTarget());
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == REQUEST_ADD_DEVICE_CODE) {
			if (data != null) {
				switch (data.getIntExtra("groupid",
						E3BleApplication.GROUP_All_ID)) {
				case E3BleApplication.GROUP_All_ID:
					// allGroup.performClick();
					allGroup.setSelected(true);
					switchToFragment(new AllFragment());
					break;
				case E3BleApplication.GROUP_ONE_ID:
					oneGroup.performClick();
					break;
				case E3BleApplication.GROUP_TWO_ID:
					twoGroup.performClick();
					break;
				default:
					break;
				}
			}
		}
		application.myApi.setCallback(this);
		super.onActivityResult(requestCode, resultCode, data);
	}

	public void switchToFragment(E3Fragment newFrag) {
		FragmentManager fm = getFragmentManager();
		FragmentTransaction ft = fm.beginTransaction();
		ft.replace(R.id.container, newFrag);
		ft.commit();
		currentFragment = newFrag;
	}

	Pattern hexPattern = Pattern.compile("/^[0-9a-fA-F]$/");
	String hexString = "0123456789abcdefABCDEF";
	InputFilter inputFilter_moodMsg = new InputFilter() {
		@Override
		public CharSequence filter(CharSequence source, int start, int end,
				Spanned dest, int dstart, int dend) {

			if (dest.length() >= 18) {
				return "";
			}

			if (source.length() > 18) {
				source = source.subSequence(0, 18);
			}

			if (source.length() != 0) {

				CharSequence s = source.subSequence(source.length() - 1, 1);

				if (hexString.contains(s)) {
					return source;
				} else {
					return source.subSequence(0, source.length() - 1);
				}
			} else {
				return "";
			}

		}
	};

	private void showMessage(String msg) {
		Toast.makeText(getBaseContext(), msg, Toast.LENGTH_SHORT).show();
	}

	private void initView() {
		radioGroup = (RadioGroup) findViewById(R.id.radioGroupLayout);
		allGroup = (RadioButton) findViewById(R.id.groupAll);
		oneGroup = (RadioButton) findViewById(R.id.groupOne);
		twoGroup = (RadioButton) findViewById(R.id.groupTwo);
		groupSwitch = (Switch) findViewById(R.id.groupOnOff);
		groupDim = (SeekBar) findViewById(R.id.groupDim);
		groupControl = (TextView) findViewById(R.id.groupControl);

		allGroup.setChecked(true);

		radioGroup.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(RadioGroup group, int checkedId) {
				switch (checkedId) {
				case R.id.groupAll:
					allGroup.setSelected(true);
					// Toast.makeText(getApplicationContext(),
					// "Group Id:" + E3BleApplication.GROUP_All_ID,
					// Toast.LENGTH_SHORT).show();
					switchToFragment(new AllFragment());
					break;
				case R.id.groupOne:
					oneGroup.setSelected(true);
					// Toast.makeText(getApplicationContext(),
					// "Group Id:" + E3BleApplication.GROUP_ONE_ID,
					// Toast.LENGTH_SHORT).show();
					switchToFragment(new GroupOneFragment());
					break;
				case R.id.groupTwo:
					twoGroup.setSelected(true);
					// Toast.makeText(getApplicationContext(),
					// "Group Id:" + E3BleApplication.GROUP_TWO_ID,
					// Toast.LENGTH_SHORT).show();
					switchToFragment(new GroupTwoFragment());
					break;

				default:
					break;
				}
			}
		});

		groupSwitch
				.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {

					@Override
					public void onCheckedChanged(CompoundButton buttonView,
							boolean isChecked) {
						if (isChecked) {
							application.myApi.sendOnOffCmd(getControlTarget(),isChecked);
							// Toast.makeText(getApplicationContext(), "Open:" +
							// isChecked, Toast.LENGTH_SHORT).show();
						} else {
							application.myApi.sendOnOffCmd(getControlTarget(),isChecked);
							// Toast.makeText(getApplicationContext(), "Close:"
							// + isChecked, Toast.LENGTH_SHORT).show();
						}
					}

				});

		groupDim.setOnSeekBarChangeListener(new OnSeekBarChangeListener() {

			@Override
			public void onStopTrackingTouch(SeekBar seekBar) {
				// TODO Auto-generated method stub
				// Toast.makeText(getApplicationContext(),
				// "Dim:" + seekBar.getProgress(), Toast.LENGTH_SHORT)
				// .show();
				application.myApi.sendAdjustCmd(getControlTarget(),seekBar.getProgress(), 50, 50, 0, 0, 0, 0);
			}

			@Override
			public void onStartTrackingTouch(SeekBar seekBar) {
				// TODO Auto-generated method stub

			}

			@Override
			public void onProgressChanged(SeekBar seekBar, int progress,
					boolean fromUser) {
				// TODO Auto-generated method stub

			}
		});
	}

	private int getControlTarget() {
		int target = E3BleApplication.GROUP_All_ID;
		switch (radioGroup.getCheckedRadioButtonId()) {
		case R.id.groupAll:
			target = E3BleApplication.GROUP_All_ID;
			break;
		case R.id.groupOne:
			target = E3BleApplication.GROUP_ONE_ID;
			break;
		case R.id.groupTwo:
			target = E3BleApplication.GROUP_TWO_ID;
			break;

		default:
			break;
		}

		Log.e(TAG, "target:" + target);
		return target;
	}

	private void enableBT() {
		BluetoothAdapter mBluetoothAdapter = BluetoothAdapter
				.getDefaultAdapter();
		if (!mBluetoothAdapter.isEnabled()) {
			// if (!ws.getBleWrapper().isBtEnabled()) {
			Intent intentBtEnabled = new Intent(
					BluetoothAdapter.ACTION_REQUEST_ENABLE);
			int REQUEST_ENABLE_BT = 1;
			startActivityForResult(intentBtEnabled, REQUEST_ENABLE_BT);
		}

	}

	private void initDatas() {
		for (int i = 0; i < 5; i++) {
			BleDevice d = new BleDevice();
			d.setAddr(0xff + i);
			d.setDesc("灯" + i);
			d.setMacAddr("FF:FF:FF:FF:FF:F" + i);

			E3BleApplication.rootZone.addBleDevice(d);

			if (i % 2 == 0) {
				BleZone z = E3BleApplication.rootZone
						.getSubZoneById(E3BleApplication.GROUP_ONE_ID);
				z.addBleDevice(d);
			} else {
				BleZone z = E3BleApplication.rootZone
						.getSubZoneById(E3BleApplication.GROUP_TWO_ID);
				z.addBleDevice(d);
			}
		}
	}

	@Override
	public void onUIConnected(String macAddress) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUIConnectedFailed(String macAddress, int code) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUIAddToMeshSucceeded(String macAddress, int code) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUIAddToMeshFailed(String macAddress, int code) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUIConnectionLost() {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUINewBleDeviceFound(BluetoothDevice device, int rssi,
			DeviceInfo dInfo) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void onUIDeviceStatusChanged(final byte addr, boolean isOnline,
			final byte level, byte temColor) {
		// TODO Auto-generated method stub
		Log.e(TAG, "onUIDeviceStatusChanged");
		this.runOnUiThread(new Runnable() {
			
			@Override
			public void run() {
				// TODO Auto-generated method stub
				application.updateBleDevice(addr, level);
				currentFragment.updateDataStatus();
			}
		});
		
	}


}
