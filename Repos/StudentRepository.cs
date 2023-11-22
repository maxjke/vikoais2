using AntrojiProgramavimoPraktika.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.WireFormat;
using System.Xml.Linq;
using System.Windows;

namespace AntrojiProgramavimoPraktika.Repos
{
   public class StudentRepository : IUserRepository<Student>
    {
        public void AddGrade()
        {
            throw new NotImplementedException();
        }

        public void AddGrade(Teacher teacher)
        {
            throw new NotImplementedException();
        }

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

        public void UpdateInfo(string username, string password, string user)
        {
            DB db = new DB();
            try
            {
                db.openConnection();
               
                string query = "UPDATE student \r\nSET username = @u, password = @pwd \r\nWHERE id IN (\r\n    SELECT id FROM (\r\n        SELECT id FROM student WHERE username = @Un\r\n    ) AS temp\r\n);\r\n";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@Un", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = password;


                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sėkmingai pakeisti duomenys");
                }
                else
                {
                    MessageBox.Show("Klaida");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
