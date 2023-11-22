using AntrojiProgramavimoPraktika.Classes;
using AntrojiProgramavimoPraktika.Repos;
using System;
using System.Collections.Generic;
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

namespace AntrojiProgramavimoPraktika
{
    /// <summary>
    /// Interaction logic for KontaktiniaiDuomenysWindow.xaml
    /// </summary>
    public partial class KontaktiniaiDuomenysWindow : Window
    {
        IUserRepository<Student> StudentRepository = new StudentRepository();
        public Student Student = new Student();
        public KontaktiniaiDuomenysWindow(Student student)
        {

            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            Student = student;
            usernameTextBox.Text = Student.getUsername();
            pwdTextbox.Text = Student.GetPassword();
            
        }

        private void disBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void kontaktDuomBtn_click(object sender, RoutedEventArgs e)
        {
            KontaktiniaiDuomenysWindow kontaktiniaiDuomenysWindow = new KontaktiniaiDuomenysWindow(Student);
            kontaktiniaiDuomenysWindow.Show();
            this.Close();
        }

        private void mainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            LoggedInWindow loggedInWindow = new LoggedInWindow(Student);
            loggedInWindow.kontaktDuomBtn.Visibility= Visibility.Visible;
            loggedInWindow.Show();
            this.Close();
        }

        private void updateInfo_Click(object sender, RoutedEventArgs e)
        {
           string username = usernameTextBox.Text;
           string password=pwdTextbox.Text;
            string user = Student.getUsername();
          StudentRepository.UpdateInfo(username, password, user);           
        }
    }
}
