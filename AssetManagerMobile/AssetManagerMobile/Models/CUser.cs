using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagerMobile.Models
{
    public class CUser
    {
     
        [PrimaryKey]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public  CUser()
        {
        }
     
        public void SetUser(string Password, string Username)
        {
            this.Password = Password;
            this.Username = Username;
        }
        public bool ValidateText()
        {
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
                return false;
            else
                return true;
        }
    }
}
