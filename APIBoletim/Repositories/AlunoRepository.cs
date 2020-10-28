using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        BoletimContext conexao = new BoletimContext();
        SqlCommand cmd = new SqlCommand();

        public Aluno AlterarAluno(Aluno _aluno, int _idAluno)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorId(int _idAluno)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM aluno WHERE IdAluno = @id";

            cmd.Parameters.AddWithValue("@id", _idAluno);

            SqlDataReader dado = cmd.ExecuteReader();

            Aluno aluno = new Aluno();

            while (dado.Read())
            {
                aluno.IdAluno = Convert.ToInt32(dado.GetValue(0));
                aluno.Nome = dado.GetValue(1).ToString();
                aluno.RA = dado.GetValue(2).ToString();
                aluno.Idade = Convert.ToInt32(dado.GetValue(3));
            }

            conexao.Desconectar();

            return aluno;
        }

        public Aluno CadastrarAluno(Aluno aluno)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO aluno (Nome, RA, Idade)" +
                " VALUES " +
                "(@Nome, @RA, @Idade)";

            cmd.Parameters.AddWithValue("@Nome", aluno.Nome);
            cmd.Parameters.AddWithValue("@RA", aluno.RA);
            cmd.Parameters.AddWithValue("@Idade", aluno.Idade);


            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return aluno;
        }

        public Aluno ExcluirAluno(int idAluno)
        {
           cmd.Connection = conexao.Conectar();

           cmd.CommandText = "DELETE FROM aluno WHERE IdAluno = @id";

           cmd.Parameters.AddWithValue("@id", idAluno);

           cmd.ExecuteNonQuery();

          
            conexao.Desconectar();

            
        }

        public List<Aluno> ListarAlunos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();
            while (dados.Read())
            {
                alunos.Add(
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3)),

                    });
            }
            conexao.Desconectar();

            return alunos;
        }
    }
}
