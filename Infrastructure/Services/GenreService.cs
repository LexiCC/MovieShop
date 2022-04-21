using System.Collections.Immutable;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IGenreRepository _genreRepository;
    
    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    
    //Used to get all the genres from database
    public async Task<IEnumerable<GenreModel>> GetAllGenre()
    {
        var genres = await _genreRepository.GetAllGenreFromDb();
        var genresModel = new List<GenreModel>();
        foreach(var g in genres)
        {
            genresModel.Add(new GenreModel
            {
               Id = g.Id,
               Name = g.Name
            });
        }
        return genresModel;
    }
}