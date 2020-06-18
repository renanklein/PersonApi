using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models;
using PersonAPI.Models.Request;
using PersonAPI.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/persons/")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService PersonService;
        public PersonController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        /// <summary>
        /// Lista todas a pessoas persistidas na base de dados
        /// As propriedades Offset e Limit são utilizadas para, respectivamente, pular e limitar 
        /// o dados de retorno
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListPersons([FromQuery] PersonFilter filter)
        {
            var result = await this.PersonService.ListPersons(filter);

            if(result.Count() == 0)
            {
                return BadRequest("There's no person");
            }

            return Ok(result);
        }

        /// <summary>
        /// Obtem uma pessoa a partir de um id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPerson([FromRoute] string id)
        {
            var result = await this.PersonService.GetPerson(id);
            if(result == null)
            {
                return NotFound("Person not found");
            }

            return Ok(result); 
        }
        /// <summary>
        /// Cria uma Pessoa
        /// </summary>
        /// <param name="personRequest"></param>
        /// <returns></returns>
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePerson([FromBody] PersonRequest personRequest)
        {
            var newPerson = await this.PersonService.CreatePerson(personRequest);

            return Created("", newPerson);
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa. Por se tratar de uma Put, todos os dados da 
        /// pessoa serão atualizados, os dados não enviados no corpo da requisição terão 
        /// o valor nulo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePerson([FromRoute] string id, [FromBody] PersonRequest personRequest)
        {
            var result = await this.PersonService.PutPerson(id, personRequest);

            if(result == null)
            {
                return BadRequest("There's no person with this id");
            }

            return Ok(result); 
        }

        /// <summary>
        /// Apaga os dados de uma Pessoa com o id correspondente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePerson([FromRoute] string id)
        {
            await this.PersonService.DeletePerson(id);

            return Ok();
        }
    }
}
