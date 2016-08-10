package com.example.oleh.myapplication;

import android.content.Context;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {

    Context c;
    EditText Email, Password;
    public Button loginButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);



        c = this;
        Email = (EditText)findViewById(R.id.Email);
        Password = (EditText)findViewById(R.id.Password);
        loginButton = (Button)findViewById(R.id.loginButton);
        final TextView signUp = (TextView)findViewById(R.id.tvSignUP);

        if (signUp != null) {
            signUp.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent signUpIntent = new Intent(LoginActivity.this, RegisterActivity.class);
                    LoginActivity.this.startActivity(signUpIntent);
                }
            });
        }

        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v)
            {
                String username = Email.getText().toString();
                String password = Password.getText().toString();

                if(username.length() == 0 || password.length() == 0)
                {
                    Toast.makeText(c, "Please fill in Email or Password", Toast.LENGTH_SHORT).show();
                    return;
                }
                if(username.contains("oleh93") && password.contains("oleh93"))
                {
                    Intent databaseInventoryIntent = new Intent(LoginActivity.this, DatabaseInvetoryActivity.class);
                    LoginActivity.this.startActivity(databaseInventoryIntent);
                }
            }
        });




    }
}
