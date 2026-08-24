using AssetManager.Application.DTOs.Transactions;

namespace AssetManager.Application.Services.Interfaces;

public interface IWithdrawalService
{
    Task WithdrawAsync(WithdrawalDto request);
}