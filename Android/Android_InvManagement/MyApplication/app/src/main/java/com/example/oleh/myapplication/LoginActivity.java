package com.example.oleh.myapplication;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.app.ProgressDialog;

import io.cloudboost.CloudException;
import io.cloudboost.CloudUser;
import io.cloudboost.CloudUserCallback;


public class LoginActivity extends AppCompatActivity implements CompoundButton.OnCheckedChangeListener {

    Context c;
    EditText Email, Password;
    CheckBox rememberMe;
    SharedPreferences pref;
    SharedPreferences.Editor editor;

    boolean checkFlag;

    public Button loginButton;
    public ProgressDialog pdialog;




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Login");
        setContentView(R.layout.activity_login);

        pdialog = new ProgressDialog(this);
        c = this;
        Email = (EditText) findViewById(R.id.Email);
        Password = (EditText) findViewById(R.id.Password);
        rememberMe = (CheckBox) findViewById(R.id.checkBox);
        rememberMe.setOnCheckedChangeListener(this);
        checkFlag = rememberMe.isChecked();
        loginButton = (Button) findViewById(R.id.loginButton);
        final TextView signUp = (TextView) findViewById(R.id.tvSignUP);

        pref = getSharedPreferences("login.config", Context.MODE_PRIVATE);
        editor = pref.edit();

        String rmUsername = pref.getString("username", "");
        String rmPassword = pref.getString("password", "");

        if(!(rmUsername.equals("") && rmPassword.equals(""))){
            doLogin(rmUsername, rmPassword);

        }
       /* editor.putString("username", Email.getText().toString());
        editor.putString("password", Password.getText().toString());
        editor.apply();

        pref.getString("username","");
        pref.getString("password","");*/


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
            public void onClick(View v) {
                String username = Email.getText().toString();
                String password = Password.getText().toString();



                if (username.length() == 0 || password.length() == 0) {
                    Toast.makeText(c, "Please fill in Email or Password", Toast.LENGTH_SHORT).show();
                    return;
                } else {
                    doLogin(username, password);
                }
                /*if(username.contains("oleh93") && password.contains("oleh93"))
                {
                    Intent databaseInventoryIntent = new Intent(LoginActivity.this, DatabaseInvetoryActivity.class);
                    LoginActivity.this.startActivity(databaseInventoryIntent);
                }*/
            }
        });
    }


    public void doLogin(String uname, String upass)
    {
        new login().execute(uname, upass);
    }

    @Override
    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
        checkFlag = isChecked;
    }

    class login extends AsyncTask<String,String,String>
    {
        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            pdialog.setMessage("Authenticating...");
            pdialog.show();
        }
        @Override
        protected void onPostExecute(String result)
        {
            super.onPostExecute(result);
            pdialog.dismiss();
        }
        @Override
        protected String doInBackground(final String... params)
        {
            final CloudUser user = new CloudUser();
            user.setUserName(params[0]);
            user.setPassword(params[1]);
            try
            {
                user.logIn(new CloudUserCallback() {
                    @Override
                    public void done(CloudUser user, CloudException e) throws CloudException {
                        if(e != null)
                            throw e;
                        else
                        {
                            if(checkFlag) {
                                // Remember Me
                                editor.putString("username", Email.getText().toString());
                                editor.putString("password", Password.getText().toString());
                                editor.apply();

                            }
                            App.CURRENT_USER=user;
                            Intent databaseInventoryIntent = new Intent(LoginActivity.this, DatabaseInvetoryActivity.class);
                            LoginActivity.this.startActivity(databaseInventoryIntent);
                        }
                    }
                });
            } catch (final CloudException e) {
                Log.e("LoginActivity", e.getMessage());
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Toast.makeText(LoginActivity.this, e.getMessage(),Toast.LENGTH_SHORT).show();
                        //Email.setText("");
                        //Password.setText("");


                    }
                });
            }
            return null;
        }

    }
}
