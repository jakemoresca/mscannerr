using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using mscanner.Models;
using mscannerr.DTOs;
using mscannerr.Services;

namespace mscannerr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IOptionsSnapshot<MovieDB> _movieDbOptions;

        public MovieController(IMovieService movieService, IOptionsSnapshot<MovieDB> movieDbOptions)
        {
            _movieService = movieService;
            _movieDbOptions = movieDbOptions;
        }

        [HttpGet]
        public async Task<MovieDto[]> Get()
        {
            return await _movieService.GetMovies();
        }

        [HttpGet("{movieId}")]
        public async Task<MovieDto> Get(int movieId)
        {
            return await _movieService.GetMovie(movieId);
        }

        [HttpGet("MatchedMovies")]
        public List<ScannedMovie> GetMatchMovies()
        {
            return _movieDbOptions.Value.Collection;
        }

        [HttpGet("MatchedMovies/{movieTitle}")]
        public ScannedMovie GetMatchMovies(string movieTitle)
        {
            return _movieDbOptions.Value.Collection.FirstOrDefault(movie =>
            {
                return movie.Title == movieTitle;
            });
        }

        [HttpPost("Match")]
        public async Task<ScannedMovie> MatchMovie([FromBody] MovieDto movie)
        {
            return await _movieService.MatchMovie(movie);
        }

        [HttpPost("MatchAll")]
        public async Task<List<ScannedMovie>> MatchMovies()
        {
            return await _movieService.MatchMovies();
        }
    }
}