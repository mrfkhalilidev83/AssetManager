using AssetManager.Application.DTOs.Transactions;
using AssetManager.Application.Repositories.Interfaces;
using AssetManager.Application.Services.Interfaces;
using AssetManager.Domain.Entities;

namespace AssetManager.Application.Services;

public class DepositService : IDepositService
{
    private readonly IAssetRepository _assetRepository;
    private readonly IAssetTransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DepositService(
        IAssetRepository assetRepository,
        IAssetTransactionRepository transactionRepository,
        IUnitOfWork unitOfWork)
    {
        _assetRepository = assetRepository;
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task DepositAsync(DepositDto request)
    {
        if (request.UserId <= 0)
            throw new ArgumentException("Invalid user ID.");

        if (request.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var asset = await _assetRepository.GetByUserIdAsync(request.UserId);

        bool isNewAsset = false;

        if (asset is null)
        {
            asset = await _assetRepository.CreateForUserAsync(request.UserId);
            isNewAsset = true;
        }

        switch (request.AssetType)
        {
            case Domain.Enums.AssetType.Gold:
                asset.Gold += request.Amount;
                break;

            case Domain.Enums.AssetType.Silver:
                asset.Silver += request.Amount;
                break;

            case Domain.Enums.AssetType.Toman:
                asset.Toman += request.Amount;
                break;

            default:
                throw new ArgumentException("Invalid asset type.");
        }

        asset.UpdatedAt = DateTime.UtcNow;

        var transaction = new AssetTransaction
        {
            UserId = request.UserId,
            AssetType = request.AssetType,
            TransactionType = Domain.Enums.TransactionType.Deposit,
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow
        };

        if (!isNewAsset)
        {
            await _assetRepository.UpdateAsync(asset);
        }
        await _transactionRepository.AddAsync(transaction);

        await _unitOfWork.SaveChangesAsync();
    }
}