package com.example.oleh.myapplication;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import io.cloudboost.CloudApp;

public class MainActivity extends AppCompatActivity {

    TextView text;
    public Button contButton;
    
    public void init()
    {
        contButton = (Button)findViewById(R.id.contButton);

        contButton.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View v)
            {
                Intent intent = new Intent(MainActivity.this,LoginActivity.class);

                startActivity(intent);

            }
        });
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
