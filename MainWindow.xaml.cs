using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AntrojiProgramavimoPraktika.Classes;
using AntrojiProgramavimoPraktika.Repos;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace AntrojiProgramavimoPraktika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double WindowLeft { get; set; }
        public static double WindowTop { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Left = (SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
            this.Top = (SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2);
        }


        private void conbtn_click(object sender, RoutedEventArgs e)
        {



            string Username = username.Text;
            string Password = password.Password;

           

            UserR userr = new UserR();

           

            DB db = new DB();
            

            var user = userr.GetUsers(db, Username, Password);

            

            DataTable table = new DataTable();

           MySqlDataAdapter adapter = new MySqlDataAdapter();
            
            if (user.getPermission() == "admin")
            {
                WindowLeft = this.Left;
                WindowTop = this.Top;
                Admin x = new Admin();
                x.setUsername(Username);
                x.setPassword(Password);
                LoggedInWindow loggedInWindow = new LoggedInWindow(x);
                loggedInWindow.Show();
                loggedInWindow.AdminBtn.Visibility = Visibility.Visible;
                loggedInWindow.fSemBtn.IsEnabled= false;
                loggedInWindow.sSemBtn.IsEnabled= false;
                loggedInWindow.tSemBtn.IsEnabled= false;
                this.Close();
                
            }

           else if (user.getPermission() == "teacher")
            {
                WindowLeft = this.Left;
                WindowTop = this.Top;
                Teacher x = new Teacher();
                x.setUsername(Username);
                x.setPassword(Password);
                LoggedInWindow loggedInWindow = new LoggedInWindow(x);
                loggedInWindow.Show();
                loggedInWindow.AdminBtn.Visibility = Visibility.Hidden;
                loggedInWindow.TeacherBtn.Visibility = Visibility.Visible;
                loggedInWindow.fSemBtn.IsEnabled = false;
                loggedInWindow.sSemBtn.IsEnabled = false;
                loggedInWindow.tSemBtn.IsEnabled = false;
                this.Close();
                
            }
            
          else  if(user.getPermission() == "student")
            {
                WindowLeft = this.Left;
                WindowTop = this.Top;
                Student x = new Student();
                x.setUsername(Username);
                x.setPassword(Password);
                LoggedInWindow loggedInWindow = new LoggedInWindow(x);
                loggedInWindow.Show();
                loggedInWindow.AdminBtn.Visibility = Visibility.Hidden;
                loggedInWindow.kontaktDuomBtn.Visibility = Visibility.Visible;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Nerasta tokio vartotojo");

            }

           

            //MySqlCommand command = new MySqlCommand("select * from admin where username = @Auname and password = @Apass", db.getConnection());
               
            //    command.Parameters.Add("@Auname", MySqlDbType.VarChar).Value = Username;
            //    command.Parameters.Add("@Apass", MySqlDbType.VarChar).Value = Password;


            //    adapter.SelectCommand = command;
            //    adapter.Fill(table);

            //    if (table.Rows.Count > 0)
            //    {
            //        LoggedInWindow loggedInWindow = new LoggedInWindow();
            //        loggedInWindow.Show();
            //        this.Close();
            //        Admin x = new Admin();
            //        x.setUsername(Username);
            //        x.setPassword(Password);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Nerasta tokio admino");

            //    }
            


                //    try
                //    {
                //        string connstring = "server=localhost;uid=root;pwd=root;database=viko_soc_media;";
                //        MySqlConnection con = new MySqlConnection();
                //        using (var con = new MySqlConnection())
                //        {

                //        }
                //        con.ConnectionString = connstring;
                //        con.Open();
                //        string sql = "select * from autoriai;";
                //        MySqlCommand cmd = new MySqlCommand(sql, con);
                //        MySqlDataReader reader = cmd.ExecuteReader();
                //        /*while (reader.Read())
                //        {
                //            MessageBox.Show("Name " + reader["vardas"]+ " Pavarde " + reader["pavarde"]);
                //        }*/
                //        //MessageBox.Show("connected");



                //        while (reader.Read())
                //        {
                //            string adminUsername = (string)reader["vardas"];
                //            string adminPassword = (string)reader["pavarde"];


                //            if (username.Text == adminUsername && password.Password == adminPassword)
                //            {
                //                LoggedInWindow loggedInWindow = new LoggedInWindow();
                //                loggedInWindow.Show();
                //                this.Close();
                //                break;
                //            }
                //            else
                //            {
                //                MessageBox.Show("Nerasta tokio admino");
                //                break;
                //            }
                //        }
                //    }
                //    catch (MySqlException ex)
                //    {
                //        MessageBox.Show(ex.ToString());
                //    }
        }


    }
}
