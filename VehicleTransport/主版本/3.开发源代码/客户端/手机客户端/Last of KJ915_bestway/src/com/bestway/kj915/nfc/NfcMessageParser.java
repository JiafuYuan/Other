package com.bestway.kj915.nfc;

import java.util.ArrayList;
import java.util.List;

import android.content.Intent;
import android.nfc.NdefMessage;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.os.Parcelable;

public class NfcMessageParser {

	private Intent tagIntent;
	private String TAG = "NfcMessageParser";

	public NfcMessageParser() {

	}

	public NfcMessageParser(Intent intent) {
		this.tagIntent = intent;
	}

	// 解析NFC信息，并得到站名和地理位置
	public List<String> getTagMessage() {
		if (NfcAdapter.ACTION_NDEF_DISCOVERED.equals(tagIntent.getAction())) {
			NdefMessage[] msgs = getTagNdef(tagIntent);
			System.out.println("mgs"+msgs);
			List<String> ndefList = getNdefString(msgs);
			if (ndefList != null && ndefList.size() != 0) {
				return ndefList;
			}
		}
		return null;
	}

	// 得到Intent中的NDEF
	private NdefMessage[] getTagNdef(Intent intent) {
		// TODO Auto-generated method stub
		NdefMessage[] msgs = null;
		Parcelable[] rawMsgs = intent
				.getParcelableArrayExtra(NfcAdapter.EXTRA_NDEF_MESSAGES);
		if (rawMsgs != null) {
			msgs = new NdefMessage[rawMsgs.length];
			for (int i = 0; i < rawMsgs.length; i++) {
				msgs[i] = (NdefMessage) rawMsgs[i];
			}
		} else {
			// Unknown tag type
			byte[] empty = new byte[] {};
			NdefRecord record = new NdefRecord(NdefRecord.TNF_UNKNOWN, empty,
					empty, empty);
			NdefMessage msg = new NdefMessage(new NdefRecord[] { record });
			msgs = new NdefMessage[] { msg };
		}
		return msgs;
	}

	// 从NDEF中获取所需的信息
	private List<String> getNdefString(NdefMessage[] msgs) {
		// TODO Auto-generated method stub
		if (msgs != null && msgs.length != 0) {
			List<String> tagMessage = parser(msgs[0]);
			return tagMessage;
		}
		return null;
	}
    //www.javaapk.com
	// 把NDEF中的信息系转化为Record，并最终转化为String
	private List<String> parser(NdefMessage ndefMessage) {
		// TODO Auto-generated method stub
		NdefRecord[] records = ndefMessage.getRecords();
		List<String> elements = new ArrayList<String>();
		for (NdefRecord ndefRecord : records) {
			System.out.println(ndefRecord+">>>");
			
//			if (!TextRecord.isText(ndefRecord)) {
//				System.out.println("TextRecord");
//				return null;
//			}
			elements.add(TextRecord.parse(ndefRecord));
		}
		return elements;
	}

}
