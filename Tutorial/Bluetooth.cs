
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
using MX.Digitalcoaster.Socketexample.Xamarin;

namespace Tutorial
{
    [Activity(Label = "Bluetooth")]
    public class Bluetooth : Activity
    {
        Button btnOnOff, btnDiscoverable, btnFindUnpairedDevices, btnFindPairedDevices;
        ListView lvDevicesUnpaired;
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
            lvDevicesUnpaired = FindViewById<ListView>(Resource.Id.lvDevicesUnpaired);

            //Inicializando Bluetooth
            bluetooth = new MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth();
            bluetooth.Initializate(this, lvDevicesUnpaired);

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
    }
}
