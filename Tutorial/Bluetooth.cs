
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
using MX.Digitalcoaster.Socketexample.Async;
using MX.Digitalcoaster.Socketexample.Xamarin;

namespace Tutorial
{
    [Activity(Label = "Bluetooth")]
    public class Bluetooth : Activity, IBluetoothConnection
    {
        Button btnOnOff, btnDiscoverable, btnFindUnpairedDevices, btnFindPairedDevices;
        MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth bluetooth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_bluetooth);

            btnOnOff = FindViewById<Button>(Resource.Id.btnOnOff);
            btnDiscoverable = FindViewById<Button>(Resource.Id.btnDiscoverable);
            btnFindUnpairedDevices = FindViewById<Button>(Resource.Id.btnFindUnpairedDevices);
            btnFindPairedDevices = FindViewById<Button>(Resource.Id.btnFindPairedDevices);

            //Inicializando Bluetooth
            bluetooth = new MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth();
            bluetooth.Initializate(this, this);

            btnOnOff.Click += delegate {
                bluetooth.OnOff();
            };

            btnDiscoverable.Click += delegate {
                bluetooth.Discoverable();
            };

            btnFindUnpairedDevices.Click += delegate {
                bluetooth.FindUnpairedDevices();
            };

            btnFindPairedDevices.Click += delegate {
                bluetooth.FindPairedDevices();
            };

        }

        public void FinishBluetoothConnection(bool p0)
        {
            if (p0)
            {
                var intent = new Intent(this, typeof(Comandos));
                StartActivity(intent);
            }
            else
            {
                Toast.MakeText(Application.Context, "Error de conexion", ToastLength.Short).Show();
            }
        }
    }
}
