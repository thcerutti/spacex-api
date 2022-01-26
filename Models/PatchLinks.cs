using System.Text.Json.Serialization;

namespace SpaceX.Api.Models
{
    public class PatchLinks
    {
        [JsonPropertyName("small")]
        public string Small { get; set; }
        [JsonPropertyName("large")]
        public string Large { get; set; }
    }
}