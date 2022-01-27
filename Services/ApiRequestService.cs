using System.Text.Json;
using SpaceX.Api.Models.Input;
using SpaceX.Api.Models.Output;

namespace SpaceX.Api.Services
{
    public class ApiRequestService : IApiRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private string _apiBaseUrl;

        public ApiRequestService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _apiBaseUrl = _configuration.GetSection("ApiBaseUrl").Value;
        }

        public async Task<LaunchOutputInfo> GetLatestLaunchAsync() =>
            await PerformHttpGetAsync($"{_apiBaseUrl}/launches/latest");

        public async Task<LaunchOutputInfo> GetNextLaunchAsync() =>
            await PerformHttpGetAsync($"{_apiBaseUrl}/launches/next");

        public async Task<IEnumerable<LaunchOutputInfo>> GetPastLaunchesAsync() =>
            await PerformHttpGetListAsync($"{_apiBaseUrl}/launches/past");

        public async Task<IEnumerable<LaunchOutputInfo>> GetUpcomingLaunchesAsync() =>
            await PerformHttpGetListAsync($"{_apiBaseUrl}/launches/upcoming");

        private async Task<LaunchOutputInfo> PerformHttpGetAsync(string url)
        {
            var launchInfoResponse = await PerformHttpGetStringAsync(url);
            var info = JsonSerializer.Deserialize<LaunchInfo>(launchInfoResponse);
            return new LaunchOutputInfo(info);
        }

        public async Task<RocketOutputInfo> PerformRocketSearchAsync(string rocketId)
        {
            var rocketResponse = PerformHttpGetStringAsync($"{_apiBaseUrl}/rockets/{rocketId}");
            var rocketInfo = JsonSerializer.Deserialize<RocketInputInfo>(await rocketResponse);
            return new RocketOutputInfo(rocketInfo);
        }

        private async Task<IEnumerable<LaunchOutputInfo>> PerformHttpGetListAsync(string url)
        {
            var launchInfoResponse = await PerformHttpGetStringAsync(url);
            var list = JsonSerializer.Deserialize<IEnumerable<LaunchInfo>>(launchInfoResponse);
            return list.Select(info => new LaunchOutputInfo(info));
        }

        private async Task<string> PerformHttpGetStringAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new HttpRequestException($"Status code: {response.StatusCode}");
        }
    }
}