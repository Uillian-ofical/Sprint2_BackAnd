using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces
{
    interface IAluno
    {
        
        Aluno CadastrarAluno(Aluno a);
        Aluno BuscarPorId(int idAluno);
        Aluno Alterar(int id, Aluno aluno);
        void Excluir(int id);
        List<Aluno> ListarAlunos();
    }
}
