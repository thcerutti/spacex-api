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
            var nextLaunch = await _apiRequestService.GetNextLaunch();
            return Ok(nextLaunch);
        }

        [HttpGet, Route("latest-launch")]
        public async Task<IActionResult> GetLatestLaunch()
        {
            var latestLaunch = await _apiRequestService.GetLatestLaunch();
            return Ok(latestLaunch);
        }

        [HttpGet, Route("upcoming-launches")]
        public async Task<IActionResult> GetUpcomingLaunches()
        {
            var upcomingLaunches = await _apiRequestService.GetUpcomingLaunches();
            return Ok(upcomingLaunches);
        }
        
        [HttpGet, Route("past-launches")]
        public async Task<IActionResult> GetPastLaunches()
        {
            var pastLaunches = await _apiRequestService.GetPastLaunches();
            return Ok(pastLaunches);
        }
    }
}