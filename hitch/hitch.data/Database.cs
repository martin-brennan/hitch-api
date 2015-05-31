using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace hitch.data
{
    internal static class Database
    {
        public static MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            var connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Port=3306;Database=hitch;UID=root;Password=root");
            connection.Open();
            return connection;
        }
    }
}
