using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;

namespace ParkingDAL
{
    public class SQLAdapter : ISQLAdapter
    {
        private string _connectionString;

        public SQLAdapter() : this(null)
        {

        }

        public SQLAdapter(string connectionString)
        {
            _connectionString = connectionString ?? @"Server=10.0.69;Database=InnovatorsParkingSystem;Integrated Security=true;";
        }

        public int Execute(string sqlCommand)
        {
            using (var connection = GetSqlConnection())
            {
                return connection.Execute(sqlCommand);
            }
        }

        public IEnumerable<dynamic> Query(string sqlCommand)
        {
            using (var connection = GetSqlConnection())
            {
                return connection.Query(sqlCommand);
            }
        }
        
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
