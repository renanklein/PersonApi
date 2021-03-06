﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PersonAPI.Models;
using PersonAPI.Models.Request;
using PersonAPI.Models.Response;
using PersonAPI.Repositories.Interfaces;
using PersonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<PersonResponse> CreatePerson(PersonRequest personRequest)
        {
            personRequest.Id = DateTime.Now.Ticks.ToString("x");
            await this.PersonRepository.Create(Mapper.Map<Person>(personRequest));

            var person = await this.PersonRepository.Get(personRequest.Id);

            return Mapper.Map<PersonResponse>(person);
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

        public async Task<IEnumerable<PersonResponse>> ListPersons(PersonFilter filter)
        {
            var result = await this.PersonRepository.List(filter);

            return Mapper.Map<List<PersonResponse>>(result);
        }

        public async Task<PersonResponse> PatchPerson(string personId, JsonPatchDocument<PersonRequest> request)
        {
            var person = Mapper.Map<JsonPatchDocument<Person>>(request);

            var result = await this.PersonRepository.Patch(personId, person);

            return Mapper.Map<PersonResponse>(result);
        }

        public async Task<PersonResponse> PutPerson(string personId, PersonRequest personRequest)
        {
            personRequest.Id = personId;
            var person = Mapper.Map<Person>(personRequest);
            await this.PersonRepository.Update(personId, person);

            var updatedPerson = await this.PersonRepository.Get(personId);
            return Mapper.Map<PersonResponse>(updatedPerson);
        }
    }
}
