package com.example.oleh.myapplication;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.support.annotation.NonNull;
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

import com.facebook.CallbackManager;
import com.facebook.FacebookCallback;
import com.facebook.FacebookException;
import com.facebook.FacebookSdk;
import com.facebook.login.LoginResult;
import com.facebook.login.widget.LoginButton;
import com.google.android.gms.auth.api.Auth;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.auth.api.signin.GoogleSignInResult;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.SignInButton;
import com.google.android.gms.common.api.GoogleApiClient;

import java.util.Timer;
import java.util.TimerTask;

import io.cloudboost.CloudException;
import io.cloudboost.CloudUser;
import io.cloudboost.CloudUserCallback;


public class LoginActivity extends AppCompatActivity implements CompoundButton.OnCheckedChangeListener, GoogleApiClient.OnConnectionFailedListener {

    Context c;
    EditText Email, Password;
    CheckBox rememberMe;
    SharedPreferences pref;
    SharedPreferences.Editor editor;

    boolean checkFlag;

    public Button loginButton;
    public ProgressDialog pdialog;

    //Google Sign In
    private SignInButton login;
    private TextView name;
    private GoogleApiClient googleApiClient;
    private GoogleSignInOptions signInOptions;
    private static final int REQUEST_CODE = 100;

    // Facebook Sign In
    private TextView info;
    private LoginButton fbLoginButton;
    private CallbackManager callbackManager;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setTitle("Login");
        FacebookSdk.sdkInitialize(getApplicationContext());
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

        //Google Sign In Button
        signInOptions = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN).requestEmail().build();
        googleApiClient = new GoogleApiClient.Builder(this).enableAutoManage(this,this).addApi(Auth.GOOGLE_SIGN_IN_API,signInOptions).build(); //need fix
        login = (SignInButton)findViewById(R.id.Login);
        name = (TextView)findViewById(R.id.name);
        login.setSize(SignInButton.SIZE_WIDE);
        login.setScopes(signInOptions.getScopeArray());

        // Facebook Sign In
        //FacebookSdk.sdkInitialize(getApplicationContext());
        callbackManager = CallbackManager.Factory.create();
        //setContentView(R.layout.activity_login);
        fbLoginButton = (LoginButton)findViewById(R.id.FacebookLogin);
        info = (TextView)findViewById(R.id.FacebookInfo);

        //Empty Fields
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
            }
        });

        // Login with Google Button Click
        login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent signInIntent = Auth.GoogleSignInApi.getSignInIntent(googleApiClient);
                startActivityForResult(signInIntent,REQUEST_CODE);
            }
        });


        // Login in with Facebook callback
        fbLoginButton.registerCallback(callbackManager, new FacebookCallback<LoginResult>() {
            @Override
            public void onSuccess(LoginResult loginResult) {
                info.setText("User ID: "
                        + loginResult.getAccessToken().getUserId()
                        + "\n"
                        + "Auth Token"
                        + loginResult.getAccessToken().getToken());
            }


            @Override
            public void onCancel() {
                info.setText("Login attempt canceled");
            }

            @Override
            public void onError(FacebookException e) {
                info.setText("Login attempt failed");
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
    //Google Sign In
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data){
        super.onActivityResult(requestCode,resultCode,data);

        if(requestCode == REQUEST_CODE)
        {
            GoogleSignInResult result = Auth.GoogleSignInApi.getSignInResultFromIntent(data);
            GoogleSignInAccount account = result.getSignInAccount();

            Intent databaseInventoryIntent = new Intent(LoginActivity.this, /*DatabaseInvetoryActivity*/OrganizationActivity.class);
            LoginActivity.this.startActivity(databaseInventoryIntent);
        }
    }
    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {

    }
    //Google Sign In end


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
            //super.onPostExecute(result);
            //.dismiss();
            //Trying out delay for listView to load
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
                            Intent databaseInventoryIntent = new Intent(LoginActivity.this, OrganizationActivity.class);//Used to go to Database
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
