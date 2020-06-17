
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
    [Activity(Label = "Comandos")]
    public class Comandos : Activity, IFinishPrintScreen, IFinishRead, IFinishTransaction, IFinishRandomKey, IFinishLoadKey, IFinishPrint
    {
        Button commandz2, commandc51, commandc54, commandz10, commandz11, imprimir;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_comandos);
            // Create your application here

            commandz2 = FindViewById<Button>(Resource.Id.commandz2);
            commandc51 = FindViewById<Button>(Resource.Id.commandc51);
            commandc54 = FindViewById<Button>(Resource.Id.commandc54);
            commandz10 = FindViewById<Button>(Resource.Id.commandz10);
            commandz11 = FindViewById<Button>(Resource.Id.commandz11);
            imprimir = FindViewById<Button>(Resource.Id.imprimir);

            commandz2.Click += delegate {
                Methods.PrintScreen(this, "Hola mundo");
            };

            commandc51.Click += delegate {
                Methods.Read(this, "12.34", 3, 0);
            };

            commandc54.Click += delegate {
                Methods.Transaction(this, "123456", "71709F180441424344860D841E0000087AE24D52F6688995860D841E000008EDDE5B5C68879C5D860D841E00000803CCEEB506DC6018860D841E00000875057748123D2744860D841E00000879254CE01E7B119F860D841E000008400FC89F473BA6D6860D841E0000080DBA069743347583", null,
                        "00", "1", "0",
                        "0", "", "0", "BBVA");
            };

            commandz10.Click += delegate {
                Methods.RandomKey(this);
            };

            commandz11.Click += delegate {
                Methods.LoadKey(this, "! EX00068 97FF3455DDFF2233DD556677889900440102012345678AE000010000000100000000");
            };

            imprimir.Click += delegate {
                Methods.Print(this, "Hola mundo, esto es una impresión");
            };

        }
        public void FinishLoadKey(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza LoadKey", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }

        public void FinishPrint(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza Print", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }

        public void FinishPrintScreen(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza PrintScreen", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }

        public void FinishRandomKey(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza RandomKey", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }

        public void FinishRead(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza Read", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }

        public void FinishTransaction(bool p0, string p1)
        {
            if (p0)
            {
                Toast.MakeText(Application.Context, "Finaliza Transaction", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, p1, ToastLength.Short).Show();
            }
        }
    }
}
