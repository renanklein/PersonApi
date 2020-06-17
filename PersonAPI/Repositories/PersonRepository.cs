using MongoDB.Driver;
using PersonAPI.Models;
using PersonAPI.Repositories.Interfaces;
using PersonAPI.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> PersonCollection;

        public PersonRepository(IMongoSettings mongoSettings)
        {
            var mongoClient = new MongoClient(mongoSettings.ConnectionString);

            var collection = mongoClient.GetDatabase("PersonAPI").GetCollection<Person>("Person");

            this.PersonCollection = collection;
        }

        public async Task Create(Person person)
        {
            await this.PersonCollection.InsertOneAsync(person);

        }

        public async Task Delete(string personId)
        {
            await this.PersonCollection.DeleteOneAsync<Person>(person => person.Id == personId);
        }

        public async Task<Person> Get(string personId)
        {
            var findResult = await this.PersonCollection.FindAsync<Person>(person => person.Id == personId);
                                
            return findResult.FirstOrDefault();
        }

        public async Task<IEnumerable<Person>> List(PersonFilter filter)
        {
            var result = await this.PersonCollection.FindAsync<Person>(p => true);

            return result.ToList().Skip(int.Parse(filter.Offset)).Take(int.Parse(filter.Limit));
        }

        public async Task Update(string personId, Person person)
        {
            await this.PersonCollection.ReplaceOneAsync<Person>(person => person.Id == personId, person);
        }
    }
}
