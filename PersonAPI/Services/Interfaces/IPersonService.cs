using PersonAPI.Models.Request;
using PersonAPI.Models.Response;
using System.Threading.Tasks;

namespace PersonAPI.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonResponse> GetPerson(string personId);
        Task CreatePerson(PersonRequest person);
        Task<PersonResponse> PatchPerson(string personId, PersonRequest person);
        Task<PersonResponse> PutPerson(string personId, PersonRequest person);
        Task DeletePerson(string personId);
    }
}
