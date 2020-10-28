using APIPests.Context;
using APIPests.Domains;
using APIPests.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPests.Repositories
{
    public class TipoPetRepository : ITipoPet
    {
        PetsContext conexao = new PetsContext();

      
        SqlCommand cmd = new SqlCommand();
        public TipoPet AlterarTipo(TipoPet tipo, int idTipo)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Tipo SET Descricao = @descricao WHERE IdTipo = @id";

            cmd.Parameters.AddWithValue("@id", idTipo);
            cmd.Parameters.AddWithValue("@descricao", tipo.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return tipo;
        }

        public TipoPet CadastrarTipo(TipoPet tipo)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Tipo (Descricao) VALUES (@descricao)";

            cmd.Parameters.AddWithValue("@descricao", tipo.Descricao);

           
            cmd.ExecuteNonQuery();

            return tipo;
        }

        public void ExcluirTipo(int idTipo)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Tipo WHERE IdTipo = @id";

            cmd.Parameters.AddWithValue("@id", idTipo);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public TipoPet ListarTipo(int idTipo)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Tipo WHERE IdTipo = @id";

            cmd.Parameters.AddWithValue("@id", idTipo);

            SqlDataReader dado = cmd.ExecuteReader();

            TipoPet tipo = new TipoPet();

            while (dado.Read())
            {
                tipo.IdTipo = Convert.ToInt32(dado.GetValue(0));
                tipo.Descricao = dado.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return tipo;
        }

        public List<TipoPet> ListaTipos()
        {

            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPet> listaTipos = new List<TipoPet>();

            while (dados.Read())
            {
                listaTipos.Add(

                    new TipoPet()
                    {
                        IdTipo = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return listaTipos;
        }
    }
}
