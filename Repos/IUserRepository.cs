using AntrojiProgramavimoPraktika.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AntrojiProgramavimoPraktika.Repos
{
    public interface IUserRepository <TEntity>
        where TEntity : User
    {
        string getUsername();

        void setUsername(string username);

        void setPassword(string password);

        string getPermission();

        void addStudent();

        void AddGrade(string tusername, string firstword, string secondword, string subject, string worktype, string grade);

        void UpdateInfo(string username, string password, string user);
    }
}
