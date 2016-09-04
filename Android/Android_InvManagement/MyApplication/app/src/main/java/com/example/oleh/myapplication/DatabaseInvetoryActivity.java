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
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectArrayCallback;
import io.cloudboost.CloudQuery;

public class DatabaseInvetoryActivity extends AppCompatActivity {

    ListView listView;
    List<String> listFood;
    GridView gridView;
    ArrayAdapter<String> adapter;
    Button scan;
    public ProgressDialog pdialog;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Inventory");
        setContentView(R.layout.activity_database_invetory);

        pdialog=new ProgressDialog(this);
        listFood = new ArrayList<String>();
        // Change back to listView if gridView does't work out
        /*listView*/ gridView = (GridView) findViewById(R.id.gridView);
        adapter = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,listFood);
        new Query().execute();
        gridView.setAdapter(adapter);
        scan = (Button)findViewById(R.id.scanActivityBtn);

        scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent Scan_pg = new Intent(DatabaseInvetoryActivity.this, BarcodeScan.class);
                DatabaseInvetoryActivity.this.startActivity(Scan_pg);
            }
        });

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
            final CloudQuery query = new CloudQuery("Test"); // Change later to Organizations
            try {
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            for (int i = 0; i < x.length; ++i) {
                                listFood.add((String)x[i].get("Name"));
                                listFood.add(x[i].get("Quantity").toString());

                                // Used to be with tabs
                                //listFood.add((String) x[i].get("Name")  + (String) x[i].get("Type") + x[i].get("Quantity").toString());
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
}
