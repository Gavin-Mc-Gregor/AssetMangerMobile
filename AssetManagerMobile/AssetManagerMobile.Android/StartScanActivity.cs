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
using AssetManagerMobile.Data;
using AssetManagerMobile.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StartScanActivity))]
namespace AssetManagerMobile.Droid
{
    [Activity(Label = "StartScanActivity")]
    
    public class StartScanActivity : IQrScanner
    {
        public void StartNativeActivity()
        {
            var intent = new Intent(Forms.Context, typeof(ScanActivity));
            Forms.Context.StartActivity(intent);
        }

    
    }
}