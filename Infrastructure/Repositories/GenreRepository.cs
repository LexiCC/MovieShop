using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }

    //在repo里拿到所有genres' entity data
    public async Task<IEnumerable<Genre>> GetAllGenreFromDb()
    {
        var genre = await _dbContext.Genres.ToListAsync();
        return genre;
    }
}