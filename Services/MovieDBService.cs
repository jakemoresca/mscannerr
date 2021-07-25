using mscanner.Models;

namespace mscannerr.Services
{
    public class MovieDBService : IMovieDBService
    {
        public void Update(MovieDB movieDB)
        {
            MovieDBFile.Write(movieDB);
        }
    }
}