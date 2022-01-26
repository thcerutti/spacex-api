using System.Text.Json.Serialization;

namespace SpaceX.Api.Models{
        public class LaunchLinks
    {
        [JsonPropertyName("flickr")]
        public FlickrLinks FlickrLinks { get; set; }      
        [JsonPropertyName("patch")]
        public PatchLinks PatchLinks { get; set; }
    }
}