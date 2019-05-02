using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssetManagerMobile.Data;
using AssetManagerMobile.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]

namespace AssetManagerMobile.Droid.Data
{
    class NetworkConnection : INetworkChecker
    {
        public bool IsConnected { get ; set ; }

        public void CheckInternetConnection()
        {
            var Connectivity = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetwork = Connectivity.ActiveNetworkInfo;
            if (ActiveNetwork != null && ActiveNetwork.IsConnectedOrConnecting)
            {
                IsConnected = true;
            }
            else
            {
                IsConnected = false;
            }
        }
    }
}