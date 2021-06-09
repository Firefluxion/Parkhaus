using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Linq;
using Parkhaus;
using MySql.Data.MySqlClient;

namespace DataLibary.DataAccess
{
    public class MySqlDataAccess
    {
        private readonly DatabaseSettings databaseSettings;

        public MySqlDataAccess(DatabaseSettings databaseSettings)
        {
            this.databaseSettings = databaseSettings;
        }

        public string GetConnectionString()
        {
            return databaseSettings.ConnectionString;
        }

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public T LoadData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, data).FirstOrDefault();
            }
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
