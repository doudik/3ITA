using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConnectionManager
{
    internal sealed class ConnectionManager
    {
        //Singleton
        static ConnectionManager manager;
        public static ConnectionManager Manager
        {
            get
            {
                if (manager == null)
                {
                    manager = new ConnectionManager();
                }
                return manager;
            }
        }
        MySqlConnection conn;
        string connString = "Server=127.0.0.1;Database=3ITA;Uid=root;Pwd=;";
        string query;

        private ConnectionManager() { }

        public void Connect() {
            try
            {
                Console.WriteLine("Zkouším se připojit k db");
                conn = new MySqlConnection(connString);
                conn.Open();
                Console.WriteLine("Připojeno");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Disconnect() {
            try
            {
                conn.Close();
                Console.WriteLine("Zavřel sem spojení");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddUser(string username)
        {
            query = $"INSERT INTO users (nickname) VALUES('{username}')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
        public void RemoveUser(string username) {
            query = $"DELETE FROM users WHERE nickname = '{username}'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }

}
