using PersonAPI.Models;
using PersonAPI.Models.Request;
using PersonAPI.Models.Response;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonAPI.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonResponse>> ListPersons(PersonFilter filter);
        Task<PersonResponse> GetPerson(string personId);
        Task<PersonResponse> CreatePerson(PersonRequest person);
        Task<PersonResponse> PatchPerson(string personId, PersonRequest person);
        Task<PersonResponse> PutPerson(string personId, PersonRequest person);
        Task DeletePerson(string personId);
    }
}
