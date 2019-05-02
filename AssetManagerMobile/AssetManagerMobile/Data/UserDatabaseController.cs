using AssetManagerMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AssetManagerMobile.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();
        SQLiteConnection Database;

        public UserDatabaseController()
        {
            Database = DependencyService.Get<ISqlite>().GetConnection();
            Database.CreateTable<CUser>();
        }
        public CUser GetUser()
        {
            lock (locker)
            {
                if(Database.Table<CUser>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return Database.Table<CUser>().First();
                }
            }
        }
        public int SaveUser(CUser user)
        {
            lock (locker)
            {
                if(user.Id != 0)
                {
                    Database.Update(user);
                    return user.Id;
                }
                else
                {
                    return Database.Insert(user);
                }
            }
        }
        
    }
}
