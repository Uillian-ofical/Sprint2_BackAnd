using APIPests.Context;
using APIPests.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPests.Repositories
{
    public class RacaRepository
    {

        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();

        public List<Raca> ListarRacas()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> _listaRacas = new List<Raca>();

            while (dados.Read())
            {
                _listaRacas.Add(

                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        NomeRaca = dados.GetValue(1).ToString(),
                        IdTipoRaca = Convert.ToInt32(dados.GetValue(2)),
                    }
                );
            }

            conexao.Desconectar();

            return _listaRacas;
        }


        public Raca BuscarRaca(int idRaca)
        {
            cmd.Connection = conexao.Conectar();
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", idRaca);

            SqlDataReader dado =  cmd.ExecuteReader();

            Raca raca = new Raca();

            while (dado.Read())
            {
                raca.IdRaca = Convert.ToInt32(dado.GetValue(0));
                raca.NomeRaca = dado.GetValue(1).ToString();
                raca.IdTipoRaca = Convert.ToInt32(dado.GetValue(2));
            }

            conexao.Desconectar();

            return raca;
        }

        public Raca CadastrarRaca(Raca raca)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO Raca (NomeRaca, IdTipoRaca) VALUES (@nomeRaca, @idTipo)";

            cmd.Parameters.AddWithValue("@nomeRaca", raca.NomeRaca);
            cmd.Parameters.AddWithValue("@idTipo", raca.IdTipoRaca);

            cmd.ExecuteNonQuery();

            return raca;
        }

        public Raca AlterarRaca(Raca raca, int idRaca)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET NomeRaca = @nomeRaca, IdTipoRaca = @idTipo WHERE IdTipo = @id";

            cmd.Parameters.AddWithValue("@id", idRaca);
            cmd.Parameters.AddWithValue("@nomeRaca", raca.NomeRaca);
            cmd.Parameters.AddWithValue("@idTipo", raca.IdTipoRaca);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return raca;
        }

        public void ExcluirRaca(int idRaca)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", idRaca);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }
    }
}
