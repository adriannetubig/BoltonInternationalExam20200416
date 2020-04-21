using System.Text.Json.Serialization;

namespace InternalVirusTotalIntegrationBusiness.Entities
{
    public class EntityLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
