using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using mscannerr.Models;

namespace mscannerr.Services
{
    public class MovieService : IMovieService
    {
        private readonly ILogger _logger;

        public MovieService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MovieService>();
        }

        public List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie("Kill Bill", "The Bride wakens from a four-year coma.", 2003, null, "Unmonitored")
            };
        }
    }
}