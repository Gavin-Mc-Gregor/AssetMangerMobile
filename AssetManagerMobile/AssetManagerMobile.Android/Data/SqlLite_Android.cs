using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AssetManagerMobile.Droid.Data;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLite_Android))]

namespace AssetManagerMobile.Droid.Data
{
    class SqlLite_Android : ISqlite
    {
        SqlLite_Android() { }

        public SQLiteConnection GetConnection()
        {
            var sqlLineFileName = "AssetDB.db3";
            string documentationPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentationPath, sqlLineFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}