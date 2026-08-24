using AssetManager.Domain.Entities;

namespace AssetManager.Application.Repositories.Interfaces;

public interface IAssetTransactionRepository
{
    Task AddAsync(AssetTransaction transaction);

    Task<List<AssetTransaction>> GetByUserIdAsync(int userId);
}