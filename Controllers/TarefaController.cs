using Microsoft.AspNetCore.Mvc;
using TarefasBackEnd.Models;
using TarefasBackEnd.Repositories;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Text.Json;

namespace TarefasBackEnd.Controllers
{
    [ApiController]
    [Route("tarefa")]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Read([FromServices] ITarefaRepository repository)
        {

            var tarefas = repository.Read();


            return Ok(tarefas);

        }

        [HttpPost]
        public IActionResult Create([FromBody] Tarefa model, [FromServices] ITarefaRepository repository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            repository.Create(model);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Create(string id,[FromBody] Tarefa model, [FromServices] ITarefaRepository repository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            repository.Update(new Guid(id) ,model);

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromBody] Tarefa model, [FromServices] ITarefaRepository repository)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            repository.Delete(new Guid(id));

            return Ok();
        }

    }
}