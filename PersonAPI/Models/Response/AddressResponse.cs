using System.Text.Json.Serialization;

namespace PersonAPI.Models.Response
{
    public class AddressResponse
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }
    }
}
