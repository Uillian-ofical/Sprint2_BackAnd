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
        Aluno AlterarAluno(Aluno _, int _idAluno);
        Aluno ExcluirAluno(int _idAluno);
        List<Aluno> ListarAlunos();
    }
}
