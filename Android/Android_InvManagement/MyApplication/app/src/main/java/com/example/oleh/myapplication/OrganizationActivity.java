package com.example.oleh.myapplication;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Handler;
import android.preference.PreferenceManager;
import android.support.v4.widget.SwipeRefreshLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.SearchView;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Timer;
import java.util.TimerTask;

import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectArrayCallback;
import io.cloudboost.CloudQuery;
import io.cloudboost.CloudTable;
import io.cloudboost.CloudTableArrayCallback;
import io.cloudboost.CloudTableCallback;
import io.cloudboost.CloudUser;

public class OrganizationActivity extends AppCompatActivity {

    ListView listView;
    List<String> listOrganizations;
    TextView organization;
    ArrayAdapter<String> adapter;
    public ProgressDialog pdialog;
    Context c;
    String value;
    SwipeRefreshLayout SwipeRefreshLayout;
    private Handler handler = new Handler();
    public static Bundle MyTable = new Bundle();
    //SearchView searchView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Organizations");
        setContentView(R.layout.activity_organization);
        c = this;


        organization = (TextView)findViewById(R.id.organizationTV);
        pdialog = new ProgressDialog(this);
        listOrganizations = new ArrayList<String>();
        listView = (ListView) findViewById(R.id.organizationlistView);
        adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, listOrganizations);

        // To change listView text color based on string
        /*{
            @Override
            public View getView(int position,View convertView,ViewGroup parent){
                View view = super.getView(position,convertView,parent);
                TextView textView = (TextView)view.findViewById(android.R.id.text1);
                String text = textView.getText().toString();
                if(text.contains("Test")) {
                    textView.setTextColor(Color.BLUE);
                }
                else if(text.contains("Organization")){
                    textView.setTextColor(Color.RED);
                }

                return view;
            }
        };*/
        new Query().execute();
        listView.setAdapter(adapter);
        SwipeRefreshLayout = (SwipeRefreshLayout)findViewById(R.id.activity_swipe_refresh_layout);
        //listView.invalidateViews();
        //SwipeRefreshLayout.setOnRefreshListener(new SwipeRefreshLayout.setOnRefreshListener()

        /*assert searchView != null;
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {

                adapter.getFilter().filter(newText);
                return false;
            }
        });*/


        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                int itempos = position;
                value = (String)listView.getItemAtPosition(position);

                //Works...=/
                //String item = listView.getSelectedItem().toString();
                Intent databaseInventoryIntent = new Intent(OrganizationActivity.this, DatabaseInvetoryActivity.class);
                databaseInventoryIntent.putExtra("pop",value);
                OrganizationActivity.MyTable.putString("table", value);

                OrganizationActivity.this.startActivity(databaseInventoryIntent);

                Toast.makeText(OrganizationActivity.this,""+value,Toast.LENGTH_SHORT).show();
            }
        });
    }

    /*class orgList implements AdapterView.OnItemClickListener{
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id){
            ViewGroup vg = (ViewGroup)view;
            TextView tv = (TextView)vg.findViewById(R.id.organizationTV);
            Toast.makeText(OrganizationActivity.this,tv.getText().toString(),Toast.LENGTH_SHORT).show();
        }
    }*/

    public class Query extends AsyncTask<String, String, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pdialog.setMessage("Searching...");
            pdialog.show();

        }

        @Override
        protected String doInBackground(String... args) {

            final CloudQuery query = new CloudQuery("User");

            try {
                CloudTable.getAll(new CloudTableArrayCallback() {
                    @Override
                    public void done(CloudTable[] table, CloudException e) throws CloudException {
                        if(table != null){
                            for(int j = 0; j < table.length; ++j){
                                if(!table[j].getTableName().contains("Role") && !table[j].getTableName().contains("User") && !table[j].getTableName().contains("Device"))
                                listOrganizations.add(table[j].getTableName());
                            }
                        }
                        if(e != null){
                        }
                    }
                });
            } catch (CloudException e) {
                e.printStackTrace();
            }

            /*try {
                query.find(new CloudObjectArrayCallback() {
                    @Override
                    public void done(CloudObject[] x, CloudException t) throws CloudException {
                        if (x != null) {
                            for (int i = 0; i < x.length; ++i) {
                                CloudTable.getAll(new CloudTableArrayCallback() {
                                    @Override
                                    public void done(CloudTable[] table, CloudException e) throws CloudException {
                                        if(table != null){
                                            for(int j = 0; j < table.length; ++j){
                                                listOrganizations.add(table[j].getTableName());
                                            }

                                        }
                                        if(e != null){

                                        }
                                    }
                                });

                                listOrganizations.add((String)x[i].get("Organizations"));
                                listOrganizations.add(x[i].get("Organizations").toString()); //Shows all



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
            }*/
            return null;

        }
        //@Override
        //protected void onPostExecute (String result)
        //{
        //    super.onPostExecute(result);
        //    pdialog.dismiss();
//
        //}
        @Override
        protected void onPostExecute(String result){
            long delay = 500;
            Timer timer = new Timer();
            super.onPostExecute(result);
            timer.schedule(new TimerTask() {
                @Override
                public void run() {
                    pdialog.dismiss();
                }
            },delay);
        }
    }
}
