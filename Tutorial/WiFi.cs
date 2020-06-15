
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
//using MX.Digitalcoaster.Socketexample.Async;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Tutorial
{
    [Activity(Label = "WiFi")]
    public partial class WiFi : Activity//, AsyncPort
    {
        internal static Context ActivityContext { get; private set; }


        EditText ip;
        EditText port;
        Button connect;

        public void FinishClosePort(bool p0)
        {
            throw new NotImplementedException();
        }

        public void FinishOpenPort(bool p0)
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_wifi);

            ip = FindViewById<EditText>(Resource.Id.ip);
            port = FindViewById<EditText>(Resource.Id.port);

            connect = FindViewById<Button>(Resource.Id.connect);

            connect.Click += delegate {
                Toast.MakeText(Application.Context, ip.Text, ToastLength.Short).Show();
                IAsyncPorts asyncPorts = new WiFi();

                //AsyncOpenPort asyncOpenPort = new AsyncOpenPort( asyncPorts, ip.Text, port.Text);
                //asyncOpenPort.Execute();*/
            };

        }
    }
}
