using System.Collections.Generic;
using mscannerr.Models;

namespace mscannerr.Services
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
    }
}