package com.example.oleh.myapplication;

import android.app.Application;
import android.util.Log;

import io.cloudboost.CloudApp;
import io.cloudboost.CloudException;
import io.cloudboost.CloudObject;
import io.cloudboost.CloudUser;


public class RegisterRequest extends Application
{

    public static CloudUser CURRENT_USER = null;

    public void onCreate()
    {
        super.onCreate();


        final String myAppId = "myrrjdcqzjzz";
        final String myKey = "960f3835-dd13-47dc-828c-578ef80564b8";
        CloudApp.init(myAppId,myKey);

        //CloudObject obj = new CloudObject("User");



    }

}
