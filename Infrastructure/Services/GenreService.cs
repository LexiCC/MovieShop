using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    // private readonly IMovieRepository _genreRepository;
    //
    // public GenreService(IMovieRepository genreRepository)
    // {
    //     _genreRepository = genreRepository;
    // }
    //
    // public async Task<GenreModel> GetGenreDetails(int id)
    // {
    //     var genre = await _genreRepository.GetById(id);
    //     var genreDetails = new GenreModel
    //     {
    //         
    //         Id = genre.Id,
    //         Name = genre.
    //     };
    //     return movie;
    // }
    // public Task<GenreModel> GetGenreDetails(int id)
    // {
    //     throw new NotImplementedException();
    // }
}