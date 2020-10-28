using APIPests.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPests.Interfaces
{
    interface IRaca
    {

        List<Raca> ListarRacas();
        Raca BuscarRaca(int idRaca);
        Raca CadastrarRaca(Raca raca);
        Raca AlterarRaca(Raca raca, int idRaca);
        void ExcluirRaca(int idRaca);
    }
}
