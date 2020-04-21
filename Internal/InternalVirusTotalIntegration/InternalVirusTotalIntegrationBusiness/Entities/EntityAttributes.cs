using System.Text.Json.Serialization;

namespace InternalVirusTotalIntegrationBusiness.Entities
{
    public class EntityAttributes
    {
        [JsonPropertyName("as_owner")]
        public string AsOwner { get; set; }

        [JsonPropertyName("asn")]
        public int Asn { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
