using System.Text.Json.Serialization;

namespace PersonAPI.Models.Request
{
    public class PersonRequest
    {

        public string Name { get; set; }
        public string Age { get; set; }
        public AddressRequest Address { get; set; }
        public DocumentRequest Document { get; set; }

    }
}
