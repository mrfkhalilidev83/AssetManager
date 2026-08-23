using AssetManager.Domain.Enums;

namespace AssetManager.Application.DTOs.Transactions;

public class DepositDto
{
    public int UserId { get; set; }

    public AssetType AssetType { get; set; }

    public decimal Amount { get; set; }
}