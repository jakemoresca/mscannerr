using System.Collections.Generic;
using System.Threading.Tasks;
using mscanner.Models;
using mscannerr.DTOs;
using mscannerr.Models;

namespace mscannerr.Services
{
    public interface IMovieService
    {
        Task<MovieDto[]> GetMovies();
        Task<bool> TestSettings(IntegrationSettings settings);
        Task<ScannedMovie> MatchMovie(MovieDto movie);
        Task<List<ScannedMovie>> MatchMovies();
    }
}