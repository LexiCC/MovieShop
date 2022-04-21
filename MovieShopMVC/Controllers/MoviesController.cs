using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
       //private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //when click on Movie's poster，id get passed into this method
        //http:localhost/movies/details/id
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails); //this view name typically same as action method name
        }

        //Used to get movies filtered by a specific genres
        public async Task<IActionResult> MovieCardFilterByGenre(int id)
        {
            var movieCardsByGenre = await _movieService.GetMoviesFilterByGenre(id);
            return View(movieCardsByGenre);
        }
        

        [HttpGet]
        public async Task<IActionResult> Genres(int id, int pageSize = 30, int pageNumber = 1 )
        {
            var pagedMovies = await _movieService.GetMoviesByGenrePagination(id, pageSize, pageNumber);
            return View("pagedMovies", pagedMovies);
        }
    }
}
