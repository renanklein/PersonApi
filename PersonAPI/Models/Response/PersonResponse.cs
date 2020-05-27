namespace PersonAPI.Models.Response
{
    public class PersonResponse
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public AddressResponse Address { get; set; }
        public DocumentResponse Document { get; set; }
    }
}
