using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services.Interfaces;

public interface ITransactionService
{
    Task<List<AssetTransaction>> GetHistoryAsync(int userId);
}