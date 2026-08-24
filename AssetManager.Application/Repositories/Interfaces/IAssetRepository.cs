using AssetManager.Domain.Entities;

namespace AssetManager.Application.Repositories.Interfaces;

public interface IAssetRepository
{
    Task<Asset?> GetByUserIdAsync(int userId);

    Task<Asset> CreateForUserAsync(int userId);

    Task UpdateAsync(Asset asset);
}