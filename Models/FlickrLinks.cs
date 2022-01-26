using System.Text.Json.Serialization;

namespace SpaceX.Api.Models
{
    public class FlickrLinks
    {
        [JsonPropertyName("original")]
        public string[] Original { get; set; }

    }
}