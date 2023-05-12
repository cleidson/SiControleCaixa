﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiControleCaixa.Application.NET7.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxoCaixaController : ControllerBase
    {
        // GET: api/<FluxoCaixaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FluxoCaixaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FluxoCaixaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
