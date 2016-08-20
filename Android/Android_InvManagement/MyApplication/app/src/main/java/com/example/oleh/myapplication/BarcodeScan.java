package com.example.oleh.myapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

import android.content.Intent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class BarcodeScan extends AppCompatActivity implements OnClickListener{
    private Button scanBtn;
    private TextView formatTxt, contentTxt;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_barcode_scan);

        scanBtn = (Button)findViewById(R.id.scanButton);
        formatTxt = (TextView)findViewById(R.id.scanFormat);
        contentTxt = (TextView)findViewById(R.id.scanInfo);

        scanBtn.setOnClickListener(this);
    }

    public void onClick(View _v){
        //responding to clicks
        if(_v.getId()==R.id.scanButton){
            IntentIntegrator scanIntegrator = new IntentIntegrator(this);
            scanIntegrator.initiateScan();
        }
    }

    public void onActivityResult(int _requestCode, int _resultCode, Intent _intent){
        //Retrieve the scan result
        IntentResult scanResult = IntentIntegrator.parseActivityResult(_requestCode,_resultCode,_intent);
        if(scanResult!=null){
            String scan_Info = scanResult.GetContents();
            String scan_Format = scanResult.GetFormatName();
            formatTxt.setText("Format: "+ scan_Format);
            contentTxt.setText("Content: " + scan_Info);


        }
        else{
            Toast tst = Toast.makeText(getApplicationContext(),
                    "No scan data revieved!",Toast.LENGTH_SHORT);
            tst.show();
        }

    }
}
