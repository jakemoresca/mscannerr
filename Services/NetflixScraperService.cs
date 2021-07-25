using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;
using Microsoft.Extensions.Logging;
using mscanner.Models;
using mscannerr.DTOs;

namespace mscannerr.Services
{
    public class NetflixScraperService : INetflixScraperService
    {
        private readonly ILogger _logger;

        public NetflixScraperService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MovieService>();
        }

        public async Task<List<ScannedMovie>> BatchSearchMoviesAsync(MovieDto[] movies)
        {
            var scannedMovies = new List<ScannedMovie>();

            foreach (var movie in movies)
            {
                var scannedMovie = await SearchMovieAsync(movie);
                scannedMovies.Add(scannedMovie);

                await Task.Delay(5000);
            }

            return scannedMovies;
        }

        public async Task<ScannedMovie> SearchMovieAsync(MovieDto movie)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var escapedMovieTitle = WebUtility.UrlEncode(movie.Title);
            var address = $"https://www.flixwatch.co/?s={escapedMovieTitle}&id=45310";

            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);

            var nothingFoundSelector = "#content .h1class";
            var nothingFoundResult = document.QuerySelectorAll(nothingFoundSelector).FirstOrDefault();

            if (!nothingFoundResult.TextContent.Contains("Nothing Found"))
            {
                var resultSelector = "#content ul li a";
                var results = document.QuerySelectorAll(resultSelector);

                var resultLinks = results.Select(m => m.GetAttribute("href"));

                foreach (var resultLink in resultLinks)
                {
                    var (isMovieExists, scannedMovie) = await IsMovieExistsOnLinkAsync(resultLink, movie);

                    if(isMovieExists)
                    {
                        return scannedMovie;
                    }
                }
            }

            return new ScannedMovie { Title = movie.Title, Exist = false };
        }

        private async Task<(bool, ScannedMovie)> IsMovieExistsOnLinkAsync(string url, MovieDto movie)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);

            var titleSelector = "#content .h1class";
            var titleSelectorResult = document.QuerySelectorAll(titleSelector).FirstOrDefault();

            var titleMatched = titleSelectorResult.TextContent.Contains(movie.Title);

            var yearSelector = "#grid-single-main > div:nth-child(1) > p:nth-child(4)";
            var yearSelectorResult = document.QuerySelectorAll(yearSelector).FirstOrDefault();

            var yearMatched = yearSelectorResult.TextContent.Contains(movie.Year.ToString());

            var scannedMovie = new ScannedMovie 
            {
                Title = movie.Title,
                Exist = titleMatched && yearMatched
            };

            return (titleMatched && yearMatched, scannedMovie);
        }
    }
}