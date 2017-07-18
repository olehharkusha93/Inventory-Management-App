package com.example.oleh.myapplication;


import android.app.Application;
import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SearchRecentSuggestionsProvider;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;
import android.content.Context;


import io.cloudboost.CloudApp;
import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudObjectCallback;
import io.cloudboost.CloudUser;
import io.cloudboost.CloudUserCallback;
import io.cloudboost.*;



public class RegisterActivity extends AppCompatActivity {


    public ProgressDialog pdialog;
    public Button registerButton;
    Context c;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Sign Up");
        setContentView(R.layout.activity_register);
        pdialog=new ProgressDialog(this);
        c = this;

        final EditText etName = (EditText) findViewById(R.id.etName);
        final EditText etUsername = (EditText) findViewById(R.id.etUsername);
        final EditText etPassword = (EditText) findViewById(R.id.etPassword);
        final EditText etAge = (EditText) findViewById(R.id.etAge);

        registerButton = (Button) findViewById(R.id.registerButton);

        //assert registerButton != null;
        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //assert etName != null;
                String name = etName.getText().toString();
                //assert etUsername != null;
                String username = etUsername.getText().toString();
                //assert etPassword != null;
                String password = etPassword.getText().toString();
                //assert etAge != null;
                //Integer age = Integer.parseInt(etAge.getText().toString());
                String age = etAge.getText().toString();

                if(name.length() == 0 || username.length() == 0 || password.length() == 0 || age.length() == 0) {
                    Toast.makeText(c, "Please fill in all the fields", Toast.LENGTH_SHORT).show();
                    return;
                }
                else {
                    doRegister(username, password, name, age);
                }

            }
        });


    }

    public void doRegister(String uname,String pass, String emailname,String uage)
    {
        new signup().execute(uname,pass,emailname,uage.toString());
    }

    public class signup extends AsyncTask<String,String,String>
    {
        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();
            pdialog.setMessage("Creating Account...");
            pdialog.show();
        }
        @Override
        protected void onPostExecute(String result)
        {
            super.onPostExecute(result);
            pdialog.dismiss();
        }
        @Override
        protected String doInBackground(String...params)
        {
            CloudUser user = new CloudUser();
            user.setUserName(params[0]);
            user.setPassword(params[1]);
            user.setEmail(params[2]);
            try
           {
               user.set("Age", params[3]);
               user.signUp(new CloudUserCallback() {
                   @Override
                   public void done(CloudUser user, CloudException e) throws CloudException {
                       if(e != null)
                           throw e;
                       else
                       {
                           runOnUiThread(new Runnable() {
                               @Override
                               public void run() {
                                   Toast.makeText(c,"CREATED", Toast.LENGTH_SHORT).show();
                               }
                           });

                           CloudUser.setCurrentUser(user);
                           App.CURRENT_USER = user;
                           Intent i = new Intent(RegisterActivity.this, LoginActivity.class);
                           startActivity(i);

                       }
                   }
               });
           }catch (final CloudException e)
           {
               Log.e("RegisterActivity", e.getMessage());
               runOnUiThread(new Runnable() {
                   @Override
                   public void run() {
                       Toast.makeText(c,e.getMessage(),Toast.LENGTH_SHORT).show();
                   }
               });
           }
            return null;
        }

    }
}