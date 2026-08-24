using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IAssetTransactionRepository _transactionRepository;

    public TransactionService(
        IAssetTransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<List<AssetTransaction>> GetHistoryAsync(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Invalid user ID.");

        return await _transactionRepository.GetByUserIdAsync(userId);
    }
}