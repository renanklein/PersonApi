using MongoDB.Bson.Serialization.Attributes;
using PersonAPI.Models.Common;

namespace PersonAPI.Models
{
    public class Person
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public Document Document { get; set; }
    }
}
