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

        public async Task<LaunchOutputInfo?> GetLatestLaunchAsync() =>
            await GetLaunchInfoAsync("/latest");

        public async Task<LaunchOutputInfo?> GetNextLaunchAsync() =>
            await GetLaunchInfoAsync("/next");

        public async Task<IEnumerable<LaunchOutputInfo>> GetPastLaunchesAsync() =>
            await GetLaunchListInfoAsync("/past");

        public async Task<IEnumerable<LaunchOutputInfo>> GetUpcomingLaunchesAsync() =>
            await GetLaunchListInfoAsync("/upcoming");

        public async Task<RocketOutputInfo?> PerformRocketSearchAsync(string rocketId)
        {
            var url = $"{_apiBaseUrl}/rockets/{rocketId}";
            var rocketResponse = GetStringResponseAsync(url);
            var rocketInfo = JsonSerializer.Deserialize<RocketInputInfo>(await rocketResponse);
            if (rocketInfo == null)
            {
                return default;
            }
            return new RocketOutputInfo(rocketInfo);
        }

        private async Task<LaunchOutputInfo?> GetLaunchInfoAsync(string apiPath)
        {
            var url = GetFullLaunchesUrlPath(apiPath);
            var launchInfoResponse = await GetStringResponseAsync(url);
            var info = JsonSerializer.Deserialize<LaunchInputInfo>(launchInfoResponse);
            if (info == null)
            {
                return default;
            }
            return new LaunchOutputInfo(info);
        }

        private async Task<IEnumerable<LaunchOutputInfo>> GetLaunchListInfoAsync(string apiPath)
        {
            var url = GetFullLaunchesUrlPath(apiPath);
            var launchInfoResponse = await GetStringResponseAsync(url);
            var list = JsonSerializer.Deserialize<IEnumerable<LaunchInputInfo>>(launchInfoResponse);
            if (list == null)
            {
                return Enumerable.Empty<LaunchOutputInfo>();
            }
            return list.Select(info => new LaunchOutputInfo(info));
        }

        private string GetFullLaunchesUrlPath(string path) => $"{_apiBaseUrl}/launches{path}";

        private async Task<string> GetStringResponseAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new ArgumentException();
                default:
                    throw new HttpRequestException($"Status code: {response.StatusCode}");
            }
        }
    }
}