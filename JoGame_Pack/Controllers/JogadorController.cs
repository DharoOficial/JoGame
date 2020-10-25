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
        /// <summary>
        /// Mostra Jogadore Cadastrados
        /// </summary>
        /// <returns>Retorna Jogadores Cadastrados </returns>
        [HttpGet]
        public List<Jogador> Get()
        {
            return repo.ListarTodos();
        }

        // GET api/<JogadorController>/5
        /// <summary>
        /// Mostra um unico jogador
        /// </summary>
        /// <param name="id">ID Do Jogador PlayerId</param>
        /// <returns>Retorna um jogador de acordo com um Id</returns>
        [HttpGet("{id}")]
        public Jogador Get(int id)
        {
            return repo.BuscarPorId(id);

        }

        // POST api/<JogadorController>
        /// <summary>
        /// Cadastra um Jogaddor
        /// </summary>
        /// <param name="j">Objeto completo de Jogador</param>
        /// <returns>Retorna o jogador cadastrado</returns>
        [HttpPost]
        public Jogador Post([FromBody] Jogador j)
        {
            return repo.Cadastrar(j);
        }

        // PUT api/<JogadorController>/5
        /// <summary>
        /// altera o cadastro de um jogador
        /// </summary>
        /// <param name="id">Id Jogador</param>
        /// <param name="j">Objeto completo de Jogador</param>
        /// <returns>Retorna o Jogador cadastrado</returns>
        [HttpPut("{id}")]
        public Jogador Put(int id, [FromBody] Jogador j)
        {
            return repo.Alterar(j , id);
        }

        // DELETE api/<JogadorController>/5
        /// <summary>
        /// exclui o cadastro de um Jogador
        /// </summary>
        /// <param name="id">Id Jogador</param>
        /// <param name="j">Objeto completo de Jogador</param>
        /// <returns>Id de  jogador excluido</returns>
        [HttpDelete("{id}")]
        public Jogador Delete(int id, [FromBody] Jogador j)
        {
            return repo.Excluir(j, id);
        }
    }
}
