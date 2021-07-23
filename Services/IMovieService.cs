using System.Collections.Generic;
using System.Threading.Tasks;
using mscannerr.DTOs;
using mscannerr.Models;

namespace mscannerr.Services
{
    public interface IMovieService
    {
        Task<MovieDto[]> GetMovies();
    }
}