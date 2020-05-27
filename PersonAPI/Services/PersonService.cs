using AutoMapper;
using PersonAPI.Models;
using PersonAPI.Models.Request;
using PersonAPI.Models.Response;
using PersonAPI.Repositories;
using PersonAPI.Repositories.Interfaces;
using PersonAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace PersonAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository PersonRepository;
        private readonly IMapper Mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.PersonRepository = personRepository;
            this.Mapper = mapper;
        }

        public async Task CreatePerson(PersonRequest personRequest)
        {
            await this.PersonRepository.Create(Mapper.Map<Person>(personRequest));
        }

        public async Task DeletePerson(string personId)
        {
            await this.PersonRepository.Delete(personId);
        }

        public async Task<PersonResponse> GetPerson(string personId)
        {
            var result = await this.PersonRepository.Get(personId);

            return Mapper.Map<PersonResponse>(result);
        }

        public Task<PersonResponse> PatchPerson(string personId, PersonRequest personRequest)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PersonResponse> PutPerson(string personId, PersonRequest personRequest)
        {
            var person = Mapper.Map<Person>(personRequest);
            await this.PersonRepository.Update(personId, person);

            var updatedPerson = this.PersonRepository.Get(personId);
            return Mapper.Map<PersonResponse>(updatedPerson);
        }
    }
}
