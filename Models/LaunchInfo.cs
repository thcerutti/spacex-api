using System.Text.Json.Serialization;

namespace SpaceX.Api.Models
{
    public class LaunchInfo
    {
        [JsonPropertyName("flight_number")]
        public int FlightNumber { get; set; }
        [JsonPropertyName("name")]
        public string MissionName { get; set; }
        [JsonPropertyName("mission_id")]
        public string[] MissionId { get; set; }
        [JsonPropertyName("date_utc")]
        public DateTime FireDateUtc { get; set; }
        [JsonPropertyName("rocket")]
        public string RocketId { get; set; }
        [JsonPropertyName("details")]
        public string MissionDetails { get; set; }
        [JsonPropertyName("links")]
        public LaunchLinks Links { get; set; }
    }
}