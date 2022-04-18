using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        //private readonly IGenreService _genreService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
            //_genreService = genreService;
        }

        public async Task< IActionResult> Index()
        {            
            // Autofac -> DI 
            // Proprty and method injection anti pattern
            // 
            //  x = 5;
            // we got the data from inline object
            // Controllers should always be thin, Logic should come from services
            // method(int x, IMovieService movieservice )
            //  class MovieService: IMovieService
            //  {}
            // class MovieService2 : IMovieService
            //  {}
            // var myMovieService = new MovieService2();
            // method(3,myMovieService);
            // 
            // newing up, we want to avoid, instead of us directly calling those classes, better if we can rely on abstarctions and pass the implementation at run time  
            // tight coupling between classes, we want to avoid
           // var movieService = new MovieService();
           // we need to inject the type that implements the interface
           // INjection is built in .NET Core
           // older .net framework -> rher eis no built  in DI
            var movies = await _movieService.Get30HighestGrossingMovies();
            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}