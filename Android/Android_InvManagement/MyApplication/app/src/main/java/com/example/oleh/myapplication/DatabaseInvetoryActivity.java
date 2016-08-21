package com.example.oleh.myapplication;

import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.DecorToolbar;
import android.support.v7.widget.SearchView;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectArrayCallback;
import io.cloudboost.CloudQuery;

public class DatabaseInvetoryActivity extends AppCompatActivity {

    TextView text;
    ListView listView;
    String[] food = {"Corn", "Potato", "Tomato"};
    CloudQuery itemList;
    ArrayAdapter<String> adapter;
    Button scan;
    public ProgressDialog pdialog;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_database_invetory);
        pdialog=new ProgressDialog(this);

        //text = (TextView) findViewById(R.id.testText);
        listView = (ListView)findViewById(R.id.listView);
        adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,food);
        //adapter = new ArrayAdapter<String>(this,q, itemList);
        listView.setAdapter(adapter);
        scan = (Button)findViewById(R.id.scanActivityBtn);
        // search = (SearchView)findViewById(R.id.searchView);
        //new Query().execute();

        Intent Scan_pg = new Intent(DatabaseInvetoryActivity.this, BarcodeScan.class);
        DatabaseInvetoryActivity.this.startActivity(Scan_pg);
    }

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
            final CloudQuery query = new CloudQuery("Test");
            try {
                //test = new CloudQuery[]{query.all("Test")};
                //final CloudQuery[] test = new CloudQuery[]{query.all("Test")};
                //itemList = query.all("Test");
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            //adapter = new ArrayAdapter<String>(this,CloudQuery[0],test);

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
}
