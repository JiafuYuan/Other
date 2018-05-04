package com.bestway.kj915.nfc;

import java.io.UnsupportedEncodingException;

import android.nfc.NdefRecord;

public class TextRecord {

	private static String TAG = "TextRecord";

	public static boolean isText(NdefRecord ndefRecord) {
		// TODO Auto-generated method stub
		try {
			parse(ndefRecord);
			return true;
		} catch (IllegalArgumentException e) {
			return false;
		}
	}

	public static String parse(NdefRecord ndefRecord) {
		// TODO Auto-generated method stub
//		if (ndefRecord.getTnf() != NdefRecord.TNF_WELL_KNOWN
//				|| !Arrays.equals(ndefRecord.getType(), NdefRecord.RTD_TEXT)) {
//			throw new IllegalArgumentException("NFC类型不正确...");
//		}
		try {
			byte[] payload = ndefRecord.getPayload();
			String textEncoding = ((payload[0] & 0200) == 0) ? "UTF-8"
					: "UTF-16";
			int languageCodeLength = payload[0] & 0077;
			String languageCode = new String(payload, 1, languageCodeLength,
					"US-ASCII");
			String text = new String(payload, languageCodeLength + 1,
					payload.length - languageCodeLength - 1, textEncoding);
			System.out.println("结果"+text);
			return text;
		} catch (UnsupportedEncodingException e) {
			System.out.println("gaga..yichang");
			throw new IllegalArgumentException(e);
		}
	}

}
