using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_System
{
    class CLIENT
    {
        Connect conn = new Connect();
        public bool insertClient(string fname, string lname, string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO clients (first_name, last_name, phone, country) VALUES (@fnm, @lnm, @phn,@cnt)";
            command.CommandText = insertQuery;
            command.Connection = conn.GetConnection();

            //@fnm, @lnm, @phn,@cnt
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

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
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM clients", conn.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public bool editClient(int id, string fname, string lname, string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE clients SET first_name=@fnm, last_name=@lnm, phone=@phn, country=@cnt WHERE id=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.GetConnection();

            //@cid, @fnm, @lnm, @phn,@cnt
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

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
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM clients WHERE id=@cid";
            command.CommandText = removeQuery;
            command.Connection = conn.GetConnection();

            //@cid
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

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
