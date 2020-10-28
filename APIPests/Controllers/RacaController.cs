﻿using System;
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
    public class RacaController : ControllerBase
    {
        RacaRepository repo = new RacaRepository();

        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return repo.ListarRacas();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repo.BuscarRaca(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca _raca)
        {
            return repo.CadastrarRaca(_raca);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca _raca)
        {
            return repo.AlterarRaca(_raca, id);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.ExcluirRaca(id);
        }
    }
    
}
