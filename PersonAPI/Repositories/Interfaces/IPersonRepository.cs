using PersonAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonAPI.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> List(PersonFilter filter);

        Task<Person> Get(string personId);

        Task Create(Person person);

        Task Update(string personId, Person person);

        Task Delete(string personId);
    }
}
