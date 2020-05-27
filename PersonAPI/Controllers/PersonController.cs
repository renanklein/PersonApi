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
        public async Task<IActionResult> GetPerson([FromRoute] string personId)
        {
            var result = await this.PersonService.GetPerson(personId);
            if(result == null)
            {
                return NotFound("Person not found");
            }

            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromRoute] PersonRequest personRequest)
        {
            await this.PersonService.CreatePerson(personRequest);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] string personId, [FromBody] PersonRequest personRequest)
        {
            var result = await this.PersonService.PutPerson(personId, personRequest);

            if(result == null)
            {
                return BadRequest("There's no person with this id");
            }

            return Ok(result); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] string personId)
        {
            await this.PersonService.DeletePerson(personId);

            return Ok();
        }
    }
}
