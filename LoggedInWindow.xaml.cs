using AntrojiProgramavimoPraktika.Classes;
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
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        public Student Student = new Student();
        public Teacher Teacher = new Teacher();
        public Admin Admin = new Admin();
        public LoggedInWindow(Student student)
        {
            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            Student = student;
        }

        public LoggedInWindow(Teacher teacher)
        {
            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            Teacher = teacher;
        }

        public LoggedInWindow(Admin admin)
        {
            this.Left = MainWindow.WindowLeft;
            this.Top = MainWindow.WindowTop;
            InitializeComponent();
            Admin = admin;
        }
        private void disBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void fSemBtn_Click(object sender, RoutedEventArgs e)
        {
            semesterWindow semesterwindow = new semesterWindow(Student);
            semesterwindow.Show();
            this.Close();
        }

        private void mainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void kontaktDuomBtn_click(object sender, RoutedEventArgs e)
        {
            KontaktiniaiDuomenysWindow kontaktiniaiDuomenysWindow = new KontaktiniaiDuomenysWindow(Student);
            kontaktiniaiDuomenysWindow.Show();
            this.Close();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(Admin);
            adminWindow.Show();
            this.Close();
        }

        private void TeacherButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacherWindow = new TeacherWindow(Teacher);
            teacherWindow.Show();
            this.Close();
        }

        private void sSemBtn_Click(object sender, RoutedEventArgs e)
        {
            semester2Window semester2window = new semester2Window(Student);
            semester2window.Show();
            this.Close();
        }

        private void tSemBtn_Click(object sender, RoutedEventArgs e)
        {
            semester3Window semester3window = new semester3Window(Student);
            semester3window.Show();
            this.Close();
        }
    }
}
