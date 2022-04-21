using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IGenreRepository: IRepository<Genre>
{
    Task<IEnumerable<Genre>> GetAllGenreFromDb();
}