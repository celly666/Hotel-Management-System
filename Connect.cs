using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Hotel_System
{
    class Connect
    {
        private MySqlConnection connection = new MySqlConnection("datasource= localhost;port=3306;username=root;password=1988;database=hotel_db");

        public MySqlConnection GetConnection()
        {
            return connection;
        }
        public void openConnection()
        {
            if(connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
