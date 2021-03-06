﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoGame_Pack.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JoGame_Pack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepositorie repo = new JogoRepositorie();

        // GET: api/<JogoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JogoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JogoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JogoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JogoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
