using PersonAPI.Models;
using System.Threading.Tasks;

namespace PersonAPI.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> Get(string personId);

        Task Create(Person person);

        Task Update(string personId, Person person);

        Task Delete(string personId);
    }
}
