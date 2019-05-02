using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AssetManagerMobile.iOS.Data;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLite_IOS))]
namespace AssetManagerMobile.iOS.Data
{
    public class SqlLite_IOS : ISqlite
    {
        public SqlLite_IOS() { }
        public SQLiteConnection GetConnection()
        {
            var fileName = "AssetDB.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;

        }
    }
}