using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class CastService: ICastService
{
    private readonly ICastRepository _castRepository;
    
    public CastService(ICastRepository castRepository)
    {
        _castRepository = castRepository;
    }
    
    public async Task<CastModel> GetCastDetails(int id)
    {
        var casts = await _castRepository.GetById(id);
        var castDetails = new CastModel
        {
            Id = casts.Id,
            Name = casts.Name,
            ProfilePath = casts.ProfilePath
        };
        return castDetails;
    }
}