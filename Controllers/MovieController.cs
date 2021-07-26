using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<MovieDto[]> Get()
        {
            return await _movieService.GetMovies();
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