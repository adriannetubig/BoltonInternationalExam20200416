using System.Text.Json.Serialization;

namespace InternalVirusTotalIntegrationBusiness.Entities
{
    public class EntityIpScan
    {
        [JsonPropertyName("attributes")]
        public EntityAttributes Attributes { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("links")]
        public EntityLinks Links { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
