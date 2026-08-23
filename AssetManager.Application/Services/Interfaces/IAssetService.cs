using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services.Interfaces;

public interface IAssetService
{
    Task<Asset?> GetByUserIdAsync(int userId);

    Task<Asset> CreateForUserAsync(int userId);
}