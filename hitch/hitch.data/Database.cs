using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data.Common;
using Dapper;

namespace hitch.data
{
    internal static class Database
    {
        public static DbConnection GetConnection(DataStore store = DataStore.MySql)
        {
            DbConnection connection = null;
            switch (store) {
                case DataStore.MySql:
                    connection = new MySql.Data.MySqlClient.MySqlConnection("Server=127.0.0.1;Port=3306;Database=hitch;UID=root;Password=root");
                    break;
            }
            connection.Open();
            return connection;
        }

        public static IEnumerable<T> SimpleGetAll<T>(DbConnection connection = null) {
            string table = GetTableName(typeof(T));

            if (connection == null)
            {
                connection = GetConnection();
            }

            IEnumerable<T> results = null;
            using (connection)
            {
                results = connection.Query<T>(String.Format("SELECT * FROM {0}", table));
            }
            return results;
        }

        public static T SimpleGet<T>(int id, DbConnection connection = null)
        {
            string table = GetTableName(typeof(T));

            if (connection == null)
            {
                connection = GetConnection();
            }

            T result;
            using (connection)
            {
                result = connection.Query<T>(String.Format("SELECT * FROM {0} WHERE id = {1}", table, id)).FirstOrDefault();
            }
            return result;
        }


        public enum DataStore {
            MySql = 1,
            MSSQL = 2
        }

        private static string GetTableName(Type t)
        {
            string table = t.Name;
            table = table.ToLower() + 's';
            return table;
        }
    }
}
