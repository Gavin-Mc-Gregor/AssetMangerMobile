using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace AssetManagerMobile.BL.Connection
{
    class CConnection
    {
        private static CConnection UniqueConnection;

        CConnection() { }
        public CConnection GetInstance()
        {
            if(UniqueConnection == null)
            {
                UniqueConnection = new CConnection();
            }
            return UniqueConnection;
        }

    }
}
