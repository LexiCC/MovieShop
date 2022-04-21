using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers;

public class GenreController : Controller
{
    private readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    // public async Task<IActionResult> GenreDetails(int id)
    // {
    //     var genres = await _genreService.GetAllGenre(id);
    //     return View(genres);
    // }
}