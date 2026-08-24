using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<Asset?> GetByUserIdAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        return await _assetRepository.GetByUserIdAsync(userId);
    }

    public async Task<Asset> CreateForUserAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        var existingAsset = await _assetRepository.GetByUserIdAsync(userId);

        if (existingAsset is not null)
            return existingAsset;

        return await _assetRepository.CreateForUserAsync(userId);
    }
}