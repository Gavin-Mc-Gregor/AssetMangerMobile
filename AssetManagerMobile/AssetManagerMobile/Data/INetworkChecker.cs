using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagerMobile.Data
{
    public interface INetworkChecker
    {
        bool IsConnected { get; set; }
        void CheckInternetConnection();
    }
}
