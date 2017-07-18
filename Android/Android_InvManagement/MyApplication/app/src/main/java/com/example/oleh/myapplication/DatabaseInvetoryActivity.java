package com.example.oleh.myapplication;

import android.app.Application;
import android.app.Dialog;
import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.DecorToolbar;
import android.support.v7.widget.SearchView;
import android.util.Log;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;

import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;
import com.nostra13.universalimageloader.core.DisplayImageOptions;
import com.nostra13.universalimageloader.core.ImageLoader;
import com.nostra13.universalimageloader.core.ImageLoaderConfiguration;


import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectArrayCallback;
import io.cloudboost.CloudObjectCallback;
import io.cloudboost.CloudQuery;
import io.cloudboost.CloudTable;
import io.cloudboost.Column;

public class DatabaseInvetoryActivity extends AppCompatActivity implements View.OnClickListener {

    public static Bundle MyList = new Bundle();
    public static Bundle MyList2 = new Bundle();
    SharedPreferences pref;
    ListView listView;
    List<String> listFood;
    GridView gridView;
    ArrayAdapter<String> adapter;
    Button scan;
    Button logout;
    public ProgressDialog pdialog;
    Context c;
    BarcodeScan barcodeScan;
    TextView data;
    BarcodeScan barcode = new BarcodeScan();
    private int numOfItems;
    private boolean isClicked = false;
    private String val;

    List<String> listName, listNum, listURL;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Inventory");
        setContentView(R.layout.activity_database_invetory);

        //ImageLoader Stuff
        DisplayImageOptions defaultOptions = new DisplayImageOptions.Builder()
                .cacheInMemory(true).cacheOnDisk(true).build();
        ImageLoaderConfiguration config = new ImageLoaderConfiguration.Builder(getApplicationContext())
                .defaultDisplayImageOptions(defaultOptions).build();
        ImageLoader.getInstance().init(config); // Do it on Application start


        pdialog=new ProgressDialog(this);
        listFood = new ArrayList<String>();
        listName = new ArrayList<String>();
        listNum = new ArrayList<String>();
        listURL = new ArrayList<String>();
        // Change back to listView if gridView does't work out
        /*listView*/ gridView = (GridView) findViewById(R.id.gridView);
        adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,listFood)
        {
            @Override
            public View getView(int position,View convertView,ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                TextView textView = (TextView) view.findViewById(android.R.id.text1);
                String text = textView.getText().toString();
                getCount();

                String[] red = new String[50];
                for(int r = 0; r < red.length; r++) {
                    red[r] = String.valueOf(r);
                }

                String[] yellow = new String[99];
                for(int y = 50; y < yellow.length; y++){
                    yellow[y] = String.valueOf(y);
                }

                String[] green = new String[101];
                for (int g = 100; g < green.length; g++){
                    green[g] = String.valueOf(g);
                }

                for (int i = 0; i < listFood.size(); ++i) {

                    for (int j = 100; j < green.length; ++j) {
                        if (text.equals(green[j] + " / 1000")) {
                            textView.setTextColor(Color.parseColor("#009933")); //Green
                        }
                    }

                    for(int k = 50; k < yellow.length; ++k){
                        if(text.equals(yellow[k] + " / 1000")){
                            textView.setTextColor(Color.parseColor("#e6b800")); //Yellow
                        }
                    }

                    for(int x = 0; x < red.length; ++x) {
                        if (text.equals(red[x] + " / 1000")) {
                            textView.setTextColor(Color.parseColor("#CC0000")); //Red
                        }
                    }

                    break;
                }
                return view;
            }
        };


        new Query().execute();
        gridView.setAdapter(adapter);
        scan = (Button)findViewById(R.id.scanActivityBtn);
        //barcode = new BarcodeScan();
        logout = (Button)findViewById(R.id.logoutButton);
        c = this;

        scan.setOnClickListener(this);

        // Remember me log out
        pref = getSharedPreferences("login.config", Context.MODE_PRIVATE);
        logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                pref.edit().clear().commit();
                Intent logoutIntent = new Intent(DatabaseInvetoryActivity.this, LoginActivity.class);
                startActivity(logoutIntent);
            }
        });
        // onClick of gridView item
        gridView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                int itempos = position;
                String value = (String) gridView.getItemAtPosition(position);
                val = value;

                for (int i = 0; i < listName.size(); i++){
                    if(value.equals(listName.get(i))){
                        if(listURL.get(i)==""||listURL.get(i)==null){
                            itemDialog("http://res.cloudinary.com/dbmz1poqo/image/upload/v1474381344/cutmypic_sjcn3i.png",
                                    listName.get(i),listNum.get(i));
                        }
                        else {
                            itemDialog(listURL.get(i),listName.get(i),listNum.get(i));
                        }
                    }

                }
                Toast.makeText(DatabaseInvetoryActivity.this,""+value,Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void onClick(View v) {
        if (v.getId() == R.id.scanActivityBtn) {
            barcodeScan = new BarcodeScan();
            IntentIntegrator scanIntegrator = new IntentIntegrator(this);
            scanIntegrator.initiateScan();
            barcodeScan.SetParentContext(this);
        }
    }
    public void onActivityResult(int _requestCode, int _resultCode, Intent _intent) {
        //Retrieve the scan result
        IntentResult scanResult = IntentIntegrator.parseActivityResult(_requestCode, _resultCode, _intent);
        if (scanResult.GetContents() != null) {
            barcodeScan.SetScanId(scanResult.GetContents());
            barcodeScan.SetScanFormat(scanResult.GetFormatName());

            //GetJson Here!!
            barcodeScan.JsonExecute("https://api.upcitemdb.com/prod/trial/lookup?upc="+barcodeScan.GetScanId());

        } else {
            Toast tst = Toast.makeText(getApplicationContext(),
                    "No scan data revieved!", Toast.LENGTH_SHORT);
            tst.show();
        }

    }

    // Logout via action bar icon
    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.logout,menu);
        return super.onCreateOptionsMenu(menu);
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        switch (item.getItemId())
        {
            case R.id.action_add:
                addDialog();
                return true;
            case R.id.action_logout:
                pref.edit().clear().commit();
                Intent logoutIntent = new Intent(DatabaseInvetoryActivity.this, LoginActivity.class);
                startActivity(logoutIntent);
                Toast.makeText(DatabaseInvetoryActivity.this, "Logged Out",Toast.LENGTH_SHORT).show();
                return true;
            case R.id.action_shoplist:
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.setMessage("Buy beans").setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                }).setTitle("My List").create();
                alert.show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }
    // Logout via action bar icon end

    public class Query extends AsyncTask<String, String, String> {

         @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            pdialog.setMessage("Searching...");
            pdialog.show();
        }
        @Override
        protected String doInBackground(String... args) {
            String data = getIntent().getExtras().getString("pop");
            final CloudQuery query = new CloudQuery(data); // Change AppKey AppID later to Organizations of main app
            query.setLimit(50); //in the future user can create a personal organization and set a limit of the inventory with a promt.
            try {
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            for (int i = 0; i < x.length; ++i) {
                                listFood.add((String) x[i].get("Name"));
                                listFood.add(x[i].get("Quantity").toString() + " / 1000");


                                listName.add((String)x[i].get("Name"));
                                listNum.add(x[i].get("Quantity").toString());
                                listURL.add((String)x[i].get("imageURL"));

                                DatabaseInvetoryActivity.MyList.putStringArrayList("list", (ArrayList<String>) listName);
                                DatabaseInvetoryActivity.MyList2.putStringArrayList("numList", (ArrayList<String>) listNum);

                            }

                            Log.d("Test", "not null");
                        } else {
                            Log.d("Test", "is null");
                        }
                        if (t != null) {
                            Log.d("Test", "not null");
                        } else {
                            Log.d("Test", "is null");
                        }
                    }
                });
            } catch (CloudException e) {
                e.printStackTrace();
            }
            return null;

        }
         @Override
         protected void onPostExecute (String result)
         {
             super.onPostExecute(result);
             pdialog.dismiss();
         }
    }

    public class addOnTap extends AsyncTask<String,String,String>{
        @Override
        protected String doInBackground(String... args) {
            String data = getIntent().getExtras().getString("pop");
            final CloudQuery query = new CloudQuery(data);
            final CloudObject obj = new CloudObject(data);

            try {
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            for (int i = 0; i < x.length; ++i) {

                                if(GetValue().equals(listName.get(i))){
                                    if(x[i].get("Quantity").toString().equals(listNum.get(i))){
                                        Integer num = (Integer)x[i].get("Quantity") + numOfItems;
                                        x[i].set("Quantity",num);
                                    }
                                    x[i].save(new CloudObjectCallback() {
                                        @Override
                                        public void done(CloudObject x, CloudException t) throws CloudException {
                                            if(x != null){
                                                //
                                            }
                                            if(t != null){
                                                //"Failed to save data"
                                            }
                                        }

                                    });
                                }
                            }

                            Log.d("Test", "not null");
                        } else {
                            Log.d("Test", "is null");
                        }
                        if (t != null) {
                            Log.d("Test", "not null");
                        } else {
                            Log.d("Test", "is null");
                        }
                    }
                });
            } catch (CloudException e) {
                e.printStackTrace();
            }
            return null;
        }
    }

    //Manual insert
    private void addDialog(){
        final Dialog dialog = new Dialog(DatabaseInvetoryActivity.this);
        dialog.setTitle("Manual Insert");
        dialog.setContentView(R.layout.custom_add_dialog);

        final EditText input_title = (EditText)dialog.findViewById(R.id.titleEdit);
        final EditText input_brand = (EditText)dialog.findViewById(R.id.brandEdit);
        final EditText input_barcode = (EditText)dialog.findViewById(R.id.barcodeEdit);
        final EditText input_quantity = (EditText)dialog.findViewById(R.id.quantityEdit);
        final Button addButton = (Button)dialog.findViewById(R.id.addButton);
        Button cancelButton = (Button)dialog.findViewById(R.id.cancelButton);

        addButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                if(input_barcode.length()<1 || input_brand.length()<1 || input_title.length()<1) {

                    Toast.makeText(getApplicationContext(),"Please fill all the information",Toast.LENGTH_SHORT).show();
                }
                else if(input_quantity.length()<1 || Integer.parseInt(input_quantity.getText().toString()) <= 0) {

                    Toast.makeText(getApplicationContext(),"Please Enter an amount larger than 1",Toast.LENGTH_SHORT).show();
                }
                else
                {
                    numOfItems = Integer.parseInt(input_quantity.getText().toString());
                    barcodeScan = new BarcodeScan();
                    barcodeScan.addItemExecute(input_title.getText().toString(),numOfItems,"");
                    Intent i = getIntent();
                    finish();
                    startActivity(i);
                    dialog.cancel();
                    Toast.makeText(getApplicationContext(), "Added!", Toast.LENGTH_SHORT).show();
                }
            }
        });
        cancelButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                dialog.cancel();
                Toast.makeText(getApplicationContext(),"Canceled",Toast.LENGTH_SHORT).show();
            }
        });
        dialog.show();
    }

    // same itemDialog from BarcodeScan
    private void itemDialog(final String url, final String title /*String brand*/, final String barcodeNum /*String barcodeType*/){

        final Dialog dialog = new Dialog(DatabaseInvetoryActivity.this);
        //numOfItems = 0;
        //Creating Dialog box behind the scenes & setting passed in values
        dialog.setTitle("Bringing...");
        dialog.setContentView(R.layout.custom_itemdialog);
        TextView itemTitle = (TextView)dialog.findViewById(R.id.ItemTitleID);
        TextView itemBrand = (TextView)dialog.findViewById(R.id.ItemBrandID);
        TextView itemBarcodeNum = (TextView)dialog.findViewById(R.id.ItemBarcodeID);
        TextView itemBarcodeType = (TextView)dialog.findViewById(R.id.ItemBarcodeTypeID);
        ImageView imgView = (ImageView)dialog.findViewById(R.id.ImageID);

        itemTitle.setText(title);
        itemBrand.setText("");
        itemBarcodeNum.setText(barcodeNum);
        itemBarcodeType.setText("");

        ImageLoader.getInstance().displayImage(url,imgView);

        Window window = dialog.getWindow();
        window.setGravity(Gravity.CENTER);


        //Input stuff
        final EditText input = (EditText)dialog.findViewById(R.id.AmountID);
        final Button addButton = (Button)dialog.findViewById(R.id.AddID);
        Button cancelButton = (Button)dialog.findViewById(R.id.CancelID);

        addButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                if(input.length()>=1 && Integer.parseInt(input.getText().toString()) > 0)
                {
                    numOfItems = Integer.parseInt(input.getText().toString());
                    new addOnTap().execute();
                    Intent i = getIntent();
                    finish();
                    startActivity(i);
                    dialog.cancel();
                    Toast.makeText(getApplicationContext(), "Added!", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Toast.makeText(getApplicationContext(),"Please Enter an amount larger than 1",Toast.LENGTH_SHORT).show();
                }
            }
        });
        cancelButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                dialog.cancel();
                Toast.makeText(getApplicationContext(),"Canceled",Toast.LENGTH_SHORT).show();
            }
        });
        dialog.show();
    }

    public String GetValue() {return val;}
    public List<String> GetList() {return listFood;}
    public int getCount() {return listFood.size();}
}

