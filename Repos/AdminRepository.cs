using AntrojiProgramavimoPraktika.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiProgramavimoPraktika.Repos
{
    public class AdminRepository : IUserRepository<Admin>
    {
     
        public void AddGrade(string tusername, string firstword, string secondword, string subject, string worktype, string grade)
        {
            throw new NotImplementedException();
        }

        public void addStudent()
        {
            throw new NotImplementedException();
        }

        public string getPermission()
        {
            throw new NotImplementedException();
        }

        public string getUsername()
        {
            throw new NotImplementedException();
        }

        public void GetUsers()
        {
            throw new NotImplementedException();
        }

        public void setPassword(string password)
        {
            throw new NotImplementedException();
        }

        public void setUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdateInfo(string username, string password, string user)
        {
            throw new NotImplementedException();
        }
    }
}
