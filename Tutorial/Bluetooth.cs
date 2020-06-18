﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Util;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using MX.Digitalcoaster.Socketexample.Async;
using MX.Digitalcoaster.Socketexample.Xamarin;
using MX.Digitalcoaster.Socketexample.Xamarin.Adaptator;

namespace Tutorial
{
    [Activity(Label = "Bluetooth")]
    public class Bluetooth : Activity, IBluetoothConnection, IBluetoothPairedDevices, IBluetoothUnpairedDevices
    {
        Button btnOnOff, btnDiscoverable, btnFindUnpairedDevices, btnFindPairedDevices;
        ListView lvDevicesUnpaired;

        public void FinishBluetoothConnection(bool p0)
        {
            throw new NotImplementedException();
        }

        public void SearchPairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("PAIRED DEVICES");
            if (p0.Count > 0)
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    Console.WriteLine("Dispositivo:"+p0[i].Name);
                    Console.WriteLine("Dispositivo:" + p0[i].Address);
                }
            }
        }

        public void SearchUnpairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("UNPAIRED DEVICES");
            if (p0.Count > 0)
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    Console.WriteLine("Dispositivo:" + p0[i].Name);
                    Console.WriteLine("Dispositivo:" + p0[i].Address);
                }
            }
        }

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

            MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth bluetooth = new MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth();
            bluetooth.Initializate(this, this, this, this);


            btnOnOff.Click += delegate
            {
                bluetooth.OnOff();
            };

            btnDiscoverable.Click += delegate
            {
                bluetooth.Discoverable();
            };

            btnFindUnpairedDevices.Click += delegate
            {
                bluetooth.FindUnpairedDevices();
            };

            btnFindPairedDevices.Click += delegate
            {
                bluetooth.FindPairedDevices();
            };


        }
    }
        
}
