using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.Interfaces;

namespace Tarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonId(int id) 
        {
            try
            {



                return Ok();
            }
            catch(Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError , $"Erro ao tentar recuperar person. Erro: {ex.Message}");
            }
        }
    }
}
