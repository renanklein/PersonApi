using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using PersonAPI.Models;
using PersonAPI.Models.Request;
using PersonAPI.Models.Response;

namespace PersonAPI.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonRequest, Person>();
            CreateMap<Person, PersonResponse>();
            CreateMap<JsonPatchDocument<PersonRequest>, JsonPatchDocument<Person>>();
            CreateMap<Operation<PersonRequest>, Operation<Person>>();
        }
    }
}
