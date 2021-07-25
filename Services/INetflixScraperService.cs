using System.Collections.Generic;
using System.Threading.Tasks;
using mscanner.Models;
using mscannerr.DTOs;

namespace mscannerr.Services
{
    public interface INetflixScraperService
    {
        Task<List<ScannedMovie>> BatchSearchMoviesAsync(MovieDto[] movies);
        Task<ScannedMovie> SearchMovieAsync(MovieDto movie);
    }
}