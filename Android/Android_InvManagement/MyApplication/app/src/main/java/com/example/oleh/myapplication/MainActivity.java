package com.example.oleh.myapplication;

import android.app.Activity;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import io.cloudboost.CloudApp;

public class MainActivity extends AppCompatActivity {

    TextView text;
    public Button contButton;

    public void init() {
        if (CheckNetwork.isInternetAvailable(MainActivity.this)) {

            contButton = (Button) findViewById(R.id.contButton);

            contButton.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent(MainActivity.this, LoginActivity.class);

                    startActivity(intent);

                }
            });
        }
        else
        {
            Toast.makeText(MainActivity.this, "No Internet Connection", Toast.LENGTH_SHORT).show();

        }
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Inventory Management");
        setContentView(R.layout.activity_main);

        init();
        text = (TextView)findViewById(R.id.welcomeText);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.main,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        switch (item.getItemId())
        {
            case R.id.action_info:
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.setMessage("Inventory Manager is a program worked on as part of a school project at Full Sail University. \n\n Contributors: \n Brandon Bigelow \n Cristobal Hall-Ramos \n Gabriel Leo \n Oleh Harkusha").setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                }).setTitle("Info").create();
                alert.show();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }
}
