using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hotel_System
{

    class Room
    {
        Connect conn = new Connect();
        public DataTable roomTypeList()
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM room_category", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public DataTable roomByType(int type)
        {


            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms WHERE roomType=@typ and free='Yes'", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@typ", MySqlDbType.Int32).Value = type;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public int getRoomType(int number)
        {


            MySqlCommand command = new MySqlCommand("SELECT roomType  FROM rooms WHERE roomNumber=@num ", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        public bool seRoomFree(int number, string YES_or_NO)
        {


            MySqlCommand command = new MySqlCommand("UPDATE rooms SET free=@yes_no WHERE roomNumber=@num", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@yes_no", MySqlDbType.VarChar).Value = YES_or_NO;

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;

            conn.openConnection();

            if(command.ExecuteNonQuery()==1)
            {
                conn.closeConnection();
                return true; ;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
            
        }

            public bool addRoom(int number, int type, string phone, string free)
        {


            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO rooms (roomNumber, roomType, phone, free) VALUES (@num, @tp, @phn,@fr)";
            command.CommandText = insertQuery;
            command.Connection = conn.GetConnection();

            //@num, @tp, @phn,@fr
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;


            }
        }
        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public bool editRooms(int number, int type, string phone, string free)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE rooms SET roomType=@tp, phone=@phn, free=@fr WHERE roomNumber=@num";
            command.CommandText = editQuery;
            command.Connection = conn.GetConnection();

            //@num, @tp, @phn,@fr
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool removeRoom(int roomNumber)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM rooms WHERE roomNumber=@num";
            command.CommandText = removeQuery;
            command.Connection = conn.GetConnection();

            //@cid
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = roomNumber;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;


            }
        }
    }
}
