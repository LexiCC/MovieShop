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
            return View(movieDetails); //this view name tipcally same as action method name
        }
    }
}
