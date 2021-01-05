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
