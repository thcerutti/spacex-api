using SpaceX.Api.Models.Output;

namespace SpaceX.Api.Services
{
    public interface IApiRequestService
    {
        Task<LaunchOutputInfo> GetNextLaunchAsync();
        Task<LaunchOutputInfo> GetLatestLaunchAsync();
        Task<IEnumerable<LaunchOutputInfo>> GetUpcomingLaunchesAsync();
        Task<IEnumerable<LaunchOutputInfo>> GetPastLaunchesAsync();
        Task<RocketOutputInfo> PerformRocketSearchAsync(string rocketId);
    }
}