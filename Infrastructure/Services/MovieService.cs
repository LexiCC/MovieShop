using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        //movieSerive will need to talk to IMovieRepository first
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // DI IMovieRepository
        // Models are nothing but dumb classes that transfer data, ViewModels, Models, DTO (Data Transfer Objects)
        public async Task<List<MovieCard>> Get30HighestGrossingMovies()
        {
            //Get Entities' data from repository
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            
            // AutoMapper - Nuget
            //Transfer Entities' data into Model's data
            var movieCards = new List<MovieCard>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCard { Id = movie.Id, PosterUrl = movie.PosterUrl, Title=movie.Title });
            }
            return movieCards;
        }

        public async Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            //先用相应的method从repository里拿到想要的entity data
            var movie = await _movieRepository.GetById(id);
            if (movie == null) 
            {
                return null;
            }
            
            //然后放入到对应的Model里
            var movieDetails = new MovieDetailsModel
            {
                Title = movie.Title,
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                RunTime = movie.RunTime,
                Price = movie.Price,
                ImdbUrl = movie.ImdbUrl,
                Rating = movie.Rating,
                Reviews = movie.Reviews
            };
            
            //Since trailers is a collection, assign this collection to movieDetails.Trailers, 然后用一个loop往里加element
            movieDetails.Trailers = new List<TrailerModel>();
            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl});
            }
            
            movieDetails.Genres = new List<GenreModel>();
            foreach (var genres in movie.GenresOfMovie)
            {
                movieDetails.Genres.Add(new GenreModel { Id = genres.GenreId, Name = genres.Genre.Name });
            }
            
            movieDetails.Casts = new List<CastModel>();
            foreach (var cast in movie.CastOfMovie)
            {
                movieDetails.Casts.Add(new CastModel
                {
                    Id = cast.CastId, Character = cast.Character, Name = cast.Cast.Name, ProfilePath = cast.Cast.ProfilePath
                });
            }
            
            // todo review???
            return movieDetails;
        }
    }
}
