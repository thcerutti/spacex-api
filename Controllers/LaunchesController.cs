using Microsoft.AspNetCore.Mvc;
using SpaceX.Api.Services;

namespace SpaceX.Api.Controllers
{
    [Route("api/[controller]")]
    public class LaunchesController: Controller
    {
        private readonly IApiRequestService _apiRequestService;

        public LaunchesController(IApiRequestService apiRequestService)
        {
            _apiRequestService = apiRequestService;
        }

        [HttpGet, Route("next-launch")]
        public async Task<IActionResult> GetNextLaunch()
        {
            var nextLaunch = await _apiRequestService.GetNextLaunchAsync();
            return Ok(nextLaunch);
        }

        [HttpGet, Route("latest-launch")]
        public async Task<IActionResult> GetLatestLaunch()
        {
            var latestLaunch = await _apiRequestService.GetLatestLaunchAsync();
            return Ok(latestLaunch);
        }

        [HttpGet, Route("upcoming-launches")]
        public async Task<IActionResult> GetUpcomingLaunches()
        {
            var upcomingLaunches = await _apiRequestService.GetUpcomingLaunchesAsync();
            return Ok(upcomingLaunches);
        }
        
        [HttpGet, Route("past-launches")]
        public async Task<IActionResult> GetPastLaunches()
        {
            var pastLaunches = await _apiRequestService.GetPastLaunchesAsync();
            return Ok(pastLaunches);
        }

        [HttpGet, Route("rocket/{rocketId}")]
        public async Task<IActionResult> GetRocket(string rocketId)
        {
            var rocketInfo = await _apiRequestService.PerformRocketSearchAsync(rocketId);
            return Ok(rocketInfo);
        }
    }
}