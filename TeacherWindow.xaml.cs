using AntrojiProgramavimoPraktika.Classes;
using AntrojiProgramavimoPraktika.Repos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AntrojiProgramavimoPraktika
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public Teacher Teacher = new Teacher();
        public TeacherWindow(Teacher teacher)
        {

            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            FillGradesComboBox();
            Teacher = teacher;

        }

        private void disBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void mainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            LoggedInWindow loggedInWindow = new LoggedInWindow(Teacher);
            loggedInWindow.TeacherBtn.Visibility = Visibility.Visible;
            loggedInWindow.fSemBtn.IsEnabled = false;
            loggedInWindow.sSemBtn.IsEnabled = false;
            loggedInWindow.tSemBtn.IsEnabled = false;
            loggedInWindow.Show();
            this.Close();
        }

        private void kontaktDuomBtn_click(object sender, RoutedEventArgs e)
        {

        }

        private void StudentGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DB db = new DB();
            if (StudentGroups.SelectedItem != null)
            {
                string selectedGroupName = StudentGroups.SelectedItem.ToString();
                string grupe = selectedGroupName;



                try
                {
                    db.openConnection();

                    string query = "select concat(firstname, ' ', lastName) as Studentas from student where groups_id = (select id from `groups` where groupName=@gr);";

                    MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                    cmd.Parameters.Add("@gr", MySqlDbType.VarChar).Value = grupe;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Students.Items.Clear();
                    while (reader.Read())
                    {
                        
                        Students.Items.Add(reader["Studentas"].ToString());
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
            else
            {
                MessageBox.Show("Pasirinkite grupe");
            }
        }

        private void studentGroupsLoaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
           
            try
            {
                db.openConnection();

                string query = "select * from `groups`;";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StudentGroups.Items.Add(reader["groupName"].ToString()); 
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

        private void StudentLoaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            if (StudentGroups.SelectedItem != null)
            {
                string selectedGroupName = StudentGroups.SelectedItem.ToString();
                string grupe = selectedGroupName;



                try
                {
                    db.openConnection();

                    string query = "select concat(firstname, ' ', lastName) as Studentas from student where groups_id = (select id from `groups` where groupName=@gr);";

                    MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                    cmd.Parameters.Add("@gr", MySqlDbType.VarChar).Value = grupe;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Students.Items.Add(reader["Studentas"].ToString());
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

        private void Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void workType_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();


                try
                {
                    db.openConnection();

                    string query = "select * from worktype";

                    MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        workType.Items.Add(reader["WorkTypeName"].ToString());
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

        private void Subject_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            string Tusername = Teacher.getUsername();

            try
            {
                db.openConnection();

                string query = "SELECT t.firstName AS TeacherName, s.name AS \"Dalyko pavadinimas\"\r\nFROM teachersubjects AS ts\r\nJOIN teacher AS t ON ts.teacher_id = t.id\r\nJOIN subject AS s ON ts.subject_id = s.id\r\nWHERE ts.teacher_id = (select id from teacher where username=@un);";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                cmd.Parameters.Add("@un", MySqlDbType.VarChar).Value = Tusername;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject.Items.Add(reader["Dalyko pavadinimas"].ToString());
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

        private void FillGradesComboBox()
        {
            for (int i = 1; i <= 10; i++)
            {
                Grades.Items.Add(i);
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
            DB db = new DB();
            string Tusername = Teacher.getUsername();
            string firstWord = "";
            string secondWord = "";
            string subject = "";
            string worktype = "";
            string grade = "";

            if (Students.SelectedItem != null)
            {
                string selectedItem = Students.SelectedItem.ToString();


                string[] parts = selectedItem.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    firstWord = parts[0];
                    secondWord = parts[1];

                }
            }

            if (workType.SelectedItem != null && Subject.SelectedItem != null && Grades.SelectedItem != null)
            {
                worktype = workType.SelectedItem.ToString();
                subject = Subject.SelectedItem.ToString();
                grade = Grades.SelectedItem.ToString();

            }

            IUserRepository<Teacher> teacher = new TeacherRepository();
            teacher.AddGrade(Tusername, firstWord, secondWord, subject, worktype, grade);
           

        }
    }
}
