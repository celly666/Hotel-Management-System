using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hotel_System
{
    class RESERVATION
    {
        Connect conn = new Connect();
        public DataTable getAllReserv()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM reservations", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public bool addReservation(int number, int clientId, DateTime dateIn, DateTime dateOut)
        {


            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO reservations (roomNumber, clientID, DateIn, DateOut) VALUES (@num, @cid, @din,@dout)";
            command.CommandText = insertQuery;
            command.Connection = conn.GetConnection();

            //@rnm, @cid, @din,@dout
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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
        public bool editReservation(int reservID, int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE rooms SET roomNumber=@num, clientID=@cid, DateIn=@din, DateOut=@dout WHERE reserID=@rvid";
            command.CommandText = editQuery;
            command.Connection = conn.GetConnection();

            //@rnm, @cid, @din,@dout, @rvid
            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservID;
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;

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
        public bool removeReservation(int reservId)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM reservations WHERE reservID=@rvid";
            command.CommandText = removeQuery;
            command.Connection = conn.GetConnection();

            //@cid
            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservId;

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
