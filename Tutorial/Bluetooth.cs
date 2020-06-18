
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
        ListView lvDevices;

        //Array
        string[] devices;

        public void FinishBluetoothConnection(bool p0)
        {
            throw new NotImplementedException();
        }

        public void SearchPairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("PAIRED DEVICES");

            if (p0.Count > 0)
                devices = new String[p0.Count];
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    devices[i] = "Dispositivo:" + p0[i].Name + ", p0[i].Address";
                    Console.WriteLine(devices[i]);

                }
            }
        }

        public void SearchUnpairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("UNPAIRED DEVICES");

            if (p0.Count > 0)
                devices = new String[p0.Count];
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    devices[i] = "Dispositivo:" + p0[i].Name + ", p0[i].Address";
                    Console.WriteLine(devices[i]);

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
            lvDevices = FindViewById<ListView>(Resource.Id.lvDevicesUnpaired);

            devices = new string[] { "Sin resultados" , "Mas datos"};

            lvDevices.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, devices);

            lvDevices.ItemClick += (s, e) => {
                var t = devices[e.Position];
                Toast.MakeText(Application.Context, t, ToastLength.Short).Show();
            };

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
