using AutoMapper;
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
        }
    }
}
