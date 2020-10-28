using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPests.Domains;
using APIPests.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        TipoPetRepository repo = new TipoPetRepository();

        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return repo.ListaTipos();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return repo.ListarTipo(id);
        }

        // POST api/<TipoPetController>
        [HttpPost]
        public TipoPet Post ([FromBody] TipoPet tipo)
        {
            return repo.CadastrarTipo(tipo);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public TipoPet Put (int id, [FromBody] TipoPet tipo)
        {
            return repo.AlterarTipo(tipo, id);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.ExcluirTipo(id);
        }
    }
}
