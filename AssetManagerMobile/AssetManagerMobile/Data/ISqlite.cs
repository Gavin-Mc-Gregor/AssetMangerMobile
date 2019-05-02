using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagerMobile
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
