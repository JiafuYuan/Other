package com.e3.bleapi.demo.adapter;

import java.util.List;

import com.e3.bleapi.demo.E3BleApplication;
import com.e3.bleapi.demo.R;
import com.e3.bleapi.demo.model.BleDevice;

import android.bluetooth.BluetoothDevice;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.ImageView;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

public class BluetoothDeviceAdapter extends BaseAdapter implements OnItemClickListener{
	private List<BleDevice> devices = null;
	private Context context;
	private LayoutInflater inflater;
	
	private int selected = -1;
	private BleDevice selectedDevice = null;
	
	
	public BluetoothDeviceAdapter(Context c,List<BleDevice> device){
		this.devices = device;
		this.context = c;
		this.inflater = LayoutInflater.from(context);
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return devices == null ? 0 : devices.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return 0;
	}
	
	public void addDevice(BleDevice device){
		devices.add(device);
		notifyDataSetChanged();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		BluetoothDeviceViewHolder holder = null;
		if(convertView == null){
			holder = new BluetoothDeviceViewHolder();
			convertView = (View)inflater.inflate(R.layout.ble_device_item, null);
			holder.meshName = (TextView)convertView.findViewById(R.id.bleitemName);
			holder.macAddr = (TextView)convertView.findViewById(R.id.bleitemMac);
			holder.selected = (ImageView)convertView.findViewById(R.id.bleitemSeleted);
			holder.rssi = (TextView)convertView.findViewById(R.id.bleitemRssi);
			convertView.setTag(holder);
		}else{
			holder = (BluetoothDeviceViewHolder)convertView.getTag();
		}
		
		if(selected == position){
			holder.selected.setVisibility(View.VISIBLE);
		}else{
			holder.selected.setVisibility(View.GONE);
		}
		
		final BleDevice device = devices.get(position);
		
		holder.meshName.setText(device.getDesc().trim());
		holder.macAddr.setText(device.getMacAddr());
		holder.rssi.setText(device.getRssi()+"");
		
		
		return convertView;
	}
	
	class BluetoothDeviceViewHolder{
		public TextView		meshName;
		public TextView		macAddr;
		public TextView 	rssi;
		public ImageView	selected;
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position,
			long id) {
		Toast.makeText(context, "onItemClick   "+devices.get(position).getMacAddr(), Toast.LENGTH_SHORT).show();
		selected = position;
		selectedDevice = devices.get(position);
		notifyDataSetChanged();
	}

	public BleDevice getSelectedDevice() {
		return selectedDevice;
	}

	public void setSelected(int selected) {
		this.selected = selected;
		notifyDataSetChanged();
	}
	
	

}
