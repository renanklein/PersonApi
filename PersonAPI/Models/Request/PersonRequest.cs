

namespace PersonAPI.Models.Request
{
    public class PersonRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public AddressRequest Address { get; set; }
        public DocumentRequest Document { get; set; }

    }
}
