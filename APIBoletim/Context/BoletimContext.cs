using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Context
{
    public class BoletimContext
    {
        SqlConnection con = new SqlConnection();

        public BoletimContext()
        {
            con.ConnectionString = @"Data Source=DESK-02-10-16\SQLEXPRESS;Persist Security Info=True;User ID=sa;Password=***********";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
