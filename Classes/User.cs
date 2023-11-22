using AntrojiProgramavimoPraktika.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AntrojiProgramavimoPraktika.Classes
{
    public class User 
    {
        private string Username;
        private string Password;
        private string Permission;
       
        public User(string username, string password, string permission) {
            
            Username = username;
            Password = password;
            Permission = permission;
        }

        public User() { }
        public string getUsername()
        {
            return this.Username;
        }

      public void setUsername(string username)
        {
            this.Username = username;
        }

        public void setPassword(string password)
        {
            this.Password = password;
        }

        public string getPermission()
        {
            return this.Permission;
        }

        public string GetPassword()
        {
            return this.Password;
        }


    }
}
