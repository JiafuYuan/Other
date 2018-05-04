package com.e3.bleapi.demo;

import java.util.ArrayList;

import com.e3.ble.model.DeviceInfo;
import com.e3.bleapi.demo.adapter.BluetoothDeviceAdapter;
import com.e3.bleapi.demo.model.BleDevice;
import com.e3.bleapi.demo.model.BleZone;
import com.e3.bleapi.demo.widget.LoadingDialog;

import android.app.Activity;
import android.bluetooth.BluetoothDevice;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.RadioGroup.OnCheckedChangeListener;

public class AddDeviceActivity extends Activity implements MyUICallback{
	private static final int RESULT_ADD_FINISH_CODE = 100;
	private static final String TAG = AddDeviceActivity.class.getName();
	private static final boolean isSupportPsd = true;
	
	private static final int STEP_SCAN = 1;
	private static final int STEP_CHECK = 2;
	private static final int STEP_PICKUP = 3;
	
	//scan list
	private ListView deviceList;
	
	//check info
	private ViewGroup checkLayout;
	private Switch checkOnOff;
	private ImageView checkImg;
	
	//pickup info
	private ViewGroup pickupLayout;
	private RadioGroup pickupGroupLayout;
	private RadioButton pickupAllGroup,pickupOneGroup,pickupTwoGroup;
	
	private TextView nextTv;
	
	private E3BleApplication application;
	private BluetoothDeviceAdapter adapter ;
	private int step = 1;
	
//	private E3BleAPI bleApi;
	
	private LoadingDialog loadingDailog ;
	private Handler uiHandler = new Handler();
	
	private BleDevice selectedDevice;
	private BleZone selectedZone;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_add_device);
		
		application = (E3BleApplication)getApplication();
		application.myApi.setCallback(this);
		init();
	}
	
	private void init(){
		adapter = new BluetoothDeviceAdapter(getApplicationContext(), E3BleApplication.SCANLIST);
		deviceList = (ListView)findViewById(R.id.scan_device_listview);
		deviceList.setAdapter(adapter);
		deviceList.setOnItemClickListener(adapter);
		if(step == STEP_SCAN){
			deviceList.setVisibility(View.VISIBLE);
		}
		
		checkLayout = (ViewGroup)findViewById(R.id.check_layout);
		checkImg 	= (ImageView)findViewById(R.id.check_bulb);
		checkOnOff = (Switch)findViewById(R.id.checkOnOff);
		checkLayout.setVisibility(View.GONE);
		
		checkOnOff.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
			@Override
			public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
				// TODO Auto-generated method stub
				if(isChecked){
					application.myApi.sendOnOffCmd(selectedDevice.getAddr(), isChecked);
					Toast.makeText(getApplicationContext(), "Open:" + isChecked, Toast.LENGTH_SHORT).show();
				}else{
					application.myApi.sendOnOffCmd(selectedDevice.getAddr(), isChecked);
					Toast.makeText(getApplicationContext(), "Close:" + isChecked, Toast.LENGTH_SHORT).show();
				}
			}
		});
		
		checkImg.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				application.myApi.sendIdentifyCmd(selectedDevice.getAddr());
			}
		});
		
		pickupLayout = (ViewGroup)findViewById(R.id.pickup_layout);
		pickupGroupLayout = (RadioGroup)findViewById(R.id.pickupGroupLayout);
		pickupAllGroup = (RadioButton)findViewById(R.id.pickupGroupAll);
		pickupOneGroup = (RadioButton)findViewById(R.id.pickupGroupOne);
		pickupTwoGroup = (RadioButton)findViewById(R.id.pickupGroupTwo);		
		pickupLayout.setVisibility(View.GONE);
		pickupAllGroup.setSelected(true);
		selectedZone = E3BleApplication.rootZone;
		pickupGroupLayout.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(RadioGroup group, int checkedId) {
				switch (checkedId) {
				case R.id.pickupGroupAll:
					pickupAllGroup.setSelected(true);
					selectedZone = E3BleApplication.rootZone;
					Toast.makeText(getApplicationContext(), "Group Id:" + E3BleApplication.GROUP_All_ID, Toast.LENGTH_SHORT).show();
					break;
				case R.id.pickupGroupOne:
					pickupOneGroup.setSelected(true);
					selectedZone = E3BleApplication.rootZone.getSubZoneById(E3BleApplication.GROUP_ONE_ID);
					Toast.makeText(getApplicationContext(), "Group Id:" + E3BleApplication.GROUP_ONE_ID, Toast.LENGTH_SHORT).show();
					break;
				case R.id.pickupGroupTwo:
					pickupTwoGroup.setSelected(true);
					selectedZone = E3BleApplication.rootZone.getSubZoneById(E3BleApplication.GROUP_TWO_ID);
					Toast.makeText(getApplicationContext(), "Group Id:" + E3BleApplication.GROUP_TWO_ID, Toast.LENGTH_SHORT).show();
					break;

				default:
					break;
				}
			}
		});
		
		nextTv = (TextView)findViewById(R.id.add_device_next);
		nextTv.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				if(step == STEP_SCAN){
					selectedDevice = adapter.getSelectedDevice();
					if(selectedDevice == null){
						Toast.makeText(AddDeviceActivity.this, "请选择要添加的设备", Toast.LENGTH_SHORT).show();
						return;
					}
					
					application.myApi.connect(selectedDevice.getMacAddr());
					if(loadingDailog == null){
						loadingDailog = new LoadingDialog(AddDeviceActivity.this,R.style.loadingDialogStyle,"连接设备...");
						loadingDailog.setCancelable(false);
					}else{
						loadingDailog.setMessage("连接设备...");
						loadingDailog.setCancelable(false);
					}
					loadingDailog.show();
				}else if(step == STEP_CHECK){
					
					if(isSupportPsd){
//						bleApi.addToMesh();
						application.myApi.setMeshnameAndPassword("E3Vcb4qxm1g0", "345678");
						if(loadingDailog == null){
							loadingDailog = new LoadingDialog(AddDeviceActivity.this,R.style.loadingDialogStyle,"连接设备...");
							loadingDailog.setCancelable(false);
						}else{
							loadingDailog.setMessage("设备入网...");
							loadingDailog.setCancelable(false);
						}
						loadingDailog.show();
					}else{
						// TODO Auto-generated method stub
						checkLayout.setVisibility(View.GONE);
						pickupLayout.setVisibility(View.VISIBLE);
						step = STEP_PICKUP;
					}
				}else if(step == STEP_PICKUP){
					pickupLayout.setVisibility(View.GONE);
					deviceList.setVisibility(View.VISIBLE);
					
					//删除扫描列表中的设备
					deleteDevice(selectedDevice.getMacAddr());
					
					//将入网的设备添加到对应的组中
					if(selectedZone == E3BleApplication.rootZone){
						selectedZone.addBleDevice(selectedDevice);
						Intent data = new Intent();
						data.putExtra("groupid", selectedZone.getId());
						setResult(RESULT_ADD_FINISH_CODE, data);
						selectedDevice = null;
						adapter.setSelected(-1);
						step = STEP_SCAN;
						AddDeviceActivity.this.finish();
						
					}else{
						selectedZone.addBleDevice(selectedDevice);
						E3BleApplication.rootZone.addBleDevice(selectedDevice);
						
						application.myApi.sendRemoveGroupById(selectedDevice.getAddr(), 0xFFFF);	//删除设备上的全部分组
						
						uiHandler.postDelayed(new Runnable() {
							
							@Override
							public void run() {
								// TODO Auto-generated method stub
								application.myApi.sendGroupingCmd(selectedDevice.getAddr(), selectedZone.getId());
								Intent data = new Intent();
								data.putExtra("groupid", selectedZone.getId());
								setResult(RESULT_ADD_FINISH_CODE, data);
								selectedDevice = null;
								adapter.setSelected(-1);
								step = STEP_SCAN;
								AddDeviceActivity.this.finish();
							}
						}, 500);
						
					}
					
					
				}
				
			}
		});
	}

	private Menu mOptionsMenu;

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		mOptionsMenu = menu;
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.menu_add_device, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_add_device_scan) {
			startBleScan();
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	public void setRefreshActionButtonState(boolean refreshing) {
		if (mOptionsMenu == null) {
			return;
		}

		final MenuItem scanItem = mOptionsMenu
				.findItem(R.id.action_add_device_scan);
		if (scanItem != null) {

			if (refreshing) {
				scanItem.setActionView(R.layout.actionbar_indeterminate_progress);
			} else {
				scanItem.setActionView(null);
			}
		}
	}
	
	private void startBleScan(){
		//开启扫描
		ArrayList<String> infalter = new ArrayList<>();
		infalter.add("E3Control Mesh");
		infalter.add("E3Vcb4qxm1g0");
		application.myApi.startScanningWithMeshNames(null,5000);
		setRefreshActionButtonState(true);
		
		uiHandler.postDelayed(new Runnable() {
			
			@Override
			public void run() {
				// TODO Auto-generated method stub
				setRefreshActionButtonState(false);
			}
		}, 10000);
	}
	

	@Override
	public void onUIConnected(String macAddress) {
		// TODO Auto-generated method stub
		if(loadingDailog != null)
			loadingDailog.dismiss();
		
		if(macAddress.equals(selectedDevice.getMacAddr())){
			this.runOnUiThread(new Runnable() {
				
				@Override
				public void run() {
					// TODO Auto-generated method stub
					deviceList.setVisibility(View.GONE);
					checkLayout.setVisibility(View.VISIBLE);
				}
			});
			
			step = STEP_CHECK;
		}else{
			Log.e(TAG, "onConnected macAddress is not selected :" + macAddress);
		}
		
		
	}

	@Override
	public void onUIConnectedFailed(String macAddress, int code) {
		// TODO Auto-generated method stub
		if(loadingDailog != null)
			loadingDailog.dismiss();
		Log.e(TAG, "onConnectedFailed macAddress :" + macAddress);
	}

	@Override
	public void onUIAddToMeshSucceeded(String macAddress, int code) {
		// TODO Auto-generated method stub
		if(loadingDailog != null)
			loadingDailog.dismiss();
		
		if(macAddress.equals(selectedDevice.getMacAddr())){
			this.runOnUiThread(new Runnable() {
				
				@Override
				public void run() {
					// TODO Auto-generated method stub
					checkLayout.setVisibility(View.GONE);
					pickupLayout.setVisibility(View.VISIBLE);
				}
			});
			
			step = STEP_PICKUP;
		}else{
			Log.e(TAG, "onAddToMeshSucceeded macAddress is not selected :" + macAddress);
		}
	}

	@Override
	public void onUIAddToMeshFailed(String macAddress, int code) {
		// TODO Auto-generated method stub
		if(loadingDailog != null)
			loadingDailog.dismiss();
		Log.e(TAG, "onAddToMeshFailed macAddress :" + macAddress);
		
		//重新回到扫描列表
		this.runOnUiThread(new Runnable() {
			
			@Override
			public void run() {
				// TODO Auto-generated method stub
				deviceList.setVisibility(View.VISIBLE);
				checkLayout.setVisibility(View.GONE);
			}
		});
		selectedDevice = null;
		adapter.setSelected(-1);
		step = STEP_SCAN;
	}

	@Override
	public void onUIConnectionLost() {
		// TODO Auto-generated method stub
		if(loadingDailog != null)
			loadingDailog.dismiss();
	}

	

	@Override
	public void onUINewBleDeviceFound(final BluetoothDevice device, final int rssi, final DeviceInfo dInfo) {
		// TODO Auto-generated method stub
		Log.e(TAG, "onNewBleDeviceFound:" + device.getAddress()+ " ,rssi:" +rssi+" ,addr:"+dInfo.getMeshAddr() );
		this.runOnUiThread(new Runnable() {
			
			@Override
			public void run() {
				// TODO Auto-generated method stub
				if(!isExist(device,rssi)){
					BleDevice d = new BleDevice(device.getAddress().trim(), dInfo.getMeshAddr(), device.getName(), rssi, BleDevice.DEVICE_TYPE_LIGHT_CW);
					adapter.addDevice(d);
				}else{
					adapter.notifyDataSetChanged();
				}
			}
		});
		
		
	}

	private boolean isExist(BluetoothDevice device,int rssi){
		for(BleDevice d :E3BleApplication.SCANLIST){
			if(d.getMacAddr().equals(device.getAddress())){
				d.setRssi(rssi);
				return true;
			}
		}
		
		for(BleDevice d :E3BleApplication.rootZone.getDevices()){
			if(d.getMacAddr().equals(device.getAddress())){
				d.setRssi(rssi);
				return true;
			}
		}
		
		
		return false;
	}
	
	private void deleteDevice(String address){
		for(int i = E3BleApplication.SCANLIST.size()-1;i >= 0;i--){
			BleDevice b = E3BleApplication.SCANLIST.get(i);
			if(b.getMacAddr().equals(address)){
				E3BleApplication.SCANLIST.remove(i);
				adapter.setSelected(-1);
				
				return ;
			}
		}
	}

	@Override
	public void onUIDeviceStatusChanged(byte addr, boolean isOnline,
			byte level, byte temColor) {
		// TODO Auto-generated method stub
		
	}
}
