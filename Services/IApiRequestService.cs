using SpaceX.Api.Models;

namespace SpaceX.Api.Services
{
    public interface IApiRequestService
    {
        Task<LaunchInfo> GetNextLaunch();
        Task<LaunchInfo> GetLatestLaunch();
        Task<IEnumerable<LaunchInfo>> GetUpcomingLaunches();
        Task<IEnumerable<LaunchInfo>> GetPastLaunches();
    }
}