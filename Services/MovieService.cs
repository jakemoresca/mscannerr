using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using mscanner.Models;
using mscannerr.DTOs;
using mscannerr.Models;

namespace mscannerr.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IOptionsSnapshot<IntegrationSettings> _settingsOptions;

        public MovieService(ILoggerFactory loggerFactory, IHttpClientFactory clientFactory, IOptionsSnapshot<IntegrationSettings> settingsOptions)
        {
            _logger = loggerFactory.CreateLogger<MovieService>();
            _httpClient = clientFactory.CreateClient();
            _settingsOptions = settingsOptions;
        }

        public async Task<MovieDto[]> GetMovies()
        {
            var getMovieUrl = new Uri(GetServiceUrl(_settingsOptions.Value, "/movie"));
            var request = new HttpRequestMessage(HttpMethod.Get, getMovieUrl);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var moviesJson = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions();
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                return JsonSerializer.Deserialize<MovieDto[]>(moviesJson, options);
            }
            else
            {
                return new MovieDto[] { };
            }
        }

        public async Task<bool> TestSettings(IntegrationSettings settings)
        {
            try
            {
                var getMovieUrl = new Uri(GetServiceUrl(settings, "/movie"));
                var request = new HttpRequestMessage(HttpMethod.Get, getMovieUrl);

                var response = await _httpClient.SendAsync(request);

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GetServiceUrl(IntegrationSettings integrationSettings, string relativeServiceUrl)
        {
            var apiKey = integrationSettings.ApiKey;
            var port = integrationSettings.Port;
            var host = integrationSettings.Host;
            var useSsl = integrationSettings.UseSsl;
            var baseUrl = integrationSettings.BaseUrl;
            var protocol = useSsl ? "https://" : "http://";

            var serviceUrl = $"{protocol}{host}:{port}{baseUrl}/api/v3{relativeServiceUrl}?apiKey={apiKey}";

            return serviceUrl;
        }
    }
}