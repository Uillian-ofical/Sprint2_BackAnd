using APIPests.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPests.Interfaces
{
    interface ITipoPet
    {
        List<TipoPet> ListaTipos();
        TipoPet ListarTipo(int idTipo);
        TipoPet CadastrarTipo(TipoPet tipo);
        TipoPet AlterarTipo(TipoPet tipo, int idTipo);
        void ExcluirTipo(int idTipo);
    }
}
