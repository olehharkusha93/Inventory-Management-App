package com.example.oleh.myapplication;

import android.app.Application;
import android.app.ListActivity;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.AsyncTask;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.DecorToolbar;
import android.support.v7.widget.SearchView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.GridView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectArrayCallback;
import io.cloudboost.CloudQuery;

public class DatabaseInvetoryActivity extends AppCompatActivity {

    SharedPreferences pref;

    ListView listView;
    List<String> listFood;
    GridView gridView;
    ArrayAdapter<String> adapter;
    Button scan;
    Button logout;
    public ProgressDialog pdialog;
    Context c;
    TextView data;

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
        logout = (Button)findViewById(R.id.logoutButton);
        c = this;
        
        scan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent Scan_pg = new Intent(DatabaseInvetoryActivity.this, BarcodeScan.class);
                DatabaseInvetoryActivity.this.startActivity(Scan_pg);
            }
        });

        pref = getSharedPreferences("login.config", Context.MODE_PRIVATE);

        logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                pref.edit().clear().commit();
                Intent logoutIntent = new Intent(DatabaseInvetoryActivity.this, LoginActivity.class);
                startActivity(logoutIntent);
            }
        });




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
            case R.id.action_logout:
                pref.edit().clear().commit();
                Intent logoutIntent = new Intent(DatabaseInvetoryActivity.this, LoginActivity.class);
                startActivity(logoutIntent);
                Toast.makeText(DatabaseInvetoryActivity.this, "Logged Out",Toast.LENGTH_SHORT).show();
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
            //final CloudQuery query = new CloudQuery(getIntent().getExtras().toString()); //???
            final CloudQuery query = new CloudQuery(data); // Change later to Organizations
            //loop through which table was picked in organization activity.
            /*for (int k = 0; k < query., ++k){

            }*/
            try {
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            //int num = 100;
                            for (int i = 0; i < x.length; ++i) {
                                listFood.add((String)x[i].get("Name"));
                                listFood.add(x[i].get("Quantity").toString() + " / 100");

                                //if((Integer)x[i].get("Quantity") >= 100)
                                //{
                                    //gridView.setBackgroundColor(Color.parseColor("#FF0000"));
                                //}
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
