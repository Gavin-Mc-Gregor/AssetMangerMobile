using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AssetManagerMobile.Models
{
    public class CConstants
    {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.FromHex("#7C7CD7");
        public static Color MainTextColor = Color.FromHex("#aaaaaa");

        public static string LoginUrl = "http://localhost:6001/users/DoLogin";
        public static string GetItemsUrl = "http://localhost:6001/items";
    }
}
