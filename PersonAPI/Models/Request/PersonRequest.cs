

using Newtonsoft.Json;

namespace PersonAPI.Models.Request
{
    public class PersonRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("address")]
        public AddressRequest Address { get; set; }

        [JsonProperty("document")]
        public DocumentRequest Document { get; set; }

    }
}
