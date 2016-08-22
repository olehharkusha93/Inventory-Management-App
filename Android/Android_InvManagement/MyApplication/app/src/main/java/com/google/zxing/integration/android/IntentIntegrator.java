package com.google.zxing.integration.android;

import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.ActivityNotFoundException;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;

public class IntentIntegrator {

    public static final int REQUEST_CODE = 0x0000c0de;
    private static final String TAG = IntentIntegrator.class.getSimpleName();

    public static final String DEFAULT_TITLE = "Install Barcode Scanner?";
    public static final String DEFAULT_MESSAGE = "This app requires a Barcode Scanner. Would you like to install it?";

    public static final String DEFAULT_YES = "Yes";
    public static final String DEFAULT_NO = "No";

    private static final String BS_PACKAGE = "com.google.zxing.client.android";
    private static final String BSPLUS_PACKAGE = "com.srowen.bs.android";

    //supported barcode formats
    public static final Collection<String> PRODUCT_CODE_TYPES = list("UPC_A","UPC_E","EAN_8","EAN_13","RSS_14");
    public static final Collection<String> ONE_D_CODE_TYPES =
            list("UPC_A","UPC_E","EAN_8","EAN_13", "CODE_39","CODE_93","CODE_128","ITF","RSS_14","RSS_EXPANDED");

    public static final Collection<String> QR_CODE_TYPES = Collections.singleton("QR_CODE");
    public static final Collection<String> DATA_MATRIX_TYPES = Collections.singleton("DATA_MATRIX");

    public static final Collection<String> ALL_CODE_TYPES = null;

    public static final List<String> TARGET_BARCODE_SCANNER_ONLY = Collections.singletonList(BS_PACKAGE);
    public static final List<String> TARGET_ALL_KNOWN = list(
            BS_PACKAGE, //Barcode Scanner
            BSPLUS_PACKAGE, //Barcode Scanner+
            BSPLUS_PACKAGE + ".simple"
    );

    private final Activity activity;
    private String title;
    private String message;
    private String buttonYes;
    private String buttonNo;
    private List<String> targetApplications;
    private final Map<String,Object> moreExtras;

    public IntentIntegrator(Activity _activity){
        activity = _activity;
        title = DEFAULT_TITLE;
        message = DEFAULT_MESSAGE;
        buttonYes = DEFAULT_YES;
        buttonNo = DEFAULT_NO;
        targetApplications = TARGET_ALL_KNOWN;
        moreExtras = new HashMap<String, Object>(3);
    }
    //Getters
    public String GetTitle(){
        return title;
    }
    public String GetMessage(){
        return message;
    }
    public String GetButtonYes(){
        return buttonYes;
    }
    public String GetButtonNo(){
        return buttonNo;
    }
    public Collection<String> GetTargetApplications(){
        return targetApplications;
    }
    public Map<String,?> GetMoreExtras(){
        return moreExtras;
    }


    //Setters
    public void SetTitle(String _title){
        title = _title;
    }
    public void SetTitleByID(int _ID){
        title = activity.getString(_ID);
    }
    public void SetMessage(String _message){
        message = _message;
    }
    public void SetMessageByID(int _ID){
        message = activity.getString(_ID);
    }
    public void SetButtonYes(String _buttonYes){
        buttonYes = _buttonYes;
    }
    public void SetButtonYesByID(int _id){
        buttonYes = activity.getString(_id);
    }
    public void SetButtonNo(String _buttonNo){
        buttonNo = _buttonNo;
    }
    public void SetButtonNoByID(int _id){
        buttonNo = activity.getString(_id);
    }
    public void SetTargetApplications(List<String> _targetApps){
        if(_targetApps.isEmpty()){
            throw new IllegalArgumentException("No target applications");
        }
        targetApplications = _targetApps;
    }
    public void SetSingleTargetApplication(String _targetApps){
        targetApplications = Collections.singletonList(_targetApps);
    }



    public final AlertDialog initiateScan(){
        return initiateScan(ALL_CODE_TYPES);
    }

    public final void AddExtra(String _key, Object _val){
        moreExtras.put(_key,_val);
    }

    public final AlertDialog initiateScan(Collection<String> desiredBarcodeFormat){
        Intent intentScan = new Intent(BS_PACKAGE + ".SCAN");
        intentScan.addCategory(Intent.CATEGORY_DEFAULT);

        //Check which type of barcode to scan for
        if(desiredBarcodeFormat != null){
            //Set the desired barcode to it's type
            StringBuilder joinedByComma = new StringBuilder();
            for (String format : desiredBarcodeFormat){
                if(joinedByComma.length()>0) {
                    joinedByComma.append(',');
                }
                joinedByComma.append(format);
            }
            intentScan.putExtra("SCAN FORMATS",joinedByComma.toString());
        }
        String targetAppPackage = findTargetAppPackage(intentScan);
        if(targetAppPackage == null){
            return showDownloadDialog();
        }
        intentScan.setPackage(targetAppPackage);
        intentScan.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        intentScan.addFlags(Intent.FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET);
        attachMoreExtras(intentScan);
        startActivityForResult(intentScan, REQUEST_CODE);
        return null;
    }

    protected void startActivityForResult(Intent intent, int code){
        activity.startActivityForResult(intent,code);
    }

    private String findTargetAppPackage(Intent intent){
        PackageManager pm = activity.getPackageManager();
        List<ResolveInfo> allAvailableApps = pm.queryIntentActivities(intent, PackageManager.MATCH_DEFAULT_ONLY);
        if(allAvailableApps != null){
            for (ResolveInfo availableApp : allAvailableApps){
                String packageName = availableApp.activityInfo.packageName;
                if(targetApplications.contains(packageName)){
                    return  packageName;
                }
            }
        }
        return null;
    }

    private AlertDialog showDownloadDialog(){
        AlertDialog.Builder downloadDialog = new AlertDialog.Builder(activity);
        downloadDialog.setTitle(title);
        downloadDialog.setMessage(message);
        downloadDialog.setPositiveButton(buttonYes, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i){
                String packageName = targetApplications.get(0);
                Uri uri = Uri.parse("market://details?id="+packageName);
                Intent intent = new Intent(Intent.ACTION_VIEW, uri);
                try{
                    activity.startActivity(intent);
                } catch(ActivityNotFoundException exception){
                    //Market is not installed
                    Log.v(TAG, "Google Play is not installed. Cannot install"+packageName);
                }
            }
        });
        downloadDialog.setNegativeButton(buttonNo, new DialogInterface.OnClickListener(){
            @Override
            public void onClick(DialogInterface dialogInterface, int i){}
        });
        return downloadDialog.show();
    }

    public static IntentResult parseActivityResult(int requestCode, int resultCode, Intent intent) {
        if (requestCode == REQUEST_CODE) {
            if (resultCode == Activity.RESULT_OK) {
                String contents = intent.getStringExtra("SCAN_RESULT");
                String formatName = intent.getStringExtra("SCAN_RESULT_FORMAT");
                byte[] rawBytes = intent.getByteArrayExtra("SCAN_RESULT_BYTES");
                int intentOrientation = intent.getIntExtra("SCAN_RESULT_ORIENTATION", Integer.MIN_VALUE);
                Integer orientation = intentOrientation == Integer.MIN_VALUE ? null : intentOrientation;
                String errorCorrectionLevel = intent.getStringExtra("SCAN_RESULT_ERROR_CORRECTION_LEVEL");
                return new IntentResult(contents,
                        formatName,
                        rawBytes,
                        orientation,
                        errorCorrectionLevel);
            }
            return new IntentResult();
        }
        return null;
    }

    public final AlertDialog shareText(CharSequence text, CharSequence type) {
        Intent intent = new Intent();
        intent.addCategory(Intent.CATEGORY_DEFAULT);
        intent.setAction(BS_PACKAGE + ".ENCODE");
        intent.putExtra("ENCODE_TYPE", type);
        intent.putExtra("ENCODE_DATA", text);
        String targetAppPackage = findTargetAppPackage(intent);
        if (targetAppPackage == null) {
            return showDownloadDialog();
        }
        intent.setPackage(targetAppPackage);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_WHEN_TASK_RESET);
        attachMoreExtras(intent);
        activity.startActivity(intent);
        return null;
    }

    private static List<String> list(String... values) {
        return Collections.unmodifiableList(Arrays.asList(values));
    }

    private void attachMoreExtras(Intent intent) {
        for (Map.Entry<String, Object> entry : moreExtras.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
// Kind of hacky
            if (value instanceof Integer) {
                intent.putExtra(key, (Integer) value);
            } else if (value instanceof Long) {
                intent.putExtra(key, (Long) value);
            } else if (value instanceof Boolean) {
                intent.putExtra(key, (Boolean) value);
            } else if (value instanceof Double) {
                intent.putExtra(key, (Double) value);
            } else if (value instanceof Float) {
                intent.putExtra(key, (Float) value);
            } else if (value instanceof Bundle) {
                intent.putExtra(key, (Bundle) value);
            } else {
                intent.putExtra(key, value.toString());
            }
        }
    }
}
