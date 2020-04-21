using System.Text.Json.Serialization;

namespace InternalVirusTotalIntegrationBusiness.Entities
{
    public class EntityVirusTotalResult
    {
        [JsonPropertyName("data")]
        public EntityIpScan data { get; set; }
    }
}
