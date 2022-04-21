using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CastRepository : Repository<Cast>, ICastRepository
{
    public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
    }
    
    public override async Task<Cast> GetById(int id)
    {
        var cast = await _dbContext.Casts.Include(c=> c.Name).Include(c=> c.ProfilePath)
            .Include(c=> c.TmdbUrl).Include(c => c.Gender)
            .FirstOrDefaultAsync(c=> c.Id == id);
    
        return cast;
    }
}