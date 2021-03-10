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
        private MySqlConnection con;

        public DatabaseHandler() 
        {
            var cs = ConfigurationManager.ConnectionStrings["freemysql"].ConnectionString;
            this.con = new MySqlConnection(cs);
            con.Open();
        }

        public MySqlDataReader select(string what, string database)
        {
            string sql = string.Format("SELECT {0} FROM {1}", what, database);
            using var cmd = new MySqlCommand(sql, con);
            return cmd.ExecuteReader();
        }

        public bool userExists(string database, string user, string pass)
        {
            bool ret = false;
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE username = '{1}' AND password = '{2}'", database, user, pass);
            using var cmd = new MySqlCommand(sql, con);
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

        public MySqlConnection getConnection()
        {
            return con;
        }

        public void close()
        {
            con.Close();
        }
    }
}
