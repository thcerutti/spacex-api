using System.Text.Json;
using SpaceX.Api.Models;

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

        public async Task<LaunchInfo> GetLatestLaunch() =>
            await PerformHttpGet<LaunchInfo>($"{_apiBaseUrl}/launches/latest");

        public async Task<LaunchInfo> GetNextLaunch() =>
            await PerformHttpGet<LaunchInfo>($"{_apiBaseUrl}/launches/next");

        public async Task<IEnumerable<LaunchInfo>> GetPastLaunches() =>
            await PerformHttpGet<IEnumerable<LaunchInfo>>($"{_apiBaseUrl}/launches/past");

        public async Task<IEnumerable<LaunchInfo>> GetUpcomingLaunches() =>
            await PerformHttpGet<IEnumerable<LaunchInfo>>($"{_apiBaseUrl}/launches/upcoming");

        private async Task<T> PerformHttpGet<T>(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }

            throw new HttpRequestException($"Status code: {response.StatusCode}");
        }
    }
}