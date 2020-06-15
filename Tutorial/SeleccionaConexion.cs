
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tutorial
{
    [Activity(Label = "SeleccionaConexion")]
    public class SeleccionaConexion : Activity
    {
        Button wifi;
        Button bluetooth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_selecciona_conexion);

            wifi = FindViewById<Button>(Resource.Id.wifi);
            bluetooth = FindViewById<Button>(Resource.Id.bluetooth);
            wifi.Click += delegate {
                //A Wifi
                var intent = new Intent(this, typeof(WiFi));
                StartActivity(intent);
            };

            bluetooth.Click += delegate {
                //A Bluetooth
                var intent = new Intent(this, typeof(Bluetooth));
                StartActivity(intent);
            };
        }

    }
}
