using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models.Request;
using PersonAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PersonAPI.Controllers
{
    [ApiController]
    [Route("/persons/")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService PersonService;
        public PersonController(IPersonService personService)
        {
            this.PersonService = personService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] string id)
        {
            var result = await this.PersonService.GetPerson(id);
            if(result == null)
            {
                return NotFound("Person not found");
            }

            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonRequest personRequest)
        {
            var newPerson = await this.PersonService.CreatePerson(personRequest);

            return Ok(newPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] string id, [FromBody] PersonRequest personRequest)
        {
            var result = await this.PersonService.PutPerson(id, personRequest);

            if(result == null)
            {
                return BadRequest("There's no person with this id");
            }

            return Ok(result); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] string id)
        {
            await this.PersonService.DeletePerson(id);

            return Ok();
        }
    }
}
