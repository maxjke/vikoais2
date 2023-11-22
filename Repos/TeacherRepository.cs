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
   public class TeacherRepository : IUserRepository<Teacher>
    {
        public void AddGrade(string tusername, string firstWord, string secondWord, string subject, string worktype, string grade)
        {

            DB db = new DB();
            try
            {
                db.openConnection();

                string query = "INSERT INTO Grades (subject_id, worktype_id, student_id, semester_id, grade)\r\nVALUES (\r\n\t(SELECT id FROM subject WHERE name = @subject),\r\n    (SELECT id FROM worktype WHERE WorkTypeName = @Wt),\r\n    (SELECT id FROM student WHERE username = (select username from student where firstname = @name and lastName=@lastname)),\r\n    10,\r\n    @grade\r\n);";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                cmd.Parameters.Add("@subject", MySqlDbType.VarChar).Value = subject;
                cmd.Parameters.Add("@Wt", MySqlDbType.VarChar).Value = worktype;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = firstWord;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = secondWord;
                cmd.Parameters.Add("@grade", MySqlDbType.Int32).Value = grade;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Sėkmingai įrašytas pažymys");
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
