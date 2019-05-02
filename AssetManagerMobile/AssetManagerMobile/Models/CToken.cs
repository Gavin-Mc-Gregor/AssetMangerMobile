using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagerMobile.Models
{
    public class CToken
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDiscription { get; set; }
        public DateTime ExpityDate { get; set; }
        public int ExpiresIn { get; set; }
        public CToken()
        {
        }
    }
}
