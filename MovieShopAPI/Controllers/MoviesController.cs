using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("top-grossing")]
        // http://localhost/api/movies/top-grossing
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            // callmovie service to get the data
            var movies = await _movieService.Get30HighestGrossingMovies();
            // reuturn data and also HTTP Status Code
            if (!movies.Any())
            {
                return NotFound(new { errorMessage = "No Movies Found" });
            }
            // ASP.NET Core converts, serializes C# object to JSON objects automatically
            // System.Text.Json Library
            
            // .net core version 2 or less
            // .NET Framework (old) => NewtonSoft.Json
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        // http://localhost/api/movies/4
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null)
                return NotFound(new { errorMessage = "No Movie Found for id" });
            return Ok(movie);
        }
    }
}