using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICastService
{
    Task<CastModel> GetCastDetails(int id);
}