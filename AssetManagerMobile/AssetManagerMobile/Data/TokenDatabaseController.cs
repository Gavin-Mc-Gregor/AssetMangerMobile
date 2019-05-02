using AssetManagerMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AssetManagerMobile.Data
{
    public class TokenDatabaseController
    {
        static object locker = new object();
        SQLiteConnection Database;

        public TokenDatabaseController()
        {
            Database = DependencyService.Get<ISqlite>().GetConnection();
            Database.CreateTable<CToken>();
        }

        public CToken GetToken()
        {
            lock (locker)
            {
                if (Database.Table<CToken>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return Database.Table<CToken>().First();
                }
            }
        }

        public int SaveToken(CToken token)
        {
            lock (locker)
            {
                if (token.Id != 0)
                {
                    Database.Update(token);
                    return token.Id;
                }
                else
                {
                    return Database.Insert(token);
                }
            }
        }
    }
}
