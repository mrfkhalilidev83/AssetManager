using AssetManager.Application.DTOs.Transactions;

namespace AssetManager.Application.Services.Interfaces;

public interface IDepositService
{
    Task DepositAsync(DepositDto request);
}