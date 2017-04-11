using Android.App;
using Android.Content.PM;
using Android.OS;
using dotnetTurtle.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace dotnetTurtle.Droid
{
    [Activity(Label = "dotnetTurtle.Android", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            
            LoadApplication(new App());
         }

        

        
    }
}