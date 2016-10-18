package com.example.oleh.myapplication;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;
import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;
import com.squareup.okhttp.internal.http.HttpConnection;

import android.content.Intent;
import android.text.InputType;
import android.view.Display;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
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
import java.lang.reflect.Array;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectCallback;
import io.cloudboost.CloudTable;
import io.cloudboost.CloudTableArrayCallback;

public class BarcodeScan extends AppCompatActivity implements OnClickListener {
    private Button scanBtn;
    private TextView formatTxt, contentTxt;
    private TextView itemTxt;

    private ImageView itemImg;
    private Button testBtn; //Delete later!!
    private String imageURL;
    private String defaultImgURL;

    private AlertDialog.Builder dialogBuilder;
    private int numOfItems;

    private String scan_Info;
    private String scan_Format;
    private String itemScannedName;
    private Context parrentCtx;
    private static String NULL_BARTYPE = "NULL0";
    private static String NULL_ITEM = "NULL1";
    //OrganizationActivity orgTable;
    //OrganizationActivity t = new OrganizationActivity();
    /**
     * ATTENTION: This was auto-generated to implement the App Indexing API.
     * See https://g.co/AppIndexing/AndroidStudio for more information.
     */
    private GoogleApiClient client;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_barcode_scan);

        // Create default options which will be used for every
        //  displayImage(...) call if no options will be passed to this method
        DisplayImageOptions defaultOptions = new DisplayImageOptions.Builder()
                .cacheInMemory(true).cacheOnDisk(true).build();
        ImageLoaderConfiguration config = new ImageLoaderConfiguration.Builder(getApplicationContext())
                .defaultDisplayImageOptions(defaultOptions).build();
        ImageLoader.getInstance().init(config); // Do it on Application start

        scanBtn = (Button) findViewById(R.id.scanButton);
        formatTxt = (TextView) findViewById(R.id.scanFormat);
        contentTxt = (TextView) findViewById(R.id.scanInfo);
        itemTxt = (TextView) findViewById(R.id.itemInfo);
        itemImg = (ImageView) findViewById(R.id.itemImg);
        testBtn = (Button) findViewById(R.id.jsonTest); //Delete later!!

        scanBtn.setOnClickListener(this);
        testBtn.setOnClickListener(this); //Delete later
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
        if (_v.getId() == R.id.jsonTest) {
            SetScanId("049000050110");
            SetScanFormat("UPC_13");
            new JSONTask().execute("https://api.upcitemdb.com/prod/trial/lookup?upc=049000050110");
        }

    }

    public void onActivityResult(int _requestCode, int _resultCode, Intent _intent) {
        //Retrieve the scan result
        IntentResult scanResult = IntentIntegrator.parseActivityResult(_requestCode, _resultCode, _intent);
        if (scanResult != null) {
            SetScanId(scanResult.GetContents());
            SetScanFormat(scanResult.GetFormatName());

            //GetJson Here!!
            new JSONTask().execute("https://api.upcitemdb.com/prod/trial/lookup?upc=" + scan_Info);
        } else {
            Toast tst = Toast.makeText(getApplicationContext(),
                    "No scan data revieved!", Toast.LENGTH_SHORT);
            tst.show();
        }

    }

    public void JsonExecute(String url) {
        new JSONTask().execute(url);
    }

    public class JSONTask extends AsyncTask<String, String, String[]> {

        @Override
        protected String[] doInBackground(String... _url) {
            HttpURLConnection c = null;
            BufferedReader br = null;
            String[] result = new String[3];
            imageURL = "";
            defaultImgURL = null;
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

                JSONObject childObj = parentArr.getJSONObject(0);

                String itemName = childObj.getString("title");//Key is the "quotes" inside the arr
                final String itemBrand = childObj.getString("brand");

                result[0] = itemName;
                result[1] = itemBrand;

                itemScannedName = itemName;

                //JSON image stuff
                imageURL = null;
                JSONArray imageArr = new JSONArray(parentArr.getJSONObject(0).getString("images")); //Getting the ImgArr
                imageURL = imageArr.getString(0); //Parsing 1st img

                return result;

            } catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                result[0] = NULL_BARTYPE;
                return result;
            } catch (JSONException e) {
                if (imageURL == null) {
                    imageURL = "";
                    //Insert Behind img code here!!!
                    defaultImgURL = "http://www.hutchinsontires.com/helpers/img/no_image.jpg";
                    return result;
                } else {
                    result[0] = NULL_ITEM;
                    return result;
                }
            } finally {
                if (c != null) {
                    c.disconnect();
                }
                try {
                    if (br != null) {
                        br.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            return null;
        }

        protected void onPostExecute(String[] result) {
            super.onPostExecute(result);
            //Check for null exceptions
            if (result[0] == NULL_BARTYPE) {
                Toast.makeText(GetParentContext(), "This barcode type is not supported. Please manually insert item info"
                        , Toast.LENGTH_LONG).show();
            } else if (result[0] == NULL_ITEM) {
                Toast.makeText(GetParentContext(), "This item does not appear to be web. Please manually insert item info"
                        , Toast.LENGTH_LONG).show();
            }

            //Dialog Result
            else {
                if(defaultImgURL!=null)
                    itemDialog(defaultImgURL, result[0], result[1], GetScanId(), GetScanFormat());
                else{
                    itemDialog(imageURL, result[0], result[1], GetScanId(), GetScanFormat());
                }
            }
        }
    }

    public void addItemExecute(String title, int num, String url){
        itemScannedName = title;
        numOfItems = num;
        imageURL = url;
        new addItem().execute(title);
        /*
        itemScannedName = null;
        numOfItems = 0;
        imageURL = null;
        */
    }
    public class addItem extends AsyncTask<String,String,String> {
        @Override
        protected String doInBackground(String... params) {
            String t = OrganizationActivity.MyTable.getString("table");
            final CloudObject obj = new CloudObject(t);
            //ArrayList<String> list = DatabaseInvetoryActivity.MyList.getStringArrayList("list");
            //for(int i = 0; i < list.size(); ++i){
                //if(GetItemName().equals(list));
            //}
            try {
                obj.set("Name", GetItemName());
                obj.set("Quantity", numOfItems);
                obj.set("imageURL", imageURL);
                obj.save(new CloudObjectCallback() {
                    @Override
                    public void done(CloudObject x, CloudException t) throws CloudException {
                        if (t != null) {

                        }
                        if (x != null) {

                        }
                    }
                });
            } catch (CloudException e) {
                e.printStackTrace();
            }
            return null;
        }
    }

    private void itemDialog(final String url, final String title, String brand, String barcodeNum, String barcodeType){

        final Dialog dialog = new Dialog(GetParentContext());
        numOfItems = 0;
        //Creating Dialog box behind the scenes & setting passed in values
        dialog.setTitle("Found!");
        dialog.setContentView(R.layout.custom_itemdialog);
        final TextView itemTitle = (TextView)dialog.findViewById(R.id.ItemTitleID);
        TextView itemBrand = (TextView)dialog.findViewById(R.id.ItemBrandID);
        TextView itemBarcodeNum = (TextView)dialog.findViewById(R.id.ItemBarcodeID);
        TextView itemBarcodeType = (TextView)dialog.findViewById(R.id.ItemBarcodeTypeID);
        final ImageView imgView = (ImageView)dialog.findViewById(R.id.ImageID);
        final  ImageView defaultImgView = (ImageView)dialog.findViewById(R.id.DefaultImgID);

        itemTitle.setText(title);
        itemBrand.setText(brand);
        itemBarcodeNum.setText(barcodeNum);
        itemBarcodeType.setText(barcodeType);

        if(defaultImgURL!=null) {
            defaultImgView.setVisibility(View.VISIBLE);
            ImageLoader.getInstance().displayImage(url, defaultImgView);
        }
        else{
            ImageLoader.getInstance().displayImage(url, imgView);
        }


        //Input stuff
        final EditText input = (EditText) dialog.findViewById(R.id.AmountID);
        Button addButton = (Button) dialog.findViewById(R.id.AddID);
        Button cancelButton = (Button) dialog.findViewById(R.id.CancelID);

        addButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (input.length() >= 1 && Integer.parseInt(input.getText().toString()) > 0) {
                    numOfItems = Integer.parseInt(input.getText().toString());
                    new addItem().execute(title);
                    dialog.cancel();
                    Toast.makeText(GetParentContext(), "Added!", Toast.LENGTH_SHORT).show();
                } else {
                    Toast.makeText(GetParentContext(), "Please Enter an amount larger than 1", Toast.LENGTH_SHORT).show();
                }
            }
        });
        cancelButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                dialog.cancel();
                Toast.makeText(GetParentContext(), "Canceled", Toast.LENGTH_SHORT).show();
            }
        });
        dialog.show();
    }

    public String GetScanId() {
        return scan_Info;
    }

    public void SetScanId(String info) {
        scan_Info = info;
    }

    public String GetScanFormat() {
        return scan_Format;
    }
    public void SetScanFormat(String format){
        scan_Format = format;
    }
    public String GetItemName(){return itemScannedName; }

    public Context GetParentContext() { return parrentCtx; }

    public void SetParentContext(Context c) { parrentCtx = c; }
}
            /* Notes
             //Error Msg
             dialogBuilder = new AlertDialog.Builder(getApplicationContext());
             dialogBuilder.setTitle("Error!");
             dialogBuilder.setMessage("Please Enter an amount larger than 1");
             dialogBuilder.setPositiveButton("OK",new DialogInterface.OnClickListener(){
                 @Override
                 public void onClick(DialogInterface dialog, int which){
                     Toast.makeText(getApplicationContext(),"Ok",Toast.LENGTH_SHORT);
                 }
             });
             dialogBuilder.setNegativeButton("Cancel",new DialogInterface.OnClickListener(){
                 @Override
                 public void onClick(DialogInterface dialog, int which){
                     Toast.makeText(getApplicationContext(),"Canceled",Toast.LENGTH_SHORT);
                 }
             });
             //Output
             AlertDialog dialogNumber = dialogBuilder.create();
             dialogNumber.show();
             */
