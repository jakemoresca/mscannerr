using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mscannerr.DTOs;
using mscannerr.Models;
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
    }
}