using AntrojiProgramavimoPraktika.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AntrojiProgramavimoPraktika.Repos
{
    public class UserR
    {
       
       
        public User GetUsers(DB db, string Username, string Password)
        {
            
            string username;
            string password;
           
            username = Username;
            password = Password;
            try
            {
                db.openConnection();
                MySqlCommand cmd = new MySqlCommand("select * from student where username=@u and password=@p;", db.getConnection());
                cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
                MySqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                     username = (string)reader["username"];
                     password = (string)reader["password"];
                    return new User(username, password, "student");
                }
              
                reader.Close();
                
                MySqlCommand cmdt = new MySqlCommand("select * from teacher where username=@u and password=@p;",db.getConnection());
                cmdt.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                cmdt.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
                MySqlDataReader readerT = cmdt.ExecuteReader();
                if (readerT.Read())
                {
                     username = (string)readerT["username"];
                     password = (string)readerT["password"];
                    return new User(username, password, "teacher");
                }
                
                readerT.Close();
                
                MySqlCommand cmda = new MySqlCommand("select * from admin where username=@u and password=@p;", db.getConnection());
                cmda.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                cmda.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
                MySqlDataReader readerA = cmda.ExecuteReader();
                if (readerA.Read())
                {
                     username = (string)readerA["username"];
                     password = (string)readerA["password"];
                    return new User(username, password, "admin");
                }
                
                readerA.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            
            return new User();
        }

       
    }
}
