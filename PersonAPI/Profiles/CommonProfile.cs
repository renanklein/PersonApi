using AutoMapper;
using PersonAPI.Models.Common;
using PersonAPI.Models.Request;
using PersonAPI.Models.Response;

namespace PersonAPI.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<AddressRequest, Address>();
            CreateMap<DocumentRequest, Document>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Document, DocumentResponse>();
        }
    }
}
