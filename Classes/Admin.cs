using AntrojiProgramavimoPraktika.Repos;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AntrojiProgramavimoPraktika.Classes
{
  public class Admin : User
    {


      public void addStudent(Student student)
        {
            // AdminWindow admin = new AdminWindow();

            string username = student.getUsername();
            string name = student.getUsername();
            string lastName = student.getUsername();
            string password = student.getUsername();
            string group = student.getUsername();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Užpildykite visus laukus");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO student (username, password, first_name, last_name) VALUES (@u, @p, @fn, @ln);", db.getConnection());
            command.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@p", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Sekmingai uzregistravote studenta");
            else
                MessageBox.Show("Nepavyko registruoti studento");


            //DB db = new DB();
            //MySqlCommand command = new MySqlCommand("INSERT INTO student (username, password, first_name, last_name) VALUES (@sName, @sPass, @sName, @sPass);", db.getConnection());
            //command.Parameters.Add("@sName", MySqlDbType.VarChar).Value = username;
            //command.Parameters.Add("@sPass", MySqlDbType.VarChar).Value = password;

            //db.openConnection();

            //if (command.ExecuteNonQuery() == 1)
            //    MessageBox.Show("Sekmingai uzregistravote studenta");
            //else
            //    MessageBox.Show("Nepavyko registruoti studento");

            db.closeConnection();
        }
        public bool isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from admin where username = @Auname", db.getConnection());

          //  command.Parameters.Add("@Auname", MySqlDbType.VarChar).Value = Username;
           

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
