using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Poker_Online
{
    class DatabaseHandler
    {
        /**
        * =============================
        * Fields
        * =============================
        **/
        private MySqlConnection con;

        /**
        * =============================
        * Constructors
        * =============================
        **/
        public DatabaseHandler() 
        {
            var cs = ConfigurationManager.ConnectionStrings["freemysql"].ConnectionString;
            this.con = new MySqlConnection(cs);
            con.Open();
        }

        /**
        * =============================
        * Getters
        * =============================
        **/
        public MySqlConnection getConnection()
        {
            return con;
        }

        /**
        * =============================
        * Utility Methods
        * =============================
        **/
        public MySqlDataReader select(string what, string database)
        {
            string sql = string.Format("SELECT {0} FROM {1}", what, database);
            using var cmd = new MySqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public bool userExists(string user, string pass)
        {
            bool ret = false;
            string sql = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", user);
            cmd.Parameters.AddWithValue("@password", pass);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                ret = rdr.GetInt32(0) > 0;
            }
            rdr.Close();
            return ret;
        }

        public int getUserChips(string username)
        {
            int ret = 0;
            string sql = string.Format("SELECT chips FROM users WHERE (username = '{0}')", username);
            using var cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                ret = rdr.GetInt32(0);
            }
            rdr.Close();
            return ret;
        }

        public void updatePlayerChips(string username, int newAmount)
        {
            string sql = "UPDATE users SET chips = @newAmount WHERE username = @username";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@newAmount", newAmount);
            cmd.Parameters.AddWithValue("@username", username);  
            cmd.ExecuteNonQuery();
        }

        public void registerPlayer(string username, string password)
        {
            var sql = "INSERT INTO users(username, password) VALUES(@username, @password)";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void close()
        {
            con.Close();
        }
    }
}
