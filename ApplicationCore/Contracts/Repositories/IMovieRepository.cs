using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository: IRepository<Movie>
    {
       Task< IEnumerable<Movie>> Get30HighestGrossingMovies();
       Task<IEnumerable<Movie>> Get30HighestRatedMovies();

       Task<List<Movie>> GetMovieListByGenre(int id);

       //default value is 30 and 1
       //We can use Tuple: return multiple data types
       Task<PagedResultSet<Movie>> GetMovieByGenres(int genreId, int pageSize = 30, int pageNumber = 1);
    }
}
