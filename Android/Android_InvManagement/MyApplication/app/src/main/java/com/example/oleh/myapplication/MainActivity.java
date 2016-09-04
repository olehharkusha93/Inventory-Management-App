package com.example.oleh.myapplication;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
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
}
