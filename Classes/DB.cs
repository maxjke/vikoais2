using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiProgramavimoPraktika.Classes
{
   public class DB
    {
        MySqlConnection connection = new MySqlConnection("Server=MYSQL5044.site4now.net;Database=db_aa1dbf_vikoais;Uid=aa1dbf_vikoais;Pwd=Root123123");
        
  

    public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
