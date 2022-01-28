using SpaceX.Api.Models.Input;

namespace SpaceX.Api.Models.Output
{
    public class LaunchOutputInfo
    {
        public int? FlightNumber { get; set; }
        public string? MissionName { get; set; }
        public string[]? MissionId { get; set; }
        public DateTime? FireDateUtc { get; set; }
        public string? RocketId { get; set; }
        public string? MissionDetails { get; set; }
        public string? PatchLinkSmall { get; set; }
        public string? PatchLinkLarge { get; set; }

        public LaunchOutputInfo(LaunchInputInfo launchInfo)
        {
            FlightNumber = launchInfo.FlightNumber;
            MissionName = launchInfo.MissionName;
            MissionId = launchInfo.MissionId;
            FireDateUtc = launchInfo.FireDateUtc;
            RocketId = launchInfo.RocketId;
            MissionDetails = launchInfo.MissionDetails;
            PatchLinkSmall = launchInfo?.Links?.PatchLinks?.Small;
            PatchLinkLarge = launchInfo?.Links?.PatchLinks?.Large;
        }
    }
}