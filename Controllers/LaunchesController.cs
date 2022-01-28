using Microsoft.AspNetCore.Mvc;
using SpaceX.Api.Models.Output;
using SpaceX.Api.Services;

namespace SpaceX.Api.Controllers
{
    [Route("api/[controller]")]
    public class LaunchesController : Controller
    {
        private readonly IApiRequestService _apiRequestService;

        public LaunchesController(IApiRequestService apiRequestService)
        {
            _apiRequestService = apiRequestService;
        }

        [HttpGet, Route("next-launch")]
        public async Task<ActionResult<LaunchOutputInfo>> GetNextLaunch()
        {
            var nextLaunch = await _apiRequestService.GetNextLaunchAsync();
            return Ok(nextLaunch);
        }

        [HttpGet, Route("latest-launch")]
        public async Task<ActionResult<LaunchOutputInfo>> GetLatestLaunch()
        {
            var latestLaunch = await _apiRequestService.GetLatestLaunchAsync();
            return Ok(latestLaunch);
        }

        [HttpGet, Route("upcoming-launches")]
        public async Task<ActionResult<IEnumerable<LaunchOutputInfo>>> GetUpcomingLaunches()
        {
            var upcomingLaunches = await _apiRequestService.GetUpcomingLaunchesAsync();
            return Ok(upcomingLaunches);
        }

        [HttpGet, Route("past-launches")]
        public async Task<ActionResult<IEnumerable<LaunchOutputInfo>>> GetPastLaunches()
        {
            var pastLaunches = await _apiRequestService.GetPastLaunchesAsync();
            return Ok(pastLaunches);
        }

        [HttpGet, Route("rocket/{rocketId}")]
        public async Task<ActionResult<RocketOutputInfo>> GetRocket(string rocketId)
        {
            try
            {
                var rocket = await _apiRequestService.PerformRocketSearchAsync(rocketId);
                return Ok(rocket);
            }
            catch (ArgumentException)
            {
                return NoContent();
            }
        }
    }
}