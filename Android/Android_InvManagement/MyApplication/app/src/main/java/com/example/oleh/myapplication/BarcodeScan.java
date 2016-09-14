package com.example.oleh.myapplication;

import android.net.Uri;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;
import com.squareup.okhttp.internal.http.HttpConnection;

import android.content.Intent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.StringReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;

public class BarcodeScan extends AppCompatActivity implements OnClickListener {
    private Button scanBtn;
    private TextView formatTxt, contentTxt;
    private TextView itemTxt;
    private Button testButton; //Delete later!!
    /**
     * ATTENTION: This was auto-generated to implement the App Indexing API.
     * See https://g.co/AppIndexing/AndroidStudio for more information.
     */
    private GoogleApiClient client;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_barcode_scan);

        scanBtn = (Button) findViewById(R.id.scanButton);
        formatTxt = (TextView) findViewById(R.id.scanFormat);
        contentTxt = (TextView) findViewById(R.id.scanInfo);
        itemTxt = (TextView) findViewById(R.id.itemInfo);

        testButton = (Button) findViewById(R.id.testJson); //Delete later!!

        scanBtn.setOnClickListener(this);
        testButton.setOnClickListener(this); //Delete later!!
        // ATTENTION: This was auto-generated to implement the App Indexing API.
        // See https://g.co/AppIndexing/AndroidStudio for more information.
        client = new GoogleApiClient.Builder(this).addApi(AppIndex.API).build();
    }

    public void onClick(View _v) {
        //responding to clicks
        if (_v.getId() == R.id.scanButton) {
            IntentIntegrator scanIntegrator = new IntentIntegrator(this);
            scanIntegrator.initiateScan();
        }
        if (_v.getId() == R.id.testJson) {

            //String data = GetJSON("http://localhost/authmanager.php",1000);
            //AuthMsg msg = new Gson
        }

    }

    public void onActivityResult(int _requestCode, int _resultCode, Intent _intent) {
        //Retrieve the scan result
        IntentResult scanResult = IntentIntegrator.parseActivityResult(_requestCode, _resultCode, _intent);
        if (scanResult != null) {
            String scan_Info = scanResult.GetContents();
            String scan_Format = scanResult.GetFormatName();
            formatTxt.setText("Format: " + scan_Format);
            contentTxt.setText("Content: " + scan_Info);

            //GetJson Here!!
            new JSONTask().execute("https://api.upcitemdb.com/prod/trial/lookup?upc="+scan_Info);
        } else {
            Toast tst = Toast.makeText(getApplicationContext(),
                    "No scan data revieved!", Toast.LENGTH_SHORT);
            tst.show();
        }

    }

    public String GetJSON(String _url, int _timeout) {
        HttpURLConnection c = null;
        try {
            URL url = new URL(_url);
            c = (HttpURLConnection) url.openConnection();
            c.setRequestMethod("GET");
            c.addRequestProperty("Content-length", "0");
            c.setUseCaches(false);
            c.setAllowUserInteraction(false);
            c.setReadTimeout(_timeout);
            c.connect();

            int status = c.getResponseCode();
            switch (status) {
                case 200:
                case 201:
                    BufferedReader br = new BufferedReader(new InputStreamReader(c.getInputStream()));
                    StringBuilder sb = new StringBuilder();
                    String line;
                    while ((line = br.readLine()) != null) {
                        sb.append((line + '\n'));
                    }
                    br.close();
                    return sb.toString();
            }
        } catch (MalformedURLException e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, null, e);
        } catch (IOException e) {
            Logger.getLogger(getClass().getName()).log(Level.SEVERE, null, e);
        } finally {
            if (c != null) {
                try {
                    c.disconnect();
                } catch (Exception e) {
                    Logger.getLogger(getClass().getName()).log(Level.SEVERE, null, e);
                }
            }
        }
        return null;
    }





    public class JSONTask extends AsyncTask<String, String, String> {

        @Override
        protected String doInBackground(String... _url) {
            HttpURLConnection c = null;
            BufferedReader br = null;
            try {
                URL url = new URL(_url[0]);
                c = (HttpURLConnection) url.openConnection();
                c.connect();

                br = new BufferedReader(new InputStreamReader(c.getInputStream()));
                StringBuffer sb = new StringBuffer();
                String line = "";
                while ((line = br.readLine()) != null) {
                    sb.append((line + '\n'));
                }
                String sJSON = sb.toString();

                JSONObject parentObj = new JSONObject(sJSON);
                JSONArray parentArr = parentObj.getJSONArray("items"); //string prior to []

                JSONObject finalObj = parentArr.getJSONObject(0);

                String itemName = finalObj.getString("title");//Key is the "quotes" inside the arr
                String itemBrand = finalObj.getString("brand");

                //JSON image stuff
                //String image = finalObj.getString("image");


                return itemName + " , "+ itemBrand;

            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            } catch(JSONException e) {
                e.printStackTrace();
            }finally {
                if (c != null) {
                    c.disconnect();
                }
                try{
                    if(br!=null){
                        br.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            return null;
        }

        protected void onPostExecute(String result){
            super.onPostExecute(result);
            itemTxt.setText(result);
        }
    }
}
