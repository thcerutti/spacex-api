using System.Text.Json.Serialization;

namespace SpaceX.Api.Models.Input
{
    public class RocketInputInfo
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("flickr_images")]
        public string[]? FlickrImages { get; set; }
    }        
}