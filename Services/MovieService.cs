using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using mscannerr.DTOs;
using mscannerr.Models;

namespace mscannerr.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;


        public MovieService(ILoggerFactory loggerFactory, IHttpClientFactory clientFactory)
        {
            _logger = loggerFactory.CreateLogger<MovieService>();
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<MovieDto[]> GetMovies()
        {
            const string API_KEY = "";
            const int PORT = 11151;
            var baseUrl = $"http://server937.seedhost.eu:{PORT}/nathang0717/radarr/api/v3";

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/movie?apiKey={API_KEY}");

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
                return new MovieDto[]{};
            }
        }
    }
}