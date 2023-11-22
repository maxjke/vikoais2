using AntrojiProgramavimoPraktika.Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AntrojiProgramavimoPraktika
{
    /// <summary>
    /// Interaction logic for semesterWindow.xaml
    /// </summary>
    public partial class semester2Window : Window
    {
        public Student Student = new Student();
        public DataTable Grades {  get; set; }
      
        public semester2Window(Student student)
        {
            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent(); 
            Student = student;
           
        }

        private void semesterWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DB db = new DB();   
            Student student = new Student();
           
                
            try
            {
                db.openConnection();

                string query = "SELECT  st.firstname as Vardas, st.lastName as Pavardė, s.name as \"Dalyko pavadinimas\", w.WorkTypeName as \"Darbo tipas\", se.semesterNr as Semestras, g.grade as Pažymys\r\nFROM grades g\r\nJOIN subject s ON g.subject_id = s.id\r\nJOIN student st ON g.student_id = st.id \r\nJOIN worktype w ON g.worktype_id = w.id\r\nJOIN semester se ON g.semester_id = se.id\r\n where st.username=@u AND se.semesterNr=@nr;";
                
                MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
                cmd.Parameters.Add("@u", MySqlDbType.VarChar).Value = Student.getUsername();
                cmd.Parameters.Add("@nr", MySqlDbType.VarChar).Value = 2;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                gradesDataGrid.ItemsSource = table.DefaultView;
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

        private void disBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void mainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            LoggedInWindow loggedInWindow = new LoggedInWindow(Student);
            loggedInWindow.kontaktDuomBtn.Visibility = Visibility.Visible;
            loggedInWindow.Show();
            this.Close();
        }

        private void kontaktDuomBtn_click(object sender, RoutedEventArgs e)
        {

        }

        private void gradesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
