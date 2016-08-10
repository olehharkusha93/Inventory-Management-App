package com.example.oleh.myapplication;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.SearchView;
import android.widget.ListView;
import android.widget.TextView;

public class DatabaseInvetoryActivity extends AppCompatActivity {
    TextView text;
    ListView list;
    SearchView search;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_database_invetory);

        text = (TextView)findViewById(R.id.inventoryLabel);
        //search = (SearchView)findViewById(R.id.searchView);
        //list = (ListView)findViewById(R.id.invList);
    }
}
