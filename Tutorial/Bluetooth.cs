
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
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;

namespace Tutorial
{
    [Activity(Label = "Bluetooth")]
    public class Bluetooth : Activity, IBluetoothConnection, IBluetoothPairedDevices, IBluetoothUnpairedDevices
    {
        Button btnOnOff, btnDiscoverable, btnFindUnpairedDevices, btnFindPairedDevices, permissions;
        ListView lvDevices;

        //Array
        string[] devices;
        ArrayAdapter myAdapter;

        //Inicialización
        MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth bluetooth;

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

        public void SearchPairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("PAIRED DEVICES");

            if (p0.Count > 0)
                devices = new String[p0.Count];
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    devices[i] = "Dispositivo:" + p0[i].Name + ", " + p0[i].Address;
                    Console.WriteLine(devices[i]);

                }
            }

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, devices);
            lvDevices.SetAdapter(myAdapter);
            myAdapter.NotifyDataSetChanged();
        }

        public void SearchUnpairedDevices(IList<BluetoothDevice> p0)
        {
            Console.WriteLine("UNPAIRED DEVICES");

            if (p0.Count > 0)
                devices = new String[p0.Count];
            {
                for (int i = 0; i < p0.Count; i++)
                {
                    devices[i] = "Dispositivo:" + p0[i].Name + ", "+p0[i].Address;
                    Console.WriteLine(devices[i]);

                }
            }

            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, devices);
            lvDevices.SetAdapter(myAdapter);
            myAdapter.NotifyDataSetChanged();
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
            permissions = FindViewById<Button>(Resource.Id.permissions); 
            lvDevices = FindViewById<ListView>(Resource.Id.lvDevicesUnpaired);

            devices = new string[] {"Esperando"};


            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, devices);
            lvDevices.SetAdapter(myAdapter);

            lvDevices.ItemClick += (s, e) => {
                var t = devices[e.Position];
                Toast.MakeText(Application.Context, t, ToastLength.Short).Show();
                int position = e.Position;
                bluetooth.MakeBinding(position);
            };

            bluetooth = new MX.Digitalcoaster.Socketexample.Xamarin.Bluetooth();
            bluetooth.Initializate(this, this, this, this);

            permissions.Click += delegate
            {
                checkBTPermissions();
            };

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

        /**
         * This method is required for all devices running API23+
         * Android must programmatically check the permissions for bluetooth. Putting the proper permissions
         * in the manifest is not enough.
         * <p>
         * NOTE: This will only execute on versions > LOLLIPOP because it is not needed otherwise.
         */
        private void checkBTPermissions()
        {
            if (Build.VERSION.SdkInt > BuildVersionCodes.Lollipop)
            {
                if ((ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted) && (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == (int)Permission.Granted))
                {

                    this.RequestPermissions(new String[] { Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessCoarseLocation }, 1001); //Any number
                }
            }
            else
            {
                Log.Info("Bluetooth", "checkBTPermissions: No need to check permissions. SDK version < LOLLIPOP.");
            }
        }
    }
        
}
