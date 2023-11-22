using AntrojiProgramavimoPraktika.Classes;
using AntrojiProgramavimoPraktika.Repos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.Xml.Linq;

namespace AntrojiProgramavimoPraktika
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        public Student Student = new Student();
        public Teacher Teacher = new Teacher();
        public Admin Admin = new Admin();

        readonly IUserRepository<Admin> AdminRepository;
        public AdminWindow(Admin admin)

        {

            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            Admin = admin;
        }

        private void mainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            LoggedInWindow loggedInWindow = new LoggedInWindow(Admin);
            loggedInWindow.AdminBtn.Visibility= Visibility.Visible;
            loggedInWindow.fSemBtn.IsEnabled = false;
            loggedInWindow.sSemBtn.IsEnabled = false;
            loggedInWindow.tSemBtn.IsEnabled = false;
            loggedInWindow.Show();
            this.Close();
        }

        private void kontaktDuomBtn_click(object sender, RoutedEventArgs e)
        {
            //KontaktiniaiDuomenysWindow kontakt = new KontaktiniaiDuomenysWindow();
            //kontakt.Show();
            //this.Close();
        }

        private void disBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        private void lastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void subjectBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ChoiceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiceBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string str = selectedItem.Content.ToString();

                if (str == "Studentas")
                {
                    lastNameTextBox.Visibility = Visibility.Hidden;
                    nameTextBox.Visibility = Visibility.Hidden;
                    SubjectComboBox.Visibility = Visibility.Hidden;
                    nameLabel.Visibility = Visibility.Hidden;
                    lastNameLabel.Visibility = Visibility.Hidden;
                    subjectLabel.Visibility = Visibility.Hidden;
                    saveBtnTeacher.Visibility = Visibility.Hidden;
                    emailTeacher.Visibility = Visibility.Hidden;
                    emaiTeacherlLabel.Visibility = Visibility.Hidden;
                    telephoneTeacherLabel.Visibility = Visibility.Hidden;
                    TelephoneTeacherNr.Visibility = Visibility.Hidden;
                    priskirtBtn.Visibility = Visibility.Hidden;
                    priskirtiLabel.Visibility = Visibility.Hidden;
                    teacherLabel.Visibility = Visibility.Hidden;
                    teachersComboBox.Visibility = Visibility.Hidden;
                    sukurtiDalykaBtn.Visibility = Visibility.Hidden;
                    sukurtiDalykaLabel.Visibility = Visibility.Hidden;
                    newDalykoTextBox.Visibility = Visibility.Hidden;
                    teachersukurtiLabel.Visibility = Visibility.Hidden;
                   
                    GroupComboBox.Visibility = Visibility.Visible;
                    studentGroupLabel.Visibility = Visibility.Visible;
                    studentLastNameLabel.Visibility = Visibility.Visible;
                    studentLastNameTextBox.Visibility = Visibility.Visible;
                    studentNameLabel.Visibility = Visibility.Visible;
                    studentNameTextBox.Visibility = Visibility.Visible;
                    saveBtnStudent.Visibility = Visibility.Visible; 
                    email.Visibility = Visibility.Visible;
                    emailLabel.Visibility = Visibility.Visible;
                    telephoneLabel.Visibility = Visibility.Visible;
                    TelephoneNr.Visibility = Visibility.Visible;
                    newGrupe.Visibility = Visibility.Visible;
                    sukurtiGrupe.Visibility = Visibility.Visible;
                    sukurtiGrupeBtn.Visibility = Visibility.Visible;
                    studentsukurtiLabel.Visibility = Visibility.Visible;
                   



                }

                else if (str == "Dėstytojas")
                {
                    lastNameTextBox.Visibility = Visibility.Visible;
                    nameTextBox.Visibility = Visibility.Visible;
                    SubjectComboBox.Visibility = Visibility.Visible;
                    nameLabel.Visibility = Visibility.Visible;
                    lastNameLabel.Visibility = Visibility.Visible;
                    subjectLabel.Visibility = Visibility.Visible;
                    saveBtnTeacher.Visibility = Visibility.Visible;
                    emailTeacher.Visibility = Visibility.Visible;
                    emaiTeacherlLabel.Visibility = Visibility.Visible;
                    telephoneTeacherLabel.Visibility = Visibility.Visible;
                    TelephoneTeacherNr.Visibility = Visibility.Visible;
                    priskirtBtn.Visibility = Visibility.Visible;
                    priskirtiLabel.Visibility = Visibility.Visible;
                    teacherLabel.Visibility = Visibility.Visible;
                    teachersComboBox.Visibility = Visibility.Visible;
                    SubjectComboBox.Visibility = Visibility.Visible;
                    subjectLabel.Visibility = Visibility.Visible;
                    sukurtiDalykaBtn.Visibility = Visibility.Visible;
                    sukurtiDalykaLabel.Visibility = Visibility.Visible;
                    newDalykoTextBox.Visibility = Visibility.Visible;
                    teachersukurtiLabel.Visibility = Visibility.Visible;


                    GroupComboBox.Visibility = Visibility.Hidden;
                    studentGroupLabel.Visibility = Visibility.Hidden;
                    studentLastNameLabel.Visibility = Visibility.Hidden;
                    studentLastNameTextBox.Visibility = Visibility.Hidden;
                    studentNameLabel.Visibility = Visibility.Hidden;
                    studentNameTextBox.Visibility = Visibility.Hidden;
                    saveBtnStudent.Visibility = Visibility.Hidden;
                    email.Visibility = Visibility.Hidden;
                    emailLabel.Visibility = Visibility.Hidden;
                    telephoneLabel.Visibility = Visibility.Hidden;
                    TelephoneNr.Visibility = Visibility.Hidden;
                    newGrupe.Visibility = Visibility.Hidden;
                    sukurtiGrupe.Visibility = Visibility.Hidden;
                    sukurtiGrupeBtn.Visibility = Visibility.Hidden;
                    studentsukurtiLabel.Visibility = Visibility.Hidden;

                }
            }
        }

        private void studentNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void studentLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void studentGroupBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void saveBtnTeacher_Click(object sender, RoutedEventArgs e)
        {
            string username = nameTextBox.Text;
            string firstname = nameTextBox.Text;
            string lastname = lastNameTextBox.Text;
            string password = lastNameTextBox.Text;
            string mail = emailTeacher.Text;
            string wmail = firstname + "." + lastname + "@viko.lt";
            string phone = TelephoneTeacherNr.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(mail)
                || string.IsNullOrWhiteSpace(wmail) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Užpildykite visus laukus");
            }
            else
            {
                if (!isTeacherExists(username)) {

                    DB db = new DB();
                    MySqlCommand command = new MySqlCommand("insert into teacher (username, password, firstName, lastName, telephoneNr, `e-mail`, `workE-mail`) values (@u,@p,@fn,@ln,@tel,@mail,@wmail);", db.getConnection());
                    command.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@p", MySqlDbType.VarChar).Value = lastname;
                    command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstname;
                    command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastname;
                    command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = phone;
                    command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
                    command.Parameters.Add("@wmail", MySqlDbType.VarChar).Value = wmail;

                    db.openConnection();

                    if (command.ExecuteNonQuery() == 1)
                        MessageBox.Show("Sekmingai uzregistravote dėstytoja");
                    else
                        MessageBox.Show("Nepavyko registruoti dėstytojo");
                    db.closeConnection();
                    teachersComboBox.Items.Clear();
                    loadTeachers();
                }
                else
                {
                    MessageBox.Show("Toks dėstytojas jau egzistuoja");
                }
            }
        }

        private void saveBtnStudent_Click(object sender, RoutedEventArgs e)
        {
            // Admin x = new Admin();
            // x.addStudent();

            // AdminRepository.addStudent();


            string username = studentNameTextBox.Text;
            string name = studentNameTextBox.Text;
            string lastname = studentLastNameTextBox.Text;
            string password = studentLastNameTextBox.Text;
            string mail = email.Text;
            string wmail = name + "." + lastname + "@stud.viko.lt";
            string phone = TelephoneNr.Text;

            if(!isStudentExists(username))
            {

                if (GroupComboBox.SelectedItem != null)
                {
                    string selectedGroupName = GroupComboBox.SelectedItem.ToString();
                    string grupe = selectedGroupName;

                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastname) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(mail)
                   || string.IsNullOrWhiteSpace(wmail) || string.IsNullOrWhiteSpace(phone))
                    {
                        MessageBox.Show("Užpildykite visus laukus");
                    }
                    else
                    {

                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("insert into student (username, password, firstName, lastName, telephoneNr, `e-mail`, `studentE-mail`, groups_id) values (@u,@p,@fn,@ln,@tel,@mail,@wmail , (SELECT id FROM `groups` WHERE groupName = @gr));;", db.getConnection());
                        command.Parameters.Add("@u", MySqlDbType.VarChar).Value = username;
                        command.Parameters.Add("@p", MySqlDbType.VarChar).Value = lastname;
                        command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastname;
                        command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = phone;
                        command.Parameters.Add("@mail", MySqlDbType.VarChar).Value = mail;
                        command.Parameters.Add("@wmail", MySqlDbType.VarChar).Value = wmail;
                        command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = grupe;
                        db.openConnection();

                        if (command.ExecuteNonQuery() == 1)
                            MessageBox.Show("Sekmingai uzregistravote studenta");
                        else
                            MessageBox.Show("Nepavyko registruoti studento");
                        db.closeConnection();
                    }
                }
            }
            else
            {
                MessageBox.Show("Toks studentas jau egzistuoja");
            }
        }

        private void GroupComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            loadGroupsComboBox();
        }

        public void loadGroupsComboBox()
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
                    GroupComboBox.Items.Add(reader["groupName"].ToString());
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

        private void SubjectComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            loadSubjects();
        }

        public void loadSubjects()
        {
            DB db = new DB();

            try
            {
                db.openConnection();

                string query = "select * from subject;";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SubjectComboBox.Items.Add(reader["name"].ToString());
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

        private void teachersComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            loadTeachers();
        }

        public void loadTeachers()
        {
            DB db = new DB();

            try
            {
                db.openConnection();

                string query = "select concat(id, ' ', firstName, ' ', lastName) as Vardas from teacher;";

                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teachersComboBox.Items.Add(reader["Vardas"].ToString());
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

        private void priskirtBtn_Click(object sender, RoutedEventArgs e)
        {

            string id = "";
            string name = "";

            if (SubjectComboBox.SelectedItem != null)
            {
                string selectedTeacherName = SubjectComboBox.SelectedItem.ToString();
                 name = selectedTeacherName;
            }


            if (teachersComboBox.SelectedItem != null)
            {
                string selectedItem = teachersComboBox.SelectedItem.ToString();


                string[] parts = selectedItem.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    id = parts[0]; 
                }
            }


            DB db = new DB();
                MySqlCommand command = new MySqlCommand("insert into teachersubjects(teacher_id, subject_id) values ((select id from teacher where id=@id),\r\n(select id from subject where name = @n));", db.getConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@n", MySqlDbType.VarChar).Value = name;
                

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Dalykas sėkmingai priskirtas");
                else
                    MessageBox.Show("Nepavyko priskirti dalyko");
                db.closeConnection();
        }

        private void sukurtiGrupeBtn_Click(object sender, RoutedEventArgs e)
        {
            string grName = newGrupe.Text;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("insert into `groups` (groupName) values (@gr);", db.getConnection());
            command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = grName;
           


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Grupė sėkmingai sukurta");
            else
                MessageBox.Show("Nepavyko sukurti grupes");
            db.closeConnection();
            GroupComboBox.Items.Clear();
            loadGroupsComboBox();
        }

        public bool isStudentExists(string username)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from student where username = @Auname", db.getConnection());

              command.Parameters.Add("@Auname", MySqlDbType.VarChar).Value = username;


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

        public bool isTeacherExists(string username)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from teacher where username = @Auname", db.getConnection());

            command.Parameters.Add("@Auname", MySqlDbType.VarChar).Value = username;


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

        public bool isSubjectExists(string subjectname)
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("select * from subject where name = @name", db.getConnection());

            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = subjectname;

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

        private void sukurtiDalykaBtn_Click(object sender, RoutedEventArgs e)
        {
            string s = newDalykoTextBox.Text;

            if (!isSubjectExists(s))
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("insert into subject (name) values (@s);", db.getConnection());
                command.Parameters.Add("@s", MySqlDbType.VarChar).Value = s;

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("Dalykas sėkmingai sukurtas");
                else
                    MessageBox.Show("Nepavyko sukurti dalyko");
                db.closeConnection();
                SubjectComboBox.Items.Clear();
                loadSubjects();
            }
            else
            {
                MessageBox.Show("Toks dalykas jau egzistuoja");
            }
        }
    }
}
