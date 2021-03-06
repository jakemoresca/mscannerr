using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ILoggerFactory _loggerFactory;
        private readonly IOptionsSnapshot<IntegrationSettings> _settingsOptions;
        private readonly IOptionsSnapshot<MovieDB> _movieDbOptions;
        private readonly INetflixScraperService _netflixScraperService;

        public MovieService(ILoggerFactory loggerFactory, IHttpClientFactory clientFactory, 
            IOptionsSnapshot<IntegrationSettings> settingsOptions,
            IOptionsSnapshot<MovieDB> movieDbOptions,
            INetflixScraperService netflixScraperService)
        {
            _logger = loggerFactory.CreateLogger<MovieService>();
            _httpClient = clientFactory.CreateClient();
            _loggerFactory = loggerFactory;
            _settingsOptions = settingsOptions;
            _movieDbOptions = movieDbOptions;
            _netflixScraperService = netflixScraperService;
        }

        public async Task<MovieDto[]> GetMovies()
        {
            var getMovieUrl = new Uri(GetServiceUrl(_settingsOptions.Value.MovieSettings, "/movie"));
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

        public async Task<MovieDto> GetMovie(int movieId)
        {
            var getMovieUrl = new Uri(GetServiceUrl(_settingsOptions.Value.MovieSettings, $"/movie/{movieId}"));
            var request = new HttpRequestMessage(HttpMethod.Get, getMovieUrl);

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var moviesJson = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions();
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                return JsonSerializer.Deserialize<MovieDto>(moviesJson, options);
            }
            else
            {
                return new MovieDto { };
            }
        }

        public async Task<ScannedMovie> MatchMovie(MovieDto movie)
        {
            var scannedMovie = await _netflixScraperService.SearchMovieAsync(movie);

            if(!scannedMovie.Exist)
                return scannedMovie;

            var movieDB = _movieDbOptions.Value;

            if(movieDB.Collection == null)
            {
                movieDB.Collection = new List<ScannedMovie>();
            }

            var isAlreadyOnDb = movieDB.Collection.Any(x => x.Title == movie.Title);

            if(isAlreadyOnDb)
                movieDB.Collection.RemoveAll(x => x.Title == movie.Title);

            movieDB.Collection.Add(scannedMovie);
            MovieDBFile.Write(movieDB);

            return scannedMovie;
        }

        public async Task<List<ScannedMovie>> MatchMovies()
        {
            var movies = await GetMovies();
            var scannedMovies = await _netflixScraperService.BatchSearchMoviesAsync(movies);

            var movieDB = _movieDbOptions.Value;
            movieDB.Collection = scannedMovies;

            MovieDBFile.Write(movieDB);
            MovieDBFile.Write(movieDB);

            return scannedMovies;
        }

        public async Task<bool> TestSettings(MovieSettings settings)
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

        private string GetServiceUrl(MovieSettings integrationSettings, string relativeServiceUrl)
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