using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagerMobile.BL.Login
{
    class CLogin
    {
        private static CLogin UniqueLogin;

        private CLogin()
        {

        }

        public CLogin GetInstance()
        {
            if(UniqueLogin == null)
            {
                UniqueLogin = new CLogin();
            }
            return UniqueLogin; 
        }
        public void DoLogin()
        {

        }
    }
}
