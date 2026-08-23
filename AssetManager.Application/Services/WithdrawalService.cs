using AssetManager.Application.DTOs.Transactions;
using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Entities;
using AssetManager.Domain.Enums;

namespace AssetManager.Application.Services;

public class WithdrawalService : IWithdrawalService
{
    private readonly IAssetRepository _assetRepository;
    private readonly IAssetTransactionRepository _transactionRepository;

    public WithdrawalService(
        IAssetRepository assetRepository,
        IAssetTransactionRepository transactionRepository)
    {
        _assetRepository = assetRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task WithdrawAsync(WithdrawalDto request)
    {
        if (request.UserId <= 0)
            throw new ArgumentException("Invalid user ID.");

        if (request.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var asset = await _assetRepository.GetByUserIdAsync(request.UserId);

        if (asset is null)
            throw new InvalidOperationException("Asset not found.");

        switch (request.AssetType)
        {
            case AssetType.Gold:

                if (asset.Gold < request.Amount)
                    throw new InvalidOperationException("Insufficient gold balance.");

                asset.Gold -= request.Amount;
                break;

            case AssetType.Silver:

                if (asset.Silver < request.Amount)
                    throw new InvalidOperationException("Insufficient silver balance.");

                asset.Silver -= request.Amount;
                break;

            case AssetType.Toman:

                if (asset.Toman < request.Amount)
                    throw new InvalidOperationException("Insufficient toman balance.");

                asset.Toman -= request.Amount;
                break;

            default:
                throw new ArgumentException("Invalid asset type.");
        }

        asset.UpdatedAt = DateTime.UtcNow;

        await _assetRepository.UpdateAsync(asset);

        var transaction = new AssetTransaction
        {
            UserId = request.UserId,
            AssetType = request.AssetType,
            TransactionType = TransactionType.Withdrawal,
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow
        };

        await _transactionRepository.AddAsync(transaction);
    }
}