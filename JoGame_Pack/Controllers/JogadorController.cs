using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoGame_Pack.Domains;
using JoGame_Pack.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JoGame_Pack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {

        JogadorRepositorie repo = new JogadorRepositorie();

        // GET: api/<JogadorController>
        [HttpGet]
        public List<Jogador> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<JogadorController>/5
        [HttpGet("{id}")]
        public Jogador Get(int id)
        {
            return repo.BuscarPorId(id);

        }

        // POST api/<JogadorController>
        [HttpPost]
        public Jogador Post([FromBody] Jogador j)
        {
            return repo.Cadastrar(j);
        }

        // PUT api/<JogadorController>/5
        [HttpPut("{id}")]
        public Jogador Put(int id, [FromBody] Jogador j)
        {
            return repo.Alterar(j , id);
        }

        // DELETE api/<JogadorController>/5
        [HttpDelete("{id}")]
        public Jogador Delete(int id, [FromBody] Jogador j)
        {
            return repo.Excluir(j, id);
        }
    }
}
