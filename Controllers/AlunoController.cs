using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_boletim.Domains;
using API_boletim.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_boletim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        // chamar o repositoorio de aluno 
        AlunoRepository repo = new AlunoRepository();

        // GET: api/Aluno
        [HttpGet]
        public List<Aluno> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/Aluno
        [HttpPost]
        public Aluno Post([FromBody] Aluno a)
        {
            return repo.Cadastrar(a);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] Aluno a)
        {
            return repo.Alterar(id, a);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}
