﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Movie> Get30HighestGrossingMovies()
        {
            // LINQ query 
            // SELECT top 30 * from Movie order by revenue 
            // Always check the SQL Query generated by EF, to make sure its the one you want and properly optimized
           
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;

        }

        public IEnumerable<Movie> Get30HighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public override Movie GetById(int id)
        {
            // Include method to include the navigation properties
            // Add Cast and MovieCast to the includes to get cast information
            var movie = _dbContext.Movies.Include(m=> m.GenresOfMovie).ThenInclude(m=> m.Genre).Include(m=> m.Trailers)
                    .FirstOrDefault(m=> m.Id == id);
            return movie;
        }

    }
}
