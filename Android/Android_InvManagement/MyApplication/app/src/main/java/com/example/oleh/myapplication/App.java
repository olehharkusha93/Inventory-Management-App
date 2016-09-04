package com.example.oleh.myapplication;

import android.app.Activity;
import android.app.Application;
import android.util.Log;

import io.cloudboost.CloudApp;
import io.cloudboost.CloudUser;

/**
 * Created by Oleh on 8/11/2016.
 */
public class App extends Application {
    public static CloudUser CURRENT_USER=null;
    @Override
    public void onCreate() {
            super.onCreate();
        Log.d("App", "onCreate(");
        CloudApp.init("myrrjdcqzjzz", "960f3835-dd13-47dc-828c-578ef80564b8");
    }
    public static void logout(){
        CURRENT_USER=null;
        CloudUser.setCurrentUser(null);
    }

}
