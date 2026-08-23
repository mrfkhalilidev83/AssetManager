using AssetManager.Domain.Enums;

namespace AssetManager.Domain.Entities;

public class AssetTransaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public AssetType AssetType { get; set; }

    public TransactionType TransactionType { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
}