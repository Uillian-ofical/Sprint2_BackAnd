using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPests.Context
{
    public class PetsContext
    {
        SqlConnection _connection = new SqlConnection();

        public PetsContext()
        {
            _connection.ConnectionString = @"Data Source=DESK-02-10-16\SQLEXPRESS;Initial Catalog=PetsClinica;User ID=sa;Password=***********";
        }

        public SqlConnection Conectar()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public void Desconectar()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close(); 
            }
        }
    }
}
